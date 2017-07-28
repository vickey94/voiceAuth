﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace voice2text.action
{
 /**
   * 流程为：
   * MSPLogin登录，
   * SessionBggin开启本次会话，
   * AudioWrite均匀上传数据到服务器，
   * 传送最后一块结束本次上传，这里常常传送一块空数据
   * getResult，数据传送期间可以多次调用获取数据，结束后再调用多次，直到确定已经结束
   * **/
    /// <summary>
    /// 语音识别类
    /// </summary>
    class MSCAction
    {

        /// <summary>
        /// 函数调用成功返回字符串格式的sessionID，失败返回NULL。sessionID是本次评测的句柄。参数只在当次评测中生效.
        /// </summary>
        private string sess_id;

        /// <summary>
        /// 每次输入输出字节流大小，
        /// 这里要注意，如果和AudioAction里的音频读取流混用,即每次录音后就上传服务器，则大小要设置为一致3200
        /// </summary>
        private const int BUFFER_NUM = 1024 * 20;

        private const int Recording_BUFFER_NUM = 3200;

        /// <summary>
        /// 端点检测
        /// 0 还没有检测到音频的前端点
        /// 1 已经检测到了音频前端点，正在进行正常的音频处理
        /// 3 检测到音频的后端点，后继的音频会被MSC忽略 
        /// </summary>
        private int ep_status = -1;

        /// <summary>
        /// 识别器返回的状态，提醒用户及时开始\停止获取识别结果
        /// 0:识别成功，有识别结果返回 
        /// 1:识别结束，没有识别结果
        /// 2:正在识别
        /// 5:识别结束，有识别结果返回
        /// </summary>
        private int rec_status = -1;
        private int rslt_status = -1;

        /// <summary>
        /// 用于获取当前服务器返回的所有结果
        /// </summary>
        private string nowResult = "";

        /// <summary>
        /// 结果获取结束后，将状态置为 1,Listener监听到为1时，结束本次所有线程
        /// </summary>
        private int nowResultStatus = 0;

        /// <summary>
        /// 输入文件地址
        /// </summary>
        private string inFile = "";


        /// <summary>
        /// 开启Session，iat模式，garmmarList = null 
        /// </summary>
        /// <param name="param">本次会话参数param = "sub=iat,rate=16000,ent=sms16k,rst=plain,vad_eos=5000";</param>
        public void SessionBegin(string grammarList, string param)
        {
            int ret = 0;

            ///第二个参数为传递的参数，使用会话模式，使用speex编解码，使用16k16bit的音频数据
            ///第三个参数为返回码
            sess_id = Util.Ptr2Str(MSCDll.QISRSessionBegin(grammarList, param, ref ret));
            if (ret != 0) throw new Exception("QISRSessionBegin失败 errCode=" + ret);
            Console.WriteLine(Util.getNowTime() + " 本次语音识别会话开始！SessionBegin");
        }

        /// <summary>
        /// 结束本次会话，一定要在数据获取完成后
        /// </summary>
        public void SessionEnd()
        {
            int ret = MSCDll.QISRSessionEnd(sess_id, string.Empty);
            Console.WriteLine(Util.getNowTime() + " 本次语音识别会话结束！SessionEnd");

        }



        /// <summary>
        /// 实时流，向服务器传输数据，以实现边说边写的效果,这里adudioStatus没有结束的4状态，只有2状态，
        /// </summary>
        /// <param name="buff"></param>
        public void AudioWrite(byte[] buff)
        {
            int ret = 0;
            IntPtr bp = Marshal.AllocHGlobal(Recording_BUFFER_NUM);
            Marshal.Copy(buff, 0, bp, buff.Length);
            ///开始向服务器发送音频数据
            ret = MSCDll.QISRAudioWrite(sess_id, bp, (uint)Recording_BUFFER_NUM, 2, ref ep_status, ref rec_status);
            if (ret != 0)
            {
                Console.WriteLine(ret);
                throw new Exception("QISRAudioWrite err,errCode=" + ret);
            }
        }

        /// <summary>
        /// 输入音频文件，将数据传到服务器,需要一个线程
        /// 输入前调用setINFILE方法把文件地址传入
        /// </summary>
        //<param name="inFile">音频文件，pcm无文件头，采样率16k，数据16位，单声道</param>
        public void AudioWriteFile()
        {
            //  string inFile = @"C:\Users\admin\Desktop\xunfei\wav\city.wav";

            int ret = 0;

            ///输入音频
            if (!File.Exists(inFile)) throw new Exception("文件" + inFile + "不存在！");
            if (inFile.Substring(inFile.Length - 3, 3).ToUpper() != "WAV" && inFile.Substring(inFile.Length - 3, 3).ToUpper() != "PCM")
                throw new Exception("音频文件格式不对！");
            FileStream fp = new FileStream(inFile, FileMode.Open);

            // if (inFile.Substring(inFile.Length - 3, 3).ToUpper() == "WAV") fp.Position = 44; //去除头部

            byte[] buff = new byte[BUFFER_NUM];
            IntPtr bp = Marshal.AllocHGlobal(BUFFER_NUM);
            int len;

            int audioStatus = 1; //用来告知MSC音频发送是否完成

            //发送首块音频
            len = fp.Read(buff, 0, BUFFER_NUM);
            Marshal.Copy(buff, 0, bp, buff.Length);
            ret = MSCDll.QISRAudioWrite(sess_id, bp, (uint)len, audioStatus, ref ep_status, ref rec_status);

            audioStatus = 2;

            while (fp.Position != fp.Length)
            {
                len = fp.Read(buff, 0, BUFFER_NUM);
                Marshal.Copy(buff, 0, bp, buff.Length);

                ///开始向服务器发送音频数据
                ret = MSCDll.QISRAudioWrite(sess_id, bp, (uint)len, audioStatus, ref ep_status, ref rec_status);

                if (ret != 0)
                {
                    fp.Close();
                    throw new Exception("QISRAudioWrite err,errCode=" + ret);
                }

                if (ep_status == 3)
                {
                    Console.WriteLine(Util.getNowTime() + " 检测到音频的后端点，后继的音频会被MSC忽略 ep_status is " + ep_status);
                    break;
                }
                Thread.Sleep(100);
            }
            fp.Close();
            ///最后一块数据
            ret = MSCDll.QISRAudioWrite(sess_id, bp, 1, 4, ref ep_status, ref rec_status);

            Marshal.FreeHGlobal(bp);

            Console.WriteLine(Util.getNowTime() + " 文件上传完毕 ep_status is " + ep_status);
        }



        /// <summary>
        /// 获取识别结果 需要一个线程
        /// 线程循环获取时，先判断是否等于rec_status = 0; 或 rslt_status = 0，如果是，则进行获取，如果rslt_status值为5，则结束获取。
        /// 当写入音频过程中已经有部分识别结果返回时，可以获取结果rec_status = 0。在音频写入完毕后，用户需反复调用此接口，直到识别结果获取完毕（rlstStatus值为5）或返回错误码
        /// </summary>
        public void getResultHandler()
        {

            while (true)
            {
                Thread.Sleep(500);

                ///识别中 这里必须进行一次识别才能获取结果状态，如果直接continue,状态会一直为2
              /* if (rec_status == 2 && rslt_status == 2)
                {
                    Console.WriteLine(Util.getNowTime() + "  识别中:" + nowResult + " 音频流ep_status is " + ep_status + " rec_status is " + rec_status + " rslt_status is " + rslt_status);
                    continue;
                }*/

                ///识别结束，有识别结果返回
                if (rslt_status == 5)
                {
                    nowResult += getResult();
                    Console.WriteLine(Util.getNowTime() + "  识别结束，识别结果:" + nowResult + " 音频流ep_status is " + ep_status + " rec_status is " + rec_status + " rslt_status is " + rslt_status);
                    nowResultStatus = 1;
                    break;
                }
                ///识别结束，没有识别结果
                if (rec_status == 1 || rslt_status == 1)
                {
                    Console.WriteLine(Util.getNowTime() + " 识别结束，没有识别结果:" + nowResult + " 音频流ep_status is " + ep_status + " rec_status is " + rec_status + " rslt_status is " + rslt_status);
                    nowResultStatus = 1;
                    break;
                }

                nowResult += getResult();
                Console.WriteLine(Util.getNowTime() + " 当前结果为:" + nowResult + " 音频流ep_status is " + ep_status + " rec_status is " + rec_status + " rslt_status is " + rslt_status);

            }

        }

        /// <returns>返回获取的文本</returns>
        private string getResult()
        {
            int ret = 0;
            string result = "";

            IntPtr p = MSCDll.QISRGetResult(sess_id, ref rslt_status, 1000, ref ret);

            if (ret != 0){ throw new Exception("QISRGetResult err,errCode=" + ret);}

            if (p != IntPtr.Zero){result = Util.Ptr2Str(p);}

            return result;
        }


        public int getNowResultStatus() { return nowResultStatus; }

        public String getNowResult() { return nowResult; }

        public void SetINFILE(string inFile) { this.inFile = inFile; }

    }

}
