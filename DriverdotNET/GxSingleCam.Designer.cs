namespace DriverdotNET
{
    partial class GxSingleCam
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btn_StopDevice = new System.Windows.Forms.Button();
            this.m_btn_StartDevice = new System.Windows.Forms.Button();
            this.m_btn_OpenDevice = new System.Windows.Forms.Button();
            this.m_btn_CloseDevice = new System.Windows.Forms.Button();
            this.m_pic_ShowImage = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_AD7 = new System.Windows.Forms.TextBox();
            this.textBox_AD6 = new System.Windows.Forms.TextBox();
            this.textBox_AD5 = new System.Windows.Forms.TextBox();
            this.textBox_AD4 = new System.Windows.Forms.TextBox();
            this.m_pic2_ShowImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_stitpic_box = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pic_ShowImage)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pic2_ShowImage)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_stitpic_box)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_btn_StopDevice);
            this.groupBox2.Controls.Add(this.m_btn_StartDevice);
            this.groupBox2.Controls.Add(this.m_btn_OpenDevice);
            this.groupBox2.Controls.Add(this.m_btn_CloseDevice);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(259, 101);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "设备控制";
            // 
            // m_btn_StopDevice
            // 
            this.m_btn_StopDevice.Location = new System.Drawing.Point(149, 57);
            this.m_btn_StopDevice.Margin = new System.Windows.Forms.Padding(4);
            this.m_btn_StopDevice.Name = "m_btn_StopDevice";
            this.m_btn_StopDevice.Size = new System.Drawing.Size(102, 29);
            this.m_btn_StopDevice.TabIndex = 4;
            this.m_btn_StopDevice.Text = "停止采集";
            this.m_btn_StopDevice.UseVisualStyleBackColor = true;
            this.m_btn_StopDevice.Click += new System.EventHandler(this.m_btn_StopDevice_Click);
            // 
            // m_btn_StartDevice
            // 
            this.m_btn_StartDevice.Location = new System.Drawing.Point(17, 57);
            this.m_btn_StartDevice.Margin = new System.Windows.Forms.Padding(4);
            this.m_btn_StartDevice.Name = "m_btn_StartDevice";
            this.m_btn_StartDevice.Size = new System.Drawing.Size(100, 29);
            this.m_btn_StartDevice.TabIndex = 3;
            this.m_btn_StartDevice.Text = "开始采集";
            this.m_btn_StartDevice.UseVisualStyleBackColor = true;
            this.m_btn_StartDevice.Click += new System.EventHandler(this.m_btn_StartDevice_Click);
            // 
            // m_btn_OpenDevice
            // 
            this.m_btn_OpenDevice.Location = new System.Drawing.Point(17, 20);
            this.m_btn_OpenDevice.Margin = new System.Windows.Forms.Padding(4);
            this.m_btn_OpenDevice.Name = "m_btn_OpenDevice";
            this.m_btn_OpenDevice.Size = new System.Drawing.Size(100, 29);
            this.m_btn_OpenDevice.TabIndex = 1;
            this.m_btn_OpenDevice.Text = "打开设备";
            this.m_btn_OpenDevice.UseVisualStyleBackColor = true;
            this.m_btn_OpenDevice.Click += new System.EventHandler(this.m_btn_OpenDevice_Click);
            // 
            // m_btn_CloseDevice
            // 
            this.m_btn_CloseDevice.Location = new System.Drawing.Point(149, 20);
            this.m_btn_CloseDevice.Margin = new System.Windows.Forms.Padding(4);
            this.m_btn_CloseDevice.Name = "m_btn_CloseDevice";
            this.m_btn_CloseDevice.Size = new System.Drawing.Size(102, 29);
            this.m_btn_CloseDevice.TabIndex = 2;
            this.m_btn_CloseDevice.Text = "关闭设备";
            this.m_btn_CloseDevice.UseVisualStyleBackColor = true;
            this.m_btn_CloseDevice.Click += new System.EventHandler(this.m_btn_CloseDevice_Click);
            // 
            // m_pic_ShowImage
            // 
            this.m_pic_ShowImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.m_pic_ShowImage.Location = new System.Drawing.Point(4, 4);
            this.m_pic_ShowImage.Margin = new System.Windows.Forms.Padding(4);
            this.m_pic_ShowImage.Name = "m_pic_ShowImage";
            this.m_pic_ShowImage.Size = new System.Drawing.Size(559, 411);
            this.m_pic_ShowImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pic_ShowImage.TabIndex = 25;
            this.m_pic_ShowImage.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.textBox_AD7);
            this.flowLayoutPanel1.Controls.Add(this.textBox_AD6);
            this.flowLayoutPanel1.Controls.Add(this.textBox_AD5);
            this.flowLayoutPanel1.Controls.Add(this.textBox_AD4);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1135, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 701);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(84, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_AD7
            // 
            this.textBox_AD7.Location = new System.Drawing.Point(4, 142);
            this.textBox_AD7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_AD7.Name = "textBox_AD7";
            this.textBox_AD7.Size = new System.Drawing.Size(155, 25);
            this.textBox_AD7.TabIndex = 23;
            // 
            // textBox_AD6
            // 
            this.textBox_AD6.Location = new System.Drawing.Point(4, 175);
            this.textBox_AD6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_AD6.Name = "textBox_AD6";
            this.textBox_AD6.Size = new System.Drawing.Size(155, 25);
            this.textBox_AD6.TabIndex = 22;
            // 
            // textBox_AD5
            // 
            this.textBox_AD5.Location = new System.Drawing.Point(4, 208);
            this.textBox_AD5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_AD5.Name = "textBox_AD5";
            this.textBox_AD5.Size = new System.Drawing.Size(155, 25);
            this.textBox_AD5.TabIndex = 21;
            // 
            // textBox_AD4
            // 
            this.textBox_AD4.Location = new System.Drawing.Point(4, 241);
            this.textBox_AD4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_AD4.Name = "textBox_AD4";
            this.textBox_AD4.Size = new System.Drawing.Size(155, 25);
            this.textBox_AD4.TabIndex = 20;
            // 
            // m_pic2_ShowImage
            // 
            this.m_pic2_ShowImage.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.m_pic2_ShowImage.Location = new System.Drawing.Point(569, 4);
            this.m_pic2_ShowImage.Margin = new System.Windows.Forms.Padding(4);
            this.m_pic2_ShowImage.Name = "m_pic2_ShowImage";
            this.m_pic2_ShowImage.Size = new System.Drawing.Size(559, 411);
            this.m_pic2_ShowImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_pic2_ShowImage.TabIndex = 27;
            this.m_pic2_ShowImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_stitpic_box);
            this.panel1.Controls.Add(this.m_pic_ShowImage);
            this.panel1.Controls.Add(this.m_pic2_ShowImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 701);
            this.panel1.TabIndex = 28;
            // 
            // m_stitpic_box
            // 
            this.m_stitpic_box.Location = new System.Drawing.Point(12, 422);
            this.m_stitpic_box.Name = "m_stitpic_box";
            this.m_stitpic_box.Size = new System.Drawing.Size(1107, 287);
            this.m_stitpic_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_stitpic_box.TabIndex = 28;
            this.m_stitpic_box.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 112);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // GxSingleCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 701);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "GxSingleCam";
            this.Text = "GxSingleCam";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GxSingleCam_FormClosed);
            this.Load += new System.EventHandler(this.GxSingleCam_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pic_ShowImage)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pic2_ShowImage)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_stitpic_box)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btn_StopDevice;
        private System.Windows.Forms.Button m_btn_StartDevice;
        private System.Windows.Forms.Button m_btn_OpenDevice;
        private System.Windows.Forms.Button m_btn_CloseDevice;
        private System.Windows.Forms.PictureBox m_pic_ShowImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox m_pic2_ShowImage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox m_stitpic_box;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_AD7;
        private System.Windows.Forms.TextBox textBox_AD6;
        private System.Windows.Forms.TextBox textBox_AD5;
        private System.Windows.Forms.TextBox textBox_AD4;
        private System.Windows.Forms.Button button3;
    }
}

