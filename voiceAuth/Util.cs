using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace voiceAuth
{
    /// <summary>
    /// 工具类
    /// </summary>
    class Util
    {
        public static string getNowTime()
        {
            return String.Format("{0:yyy-MM-dd HH-mm-ss}", DateTime.Now);
        }

        /// <summary>
        /// 返回声音大小介于0-100之间
        /// </summary>
        /// <param name="temp_waveBuffer"></param>
        /// <returns></returns>
        public static int getVolume(byte[] temp_waveBuffer)
        {
            long sh = System.BitConverter.ToInt64(temp_waveBuffer, 0);

            long width = (long)Math.Pow(2, 50);
            float svolume = Math.Abs(sh / width);
            if (svolume > 1500.0f) { svolume = 1500.0f; }

            svolume = svolume / 15.0f;

            return  (int)svolume;
        }

        /// <summary>
        /// 指针转字符串
        /// </summary>
        /// <param name="p">指向非托管代码字符串的指针</param>
        /// <returns>返回指针指向的字符串</returns>
        public static string Ptr2Str(IntPtr p)
        {
            List<byte> lb = new List<byte>();
            while (Marshal.ReadByte(p) != 0)
            {
                lb.Add(Marshal.ReadByte(p));
                p = p + 1;
            }
            byte[] bs = lb.ToArray();

            return Encoding.Default.GetString(bs);
        }


        /// <summary>
        /// 全局监控开始调用登录
        /// </summary>
        public static void MSPLogin()
        {
            //使用其他接口前必须先调用MSPLogin，可以在应用程序启动时调用。
            int ret = MSCDll.MSPLogin(null, null, Config.PARAMS_LOGIN);
            if (ret == 0) Console.WriteLine(Util.getNowTime() + " 讯飞语音会话登录成功！");
            else throw new Exception("MSPLogin失败 errCode=" + ret);
        }

        /// <summary>
        /// 文本输出
        /// </summary>
        /// <param name="path"></param>
        /// <param name="text"></param>
        public static void Write2TXT(string path, string text)
        {
            FileStream fs = new FileStream(path, FileMode.Append);
            //获得字节数组
            byte[] data = Encoding.UTF8.GetBytes(text + "\r\n");
            //开始写入
            fs.Write(data, 0, data.Length);
            //清空缓冲区、关闭流
            fs.Flush();
            fs.Close();
        }


        public static string FormatTime(long sec)
        {
            int D, H, M, S;

            D = (int)(sec / 86400);

            H = (int)(sec % 86400 / 3600);

            M = (int)(sec % 86400 % 3600 / 60);

            S = (int)(sec % 8600 % 3600 % 60);

            return D + "天" + H + "小时" + M + "分钟" + S + "分钟";
        }
    }
}
