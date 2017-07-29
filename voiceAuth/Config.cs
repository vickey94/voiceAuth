﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voiceAuth
{
    class Config
    {
        /// <summary>
        ///  MSPLogin 登录 appid 参数
        /// </summary>
        public static readonly string PARAMS_LOGIN = "appid=5964bde1";


        /// <summary>
        /// SessionBegin IAT
        /// </summary>
        public static readonly string PARAMS_SESSION_IAT = "sub=iat,ptt = 0, rate=16000,ent=sms16k,rst=plain,vad_eos=3000,plain = utf-8 ,aue = speex-wb";

        /// <summary>
        /// 语法模式 ASR
        /// </summary> 
        public static readonly string PARAMS_SESSION_ASR = "sub = asr, result_type = plain, sample_rate = 16000,aue = speex-wb,ent=sms16k";


        /// "sub = asr, result_type = plain, result_encoding = gb2312,sample_rate = 16000,aue = speex-wb,ent=sms16k";


        /// <summary>
        /// 上传语法后的获取的唯一grammarList，下次可以直接使用
        /// </summary>
        public static string grammarList = "8f78114ce1f29dc1906c58220b113d4d";


        /// <summary>
        /// 每次输入输出字节流大小，
        /// 这里要注意，如果和AudioAction里的音频读取流混用,即每次录音后就上传服务器，则大小要设置为一致3200
        /// </summary>
        public const int File_BUFFER_NUM = 1024 * 20;

        public const int Recording_BUFFER_NUM = 3200;

        /// <summary>
        /// 文件输出文件夹
        /// </summary>
        public static string outputFolder = "D:";


        public static string outputTXT = "识别记录.txt";

        /// <summary>
        /// 上传语音文件地址
        /// </summary>
        public static readonly string uploadDataFile = "";




        public static  bool isSpeeking = false;



        /// <summary>
        /// 用于提前存储数据，2个单位的存储理论上够用，这里建议不要用List之类的，因为这里要求处理器在10ms内发出去数据和硬盘写出数据，如果使用List,或单位过大，容易出错
        /// </summary>
        public static byte[] advData1 = null;
        public static byte[] advData2 = null;




        ////////////////////////////////////////////
        ///
        /////////////////////////////////////////////
       
    }
}
