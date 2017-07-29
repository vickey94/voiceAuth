
namespace  voiceAuth.model
{
    /// <summary>
    /// 进行一次语音验证的模型
    /// </summary>
    class Auth
    {

        /// <summary>
        /// 开始时间，对应音频文件名称
        /// </summary>
        private string time = "null";

        /// <summary>
        /// 返回的语音验证文本
        /// </summary>
        private string text = "null";

        /// <summary>
        /// 验证的用户id
        /// </summary>
        private string id = "null";

        /// <summary>
        /// 验证结果（成功or失败）
        /// </summary>
        private bool result = false;

        public Auth(string time)
        {
            this.time = time;
        }


        public void setText(string text) { this.text = text; }
        public void setId(string id) { this.id = id; }


        public string getWriteText()
        {
            return time + "," + id + "," + text+","+result;
        }

        /// <summary>
        /// 获取音频文件地址
        /// </summary>
        /// <returns></returns>
        public string getRunPath_wav() { return Config.outputFolder + "\\run\\wav\\" + time + ".wav"; }
        /// <summary>
        /// 获取日子文件地址
        /// </summary>
        /// <returns></returns>
        public string getRunPath_txt() { return Config.outputFolder + "\\run\\" + Config.outputTXT; }
    }
}
