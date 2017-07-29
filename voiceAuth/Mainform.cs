using System;

using System.Windows.Forms;
using voiceAuth.action;

namespace voiceAuth
{
    public partial class Mainform : Form
    {

        private MainformAction mfa;

        public Mainform()
        {
            InitializeComponent();
      
            mfa = new MainformAction(this);
        }
        ~Mainform()
        {
            
        }
        AudioAction au;
        private void button_listener_Click(object sender, EventArgs e)
        {

            //  mfa.StartListening(textBox_grammarList.Text);

        }


        private void button_endlistener_Click(object sender, EventArgs e)
        {
            //  mfa.StopListening();

        }

        private void button_id_MouseDown(object sender, MouseEventArgs e)
        {
            button_train.Text = "正在录音";
            mfa.StartTraining(textBox_id.Text);

        }

        private void button_id_MouseUp(object sender, MouseEventArgs e)
        {
          
              button_train.Text = "正在处理";
            mfa.StopTraining();
            button_train.Text = "按住说话";
            label_train_time.Text = "准备录制";
        }


        private void button_grammarList_Click(object sender, EventArgs e)
        {
            mfa.UploadABNF();
        }

        /// <summary>
        /// 设置进度条
        /// </summary>
        /// <param name="value"></param>
        public void setProgressBar(int value)
        {
            progressBar_voice.Invoke(new MethodInvoker(delegate ()
            {
                progressBar_voice.Value = value;
            }));

        }

        /// <summary>
        /// 输出控制信息
        /// </summary>
        /// <param name="value"></param>
        public void setRichTextBox(string value)
        {
            richTextBox_msg.Invoke(new MethodInvoker(delegate ()
            {
                richTextBox_msg.AppendText(value);
                richTextBox_msg.ScrollToCaret();
            }));
        }


   
        public void setTrainLabelTime(string value)
        {
            label_train_time.Invoke(new MethodInvoker(delegate ()
            {
                label_train_time.Text = value;
            }));
        }

        public void setListenerLabelTime(string value)
        {
            label_listener_time.Invoke(new MethodInvoker(delegate ()
            {
                label_listener_time.Text = value;
            }));
        }

        public void setTextBox_grammarList(string value)
        {
            textBox_grammarList.Invoke(new MethodInvoker(delegate ()
            {
                textBox_grammarList.Text = value;
            }));

        }

   
    }
}
