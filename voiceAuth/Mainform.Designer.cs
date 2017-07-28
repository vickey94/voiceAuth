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
            this.panel_train = new System.Windows.Forms.Panel();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.button_train = new System.Windows.Forms.Button();
            this.label_id = new System.Windows.Forms.Label();
            this.panel_monitor = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button_monitor = new System.Windows.Forms.Button();
            this.panel_same = new System.Windows.Forms.Panel();
            this.richTextBox_msg = new System.Windows.Forms.RichTextBox();
            this.progressBar_voice = new System.Windows.Forms.ProgressBar();
            this.panel_train.SuspendLayout();
            this.panel_monitor.SuspendLayout();
            this.panel_same.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_train
            // 
            this.panel_train.Controls.Add(this.textBox_id);
            this.panel_train.Controls.Add(this.button_train);
            this.panel_train.Controls.Add(this.label_id);
            this.panel_train.Font = new System.Drawing.Font("微软雅黑", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_train.Location = new System.Drawing.Point(37, 34);
            this.panel_train.Name = "panel_train";
            this.panel_train.Size = new System.Drawing.Size(1058, 231);
            this.panel_train.TabIndex = 0;
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(149, 23);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(300, 51);
            this.textBox_id.TabIndex = 2;
            // 
            // button_train
            // 
            this.button_train.Location = new System.Drawing.Point(759, 35);
            this.button_train.Name = "button_train";
            this.button_train.Size = new System.Drawing.Size(244, 121);
            this.button_train.TabIndex = 1;
            this.button_train.Text = "按住说话";
            this.button_train.UseVisualStyleBackColor = true;
            this.button_train.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button_id_MouseDown);
            this.button_train.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button_id_MouseUp);
            // 
            // label_id
            // 
            this.label_id.AutoSize = true;
            this.label_id.Location = new System.Drawing.Point(21, 23);
            this.label_id.Name = "label_id";
            this.label_id.Size = new System.Drawing.Size(122, 45);
            this.label_id.TabIndex = 0;
            this.label_id.Text = "工号：";
            // 
            // panel_monitor
            // 
            this.panel_monitor.Controls.Add(this.label1);
            this.panel_monitor.Controls.Add(this.button_monitor);
            this.panel_monitor.Font = new System.Drawing.Font("微软雅黑", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_monitor.Location = new System.Drawing.Point(37, 288);
            this.panel_monitor.Name = "panel_monitor";
            this.panel_monitor.Size = new System.Drawing.Size(1058, 225);
            this.panel_monitor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 45);
            this.label1.TabIndex = 3;
            this.label1.Text = "MSG";
            // 
            // button_monitor
            // 
            this.button_monitor.Location = new System.Drawing.Point(772, 45);
            this.button_monitor.Name = "button_monitor";
            this.button_monitor.Size = new System.Drawing.Size(231, 117);
            this.button_monitor.TabIndex = 2;
            this.button_monitor.Text = "开始监听";
            this.button_monitor.UseVisualStyleBackColor = true;
            this.button_monitor.Click += new System.EventHandler(this.button_monitor_Click);
            // 
            // panel_same
            // 
            this.panel_same.Controls.Add(this.richTextBox_msg);
            this.panel_same.Controls.Add(this.progressBar_voice);
            this.panel_same.Font = new System.Drawing.Font("微软雅黑", 14.14286F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel_same.Location = new System.Drawing.Point(37, 537);
            this.panel_same.Name = "panel_same";
            this.panel_same.Size = new System.Drawing.Size(1058, 378);
            this.panel_same.TabIndex = 2;
            // 
            // richTextBox_msg
            // 
            this.richTextBox_msg.Location = new System.Drawing.Point(3, 3);
            this.richTextBox_msg.Name = "richTextBox_msg";
            this.richTextBox_msg.Size = new System.Drawing.Size(1052, 337);
            this.richTextBox_msg.TabIndex = 1;
            this.richTextBox_msg.Text = "";
            // 
            // progressBar_voice
            // 
            this.progressBar_voice.Location = new System.Drawing.Point(3, 346);
            this.progressBar_voice.Name = "progressBar_voice";
            this.progressBar_voice.Size = new System.Drawing.Size(1052, 29);
            this.progressBar_voice.TabIndex = 0;
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 944);
            this.Controls.Add(this.panel_same);
            this.Controls.Add(this.panel_monitor);
            this.Controls.Add(this.panel_train);
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
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_monitor;
    }
}

