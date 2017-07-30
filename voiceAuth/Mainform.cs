using System;

using System.Windows.Forms;
using voiceAuth.action;

namespace voiceAuth
{
    /// <summary>
    /// 首先要设置项目数据存放的文件夹，然后创建
    /// </summary>
    public partial class Mainform : Form
    {
        /// <summary>
        /// 持续时间
        /// </summary>
        private long duration;

        private MainformAction mfa;

        public Mainform()
        {
            InitializeComponent();

            mfa = new MainformAction(this);

            textBox_grammarList.Text = Config.grammarList;
            button_endlistener.Enabled = false;
            textBox_path.Text = Config.outputFolder;


            button_train.Enabled = false;
            button_listener.Enabled = false;

        }
        ~Mainform()
        {
            
        }

        private void button_path_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "选择项目数据存放文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Config.outputFolder = dialog.SelectedPath;
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    Config.outputFolder = @"D:";
                }        

            }
            textBox_path.Text = Config.outputFolder;


            mfa.CreateFolder();      

            button_train.Enabled = true;
            button_listener.Enabled = true;

        }

        private void button_listener_Click(object sender, EventArgs e)
        {
            duration = 0;
            timer1.Start();
            button_listener.Enabled = false;
            button_grammarList.Enabled = false;
            button_endlistener.Enabled = true;
            mfa.StartListening(textBox_grammarList.Text);

        }


        private void button_endlistener_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button_grammarList.Enabled = true;
            button_listener.Enabled = true;
              mfa.StopListening();

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
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "打开语法文件";
            fdlg.Filter = "ABNF(*.abnf)|*.abnf|All files(*.*)|*.*";

            fdlg.RestoreDirectory = true;
            
            if (fdlg.ShowDialog() == DialogResult.OK)
            {
               string path = fdlg.FileName;
                mfa.UploadABNF(path);
            }

           
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
       
        private void timer1_Tick(object sender, EventArgs e)
        {
            duration++;
            label_listener_time.Text = Util.FormatTime(duration);
        }


    }
}
