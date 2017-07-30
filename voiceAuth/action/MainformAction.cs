
using System;
using System.IO;
using System.Threading;
using voiceAuth.model;

namespace voiceAuth.action
{
    /// <summary>
    /// 为Mainform调用
    /// 
    /// </summary>
    class MainformAction
    {
        private Mainform mf = null;

        private MSCAction msc =null;

        private AudioAction audio =null;

        private Train train; ///一次训练对象

        private Auth auth; ///一次识别对象

        private string res; //监控线程获取到的文本

        /// <summary>
        /// 文件上传线程
        /// </summary>
        private Thread msc_Uploadfile = null;

        /// <summary>
        /// 循环获取结果，结束标志为nowResultStatus = 1
        /// </summary>
        private Thread msc_result = null;

        /// <summary>
        /// 一次会话监控线程
        /// </summary>
        private Thread session_monitor = null;

        /// <summary>
        /// 主监控线程
        /// </summary>
        private Thread main_monitor = null;

        /// <summary>
        /// 环境声音监控
        /// </summary>
        private AudioAction voice_Monitor;





        public MainformAction(Mainform mf)
        {
            this.mf = mf;

            Util.MSPLogin(); //登录
        }

        public void CreateFolder()
        {

            ///本次输出文件夹          
            Config.outputFolder = Config.outputFolder + "\\" + Util.getNowTime();

            if (Directory.Exists((Config.outputFolder)) == false)//如果不存在就创建文件夹
            {
                Directory.CreateDirectory(Config.outputFolder);   //本次文件夹

                //训练文件夹
                Directory.CreateDirectory(Config.outputFolder + "\\train\\wav");  //本次语音文件          
                File.Create(Config.outputFolder + "\\train\\" + Config.outputTXT).Close(); //本次语音记录

                //识别文件夹
                Directory.CreateDirectory(Config.outputFolder + "\\run\\wav");
                File.Create(Config.outputFolder + "\\run\\" + Config.outputTXT).Close();

            }
        }

        ~MainformAction()
        {
            
        }

        /// <summary>
        /// 开始一次训练
        /// </summary>
        public void StartTraining(string id)
        {
            string time = Util.getNowTime();
            string text =  time + " 鼠标已经按下，正在录音\n";
            setRichTextBox(text);

            msc = new MSCAction(this);
            audio = new AudioAction(this);
            train = new Train(id,time);

            msc.SessionBegin(null, Config.PARAMS_SESSION_IAT);

            audio.init(null,train.getTrainPath_wav());
            audio.StartRecordingHandler();
        }

        /// <summary>
        /// 训练结束
        /// </summary>
        public void StopTraining()
        {
            string text = Util.getNowTime() + " 鼠标已经松开，停止录音\n";
            setRichTextBox(text);

            audio.StopRecording();

            msc.SetINFILE(train.getTrainPath_wav());

            setRichTextBox(Util.getNowTime()+" 正在识别语音，请等待\n");

            msc_Uploadfile = new Thread(new ThreadStart(msc.AudioWriteFile));

            ///获取结果
            msc_result = new Thread(new ThreadStart(msc.getResultHandler));

            session_monitor = new Thread(new ThreadStart(TrainSessionMonitor));

            msc_Uploadfile.Start();
            msc_result.Start();
            session_monitor.Start();
          

        }

        private void TrainSessionMonitor()
        {
            int status = -1;
            while (true)
            {
                Thread.Sleep(200);

                if (msc != null)
                {
                    res = msc.getNowResult(); //防止msc对象还没有创建就开始获取结果
                    status = msc.getNowResultStatus();
                }           

                if(status == 1) //监听到结束
                {
                    msc_Uploadfile.Abort();
                    msc_result.Abort();

                    msc.SessionEnd();

                    train.setText(res);
                    Util.Write2TXT(train.getTrainPath_txt(), train.getWriteText());
                    setRichTextBox("识别结果为："+ train.getWriteText()+"\n");
                    setProgressBar(0);

                    audio = null;
                    msc = null;
                    train = null;
                    res = null;

                    session_monitor.Abort();
                }
                
            }
        }






        /// <summary>
        /// 开启监听
        /// </summary>
        public void StartListening(string grammarList)
        {
            Config.grammarList = grammarList;

            setRichTextBox(Util.getNowTime() + " 监听开始\n");

            main_monitor = new Thread(new ThreadStart(Monitor));
            main_monitor.Start();

        }

        /// <summary>
        /// 结束监听
        /// </summary>
        public void StopListening()
        {
            setRichTextBox(Util.getNowTime() + " 监听结束\n");
            main_monitor.Abort();

        /*    if(msc_result!=null)
            {
                msc_result.Abort();
              
            }

            if (session_monitor.IsAlive)
            {
                session_monitor.Abort();
               
            }*/

            msc_result = null;
            session_monitor = null;

            main_monitor = null;
            msc = null;
            audio = null;

            voice_Monitor = null;

            auth = null;

        }


        private void voice_MonitorOpen()
        {
            voice_Monitor = new AudioAction(this);
            voice_Monitor.initMonitor();
            voice_Monitor.StartMonitoringHandler(); //自带线程
        }

        /// <summary>
        /// 主监控，控制指令识别开始
        /// </summary>
        public void Monitor()
        {
            ///创建监控
            voice_MonitorOpen();

            ///开始监听
            while (true)
            {
                Thread.Sleep(50);

                if (Config.isSpeeking)
                {
                    //voice_Monitor.StopMonitoring(); 这里已经自动暂停了，所以不需要

                    Config.isSpeeking = false;//重置状态

                    auth = new Auth(Util.getNowTime()); ///设置本次验证对象

                    ///开启连续语音识别
                    StartSession_IAT(auth);

                    session_monitor = new Thread(new ThreadStart(AuthSessionMonitor));
                    session_monitor.Start();

                }
            }
        }

        /// <summary>
        /// 用于结束本次会话，同时让主线程继续循环
        /// </summary>
        public void AuthSessionMonitor()
        {
            int status = -1; //结果获取完成结束标识
            while (true)
            {
                Thread.Sleep(200); //每500ms监控一次 ，这里要注意，防止数据还未获取完就结束线程！

                if (msc != null)
                {
                    res = msc.getNowResult(); //防止msc对象还没有创建就开始获取结果
                    status = msc.getNowResultStatus();
                }

                ///msc ,audio 都不为空为连续语音识别情况（IAT）
                if (msc != null && audio != null)
                {
                    if(msc.getNowEp_status()==3) //获取当前连续语音识别是否提前结束
                    {

                        StopSession_IAT();
                        setRichTextBox(Util.getNowTime() + " 端点结束，请再次尝试！\n");
                        Console.WriteLine(Util.getNowTime() + " 端点结束" + res);

                        // voice_Monitor.StartMonitoringHandler();
                        voice_MonitorOpen();
                       
                        session_monitor.Abort();///结束本身线程
                    }

                    if (res.Length > 6) //这里验证连续语音识别结束条件
                    {
                        StopSession_IAT();

                        Console.WriteLine(Util.getNowTime() + " 输入数据值达到上限，结束本次会话，最后结果为：" + res);

                        Console.WriteLine("ASR再次验证开始！");

                        setRichTextBox(Util.getNowTime() + " 连续语音识别结束，现在开始语音验证\n");
                        StartSession_ASR(auth);

                    }
                }

                if (msc != null && audio == null) ///这里为ASR情况的验证结束
                {
                    if (status == 1)
                    {

                       
                        StopSession_ASR();
                        Console.WriteLine("再次验证结束！");

                        
                        //  voice_Monitor.StartMonitoringHandler(); ///再次开启环境监听
                        voice_MonitorOpen();
                        session_monitor.Abort();///结束本身线程


                    }
                }


            }

        }

        /// <summary>
        /// 连续语音识别开始
        /// </summary>
        private void StartSession_IAT(Auth auth)
        {

            msc = new MSCAction(this);


            msc.SessionBegin(null, Config.PARAMS_SESSION_IAT);

            audio = new AudioAction(this);
            audio.init(msc,auth.getRunPath_wav());

            //录音，上传
            audio.StartRecordingHandler();

            //开启获取结果线程
            msc_result = new Thread(new ThreadStart(msc.getResultHandler));

            msc_result.Start();

        }

        /// <summary>
        /// 连续语音识别结束
        /// </summary>
        private void StopSession_IAT()
        {

          
            msc_result.Abort();

            audio.StopRecording();
            msc.SessionEnd();

            audio = null;
            msc = null;

        }


        /// <summary>
        /// 语法验证是直接传入之前的音频文件，不需要录音,
        /// </summary>
        public void StartSession_ASR(Auth auth)
        {
            msc = new MSCAction(this);
           
            msc.SessionBegin(Config.grammarList, Config.PARAMS_SESSION_ASR);

        
            ///设置文件地址
            msc.SetINFILE(auth.getRunPath_wav());

            msc_Uploadfile = new Thread(new ThreadStart(msc.AudioWriteFile));
            msc_Uploadfile.Start();

            ///获取结果
            msc_result = new Thread(new ThreadStart(msc.getResultHandler));
            msc_result.Start();

        }
        /// <summary>
        /// 语义识别结束
        /// </summary>
        private void StopSession_ASR()
        {

            msc_Uploadfile.Abort();
            msc_result.Abort();

            msc.SessionEnd();

            msc = null;


            //////这里进行其他验证操作！        
            auth.setText(res);

            Util.Write2TXT(auth.getRunPath_txt(), auth.getWriteText());

            setRichTextBox(Util.getNowTime() + " 语音验证结果为" + auth.getWriteText()+ "\n");
            auth = null;
        }




        /// <summary>
        /// 上传语法文件
        /// </summary>
        public void UploadABNF(string path)
        {
            msc = new MSCAction(null);
            string grammarList = msc.UploadData(path);

            setRichTextBox(Util.getNowTime() + " grammarList is " + grammarList+"\n");

            setTextBox_grammarList(grammarList);
        }





        public void setProgressBar(int volume)
        {
            if (mf != null)
                mf.setProgressBar(volume);
        }

        public void setRichTextBox(string value)
        {
            if (mf != null)
                mf.setRichTextBox(value);

        }


        public void setTrainLabelTime(string value)
        {
            if (mf != null)
                mf.setTrainLabelTime(value);

        }

        public void setListenerLabelTime(string value)
        {
            if (mf != null)
                mf.setListenerLabelTime(value);
        }


        public void setTextBox_grammarList(string value)
        {
            if (mf != null)
                mf.setTextBox_grammarList(value);
        }
    }
}
