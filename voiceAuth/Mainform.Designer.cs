namespace voiceAuth
{
    partial class Mainform
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel_train = new System.Windows.Forms.Panel();
            this.button_path = new System.Windows.Forms.Button();
            this.label_path = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label_train_time = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.button_train = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.panel_monitor = new System.Windows.Forms.Panel();
            this.button_endlistener = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_grammarList = new System.Windows.Forms.TextBox();
            this.button_grammarList = new System.Windows.Forms.Button();
            this.label_listener_time = new System.Windows.Forms.Label();
            this.button_listener = new System.Windows.Forms.Button();
            this.panel_same = new System.Windows.Forms.Panel();
            this.richTextBox_msg = new System.Windows.Forms.RichTextBox();
            this.progressBar_voice = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel_train.SuspendLayout();
            this.panel_monitor.SuspendLayout();
            this.panel_same.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_train
            // 
            this.panel_train.Controls.Add(this.button_path);
            this.panel_train.Controls.Add(this.label_path);
            this.panel_train.Controls.Add(this.textBox_path);
            this.panel_train.Controls.Add(this.label_train_time);
            this.panel_train.Controls.Add(this.textBox_id);
            this.panel_train.Controls.Add(this.button_train);
            this.panel_train.Controls.Add(this.label_id);
            this.panel_train.Font = new System.Drawing.Font("微软雅黑", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_train.Location = new System.Drawing.Point(37, 33);
            this.panel_train.Margin = new System.Windows.Forms.Padding(4);
            this.panel_train.Name = "panel_train";
            this.panel_train.Size = new System.Drawing.Size(1412, 186);
            this.panel_train.TabIndex = 0;
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(1023, 17);
            this.button_path.Margin = new System.Windows.Forms.Padding(4);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(360, 60);
            this.button_path.TabIndex = 6;
            this.button_path.Text = "设置路径";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.button_path_Click);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Location = new System.Drawing.Point(20, 26);
            this.label_path.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_path.Name = "label_path";
            this.label_path.Size = new System.Drawing.Size(190, 45);
            this.label_path.TabIndex = 5;
            this.label_path.Text = "数据路径：";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(251, 23);
            this.textBox_path.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(734, 51);
            this.textBox_path.TabIndex = 4;
            // 
            // label_train_time
            // 
            this.label_train_time.AutoSize = true;
            this.label_train_time.Location = new System.Drawing.Point(20, 112);
            this.label_train_time.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label_train_time.Name = "label_train_time";
            this.label_train_time.Size = new System.Drawing.Size(156, 45);
            this.label_train_time.TabIndex = 3;
            this.label_train_time.Text = "准备录制";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(552, 112);
            this.textBox_id.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(433, 51);
            this.textBox_id.TabIndex = 2;
            // 
            // button_train
            // 
            this.button_train.Location = new System.Drawing.Point(1023, 103);
            this.button_train.Margin = new System.Windows.Forms.Padding(4);
            this.button_train.Name = "button_train";
            this.button_train.Size = new System.Drawing.Size(360, 60);
            this.button_train.TabIndex = 1;
            this.button_train.Text = "按住说话";
            this.button_train.UseVisualStyleBackColor = true;
            this.button_train.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_id_MouseDown);
            this.button_train.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_id_MouseUp);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(366, 112);
            this.label_id.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(122, 45);
            this.label_id.TabIndex = 0;
            this.label_id.Text = "工号：";
            // 
            // panel_monitor
            // 
            this.panel_monitor.Controls.Add(this.button_endlistener);
            this.panel_monitor.Controls.Add(this.label1);
            this.panel_monitor.Controls.Add(this.textBox_grammarList);
            this.panel_monitor.Controls.Add(this.button_grammarList);
            this.panel_monitor.Controls.Add(this.label_listener_time);
            this.panel_monitor.Controls.Add(this.button_listener);
            this.panel_monitor.Font = new System.Drawing.Font("微软雅黑", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_monitor.Location = new System.Drawing.Point(37, 226);
            this.panel_monitor.Margin = new System.Windows.Forms.Padding(4);
            this.panel_monitor.Name = "panel_monitor";
            this.panel_monitor.Size = new System.Drawing.Size(1415, 192);
            this.panel_monitor.TabIndex = 1;
            // 
            // button_endlistener
            // 
            this.button_endlistener.Location = new System.Drawing.Point(1023, 101);
            this.button_endlistener.Margin = new System.Windows.Forms.Padding(4);
            this.button_endlistener.Name = "button_endlistener";
            this.button_endlistener.Size = new System.Drawing.Size(360, 60);
            this.button_endlistener.TabIndex = 7;
            this.button_endlistener.Text = "结束监听";
            this.button_endlistener.UseVisualStyleBackColor = true;
            this.button_endlistener.Click += new System.EventHandler(this.button_endlistener_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(221, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = "语法文件id：";
            // 
            // textBox_grammarList
            // 
            this.textBox_grammarList.Location = new System.Drawing.Point(251, 22);
            this.textBox_grammarList.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_grammarList.Name = "textBox_grammarList";
            this.textBox_grammarList.Size = new System.Drawing.Size(849, 51);
            this.textBox_grammarList.TabIndex = 5;
            // 
            // button_grammarList
            // 
            this.button_grammarList.Location = new System.Drawing.Point(1110, 16);
            this.button_grammarList.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.button_grammarList.Name = "button_grammarList";
            this.button_grammarList.Size = new System.Drawing.Size(273, 60);
            this.button_grammarList.TabIndex = 4;
            this.button_grammarList.Text = "上传语法文件";
            this.button_grammarList.UseVisualStyleBackColor = true;
            this.button_grammarList.Click += new System.EventHandler(this.button_grammarList_Click);
            // 
            // label_listener_time
            // 
            this.label_listener_time.AutoSize = true;
            this.label_listener_time.Location = new System.Drawing.Point(20, 110);
            this.label_listener_time.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_listener_time.Name = "label_listener_time";
            this.label_listener_time.Size = new System.Drawing.Size(156, 45);
            this.label_listener_time.TabIndex = 3;
            this.label_listener_time.Text = "准备监听";
            // 
            // button_listener
            // 
            this.button_listener.Location = new System.Drawing.Point(592, 101);
            this.button_listener.Margin = new System.Windows.Forms.Padding(4);
            this.button_listener.Name = "button_listener";
            this.button_listener.Size = new System.Drawing.Size(360, 60);
            this.button_listener.TabIndex = 2;
            this.button_listener.Text = "开始监听";
            this.button_listener.UseVisualStyleBackColor = true;
            this.button_listener.Click += new System.EventHandler(this.button_listener_Click);
            // 
            // panel_same
            // 
            this.panel_same.Controls.Add(this.richTextBox_msg);
            this.panel_same.Controls.Add(this.progressBar_voice);
            this.panel_same.Font = new System.Drawing.Font("微软雅黑", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_same.Location = new System.Drawing.Point(37, 426);
            this.panel_same.Margin = new System.Windows.Forms.Padding(4);
            this.panel_same.Name = "panel_same";
            this.panel_same.Size = new System.Drawing.Size(1415, 490);
            this.panel_same.TabIndex = 2;
            // 
            // richTextBox_msg
            // 
            this.richTextBox_msg.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_msg.Margin = new System.Windows.Forms.Padding(4);
            this.richTextBox_msg.Name = "richTextBox_msg";
            this.richTextBox_msg.Size = new System.Drawing.Size(1411, 449);
            this.richTextBox_msg.TabIndex = 1;
            this.richTextBox_msg.Text = "";
            // 
            // progressBar_voice
            // 
            this.progressBar_voice.Location = new System.Drawing.Point(0, 457);
            this.progressBar_voice.Margin = new System.Windows.Forms.Padding(4);
            this.progressBar_voice.Name = "progressBar_voice";
            this.progressBar_voice.Size = new System.Drawing.Size(1415, 40);
            this.progressBar_voice.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 936);
            this.Controls.Add(this.panel_same);
            this.Controls.Add(this.panel_monitor);
            this.Controls.Add(this.panel_train);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Mainform";
            this.Text = "VoiceAuth";
            this.panel_train.ResumeLayout(false);
            this.panel_train.PerformLayout();
            this.panel_monitor.ResumeLayout(false);
            this.panel_monitor.PerformLayout();
            this.panel_same.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_train;
        private System.Windows.Forms.Panel panel_monitor;
        private System.Windows.Forms.Panel panel_same;
        public System.Windows.Forms.RichTextBox richTextBox_msg;
        public System.Windows.Forms.ProgressBar progressBar_voice;
        private System.Windows.Forms.Label label_id;
        public System.Windows.Forms.TextBox textBox_id;
        public System.Windows.Forms.Button button_train;
        public System.Windows.Forms.Label label_listener_time;
        public System.Windows.Forms.Button button_listener;
        private System.Windows.Forms.Label label_train_time;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox_grammarList;
        private System.Windows.Forms.Button button_grammarList;
        public System.Windows.Forms.Button button_endlistener;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.Button button_path;
        private System.Windows.Forms.Label label_path;
        public System.Windows.Forms.TextBox textBox_path;
    }
}

