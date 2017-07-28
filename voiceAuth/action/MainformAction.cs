using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using voice2text.action;
using voice2text.model;

namespace voiceAuth.action
{
    /// <summary>
    /// 为Mainform调用
    /// </summary>
    class MainformAction
    {
        private Mainform mf;

        private MSCAction msc;

        private AudioAction audio;

        private Train train;

        private Auth auth;




        public MainformAction(Mainform mf)
        {
            this.mf = mf;
        }

        ~MainformAction()
        {
            
        }







        /// <summary>
        /// 开始一次训练
        /// </summary>
        public void StartTraining()
        { }

        /// <summary>
        /// 训练结束
        /// </summary>
        public void StopTraining()
        { }






        /// <summary>
        /// 开启监听
        /// </summary>
        public void StartListening()
        { }

        /// <summary>
        /// 结束监听
        /// </summary>
        public void StopListening()
        { }

        /// <summary>
        /// 上传语法文件
        /// </summary>
        public void UploadABNF()
        { }



    }
}
