using NAudio.Wave;
using System;
using System.Threading;
using voiceAuth;
using voiceAuth.model;

namespace voiceAuth.action
{
    /// <summary>
    /// 音频类
    /// </summary>
    class AudioAction
    {
        /// <summary>
        /// MSCAction主要实现向服务器实时传送数据，
        /// </summary>
        private MSCAction msc = null;

        private MainformAction mf = null;

        private string outputPath;

        private IWaveIn waveIn;

        private WaveFileWriter waveWriter;  //数据输出流


        /// <summary>
        /// 前台传递页面，可以为NULL
        /// </summary>
        /// <param name="mf"></param>
        public AudioAction(MainformAction mf)
        {
            this.mf = mf;
        }

        /// <summary>
        /// 设置本次参数，传递MSC,如果为NULL，则只为录音
        /// </summary>
        public void init(MSCAction msc,string outputPath)
        {
            this.msc = msc;
            this.outputPath = outputPath;

            waveIn = new WaveInEvent();
            waveIn.WaveFormat = new WaveFormat(16000, 16, 1); //

            waveWriter = new WaveFileWriter(outputPath, waveIn.WaveFormat);

            waveIn.DataAvailable += OnDataAvailable;
        }

        ///<summary>
        ///录音数据输出
        ///</summary>
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            byte[] temp_waveBuffer = null;

            int length = e.BytesRecorded;

            if (Config.advData1 != null || Config.advData2 != null|| Config.advData3 != null)
            {
                Console.WriteLine("预录音数据传输");

                if(Config.advData1 != null)
                {
                    temp_waveBuffer = Config.advData1;
                    waveWriter.Write(temp_waveBuffer, 0, length);
                    if (msc != null) msc.AudioWrite(temp_waveBuffer);
                    Config.advData1 = null;
                }
                if (Config.advData2 != null)
                {
                    temp_waveBuffer = Config.advData2;
                    waveWriter.Write(temp_waveBuffer, 0, length);
                    if (msc != null) msc.AudioWrite(temp_waveBuffer);
                    Config.advData2 = null;
                }

                if (Config.advData3 != null)
                {
                    temp_waveBuffer = Config.advData3;
                    waveWriter.Write(temp_waveBuffer, 0, length);
                    if (msc != null) msc.AudioWrite(temp_waveBuffer);
                    Config.advData3 = null;
                }
 
            }

            temp_waveBuffer = e.Buffer;

            waveWriter.Write(temp_waveBuffer, 0, e.BytesRecorded);
            if (msc != null) msc.AudioWrite(temp_waveBuffer);

            int volume =  Util.getVolume(temp_waveBuffer);

            mf.setProgressBar(volume);
              int secondsRecorded = (int)(waveWriter.Length / waveWriter.WaveFormat.AverageBytesPerSecond);//录音时间获取 
           mf.setTrainLabelTime("已录制"+ secondsRecorded+"秒");


        }

        ///<summary>
        ///开始录音
        ///</summary>
        public void StartRecordingHandler()
        {
            Console.WriteLine(Util.getNowTime() + " 开始录音");

            waveIn.StartRecording();

            Console.WriteLine("正在录音......");

        }

        /// <summary>
        /// 停止录音
        /// </summary>
        public void StopRecording()
        {
            if (waveIn != null) // 关闭录音对象
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
            }
            if (waveWriter != null)//关闭文件流
            {
                waveWriter.Close();
                waveWriter = null;
            }
            // waveIn.StopRecording();
            Console.WriteLine(Util.getNowTime() + " 录音结束");
        }



        /// <summary>
        ///声音监听模块
        /// </summary>
        private IWaveIn waveMonitor;

        public void initMonitor()
        {

            waveMonitor = new WaveInEvent();
            waveMonitor.WaveFormat = new WaveFormat(16000, 16, 1); //
            waveMonitor.DataAvailable += OnDataAvailableMonitor;

        }

        private void OnDataAvailableMonitor(object sender, WaveInEventArgs e)
        {

            byte[] temp_waveBuffer = e.Buffer;

            SetAdvData(temp_waveBuffer); ///提前存放数据

            long sh = System.BitConverter.ToInt64(temp_waveBuffer, 0);


            int volume = Util.getVolume(temp_waveBuffer);

            mf.setProgressBar(volume);

            if (volume > 15)
            {
                System.Console.WriteLine(Util.getNowTime() + " 监听到较大声音" + string.Format("{0}", volume));

           //     Config.isSpeeking = true;

                mf.setRichTextBox(Util.getNowTime()+" 捕获到声音，开始进行识别\n");

               StopMonitoring(); ///暂停监听
               FinshMonitoring();

                mf.auth = new Auth(Util.getNowTime()); ///设置本次验证对象

                ///开启连续语音识别
                mf.StartSession_IAT(mf.auth);

                mf.session_monitor = new Thread(new ThreadStart(mf.AuthSessionMonitor));
                mf.session_monitor.Start();


            }

           
        }

        public void StartMonitoringHandler()
        {
            Console.WriteLine(Util.getNowTime() + " 开始监听环境声音");

            waveMonitor.StartRecording();
        }

        /// <summary>
        /// 暂停录音，（还可以再次继续）
        /// </summary>
        public void StopMonitoring()
        {
            waveMonitor.StopRecording();
        }

        /// <summary>
        /// 监听结束
        /// </summary>
        public void FinshMonitoring()
        {
            if (waveMonitor != null) // 关闭录音对象
            {
                waveMonitor.Dispose();
                waveMonitor = null;
            }

            Console.WriteLine(Util.getNowTime() + " 录音结束");
        }

        /// <summary>
        /// 用于监听时，提前存入数据
        /// </summary>
        /// <param name="temp"></param>
        private void SetAdvData(byte[] temp)
        {
            Config.advData1 = Config.advData2;
            Config.advData2 = Config.advData3;
            Config.advData3 = temp;
        
        }






    }
}
