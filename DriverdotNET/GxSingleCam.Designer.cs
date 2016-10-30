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
            this.m_cb_TriggerActivation = new System.Windows.Forms.ComboBox();
            this.m_cb_TriggerSource = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_bSaveBmpImg = new System.Windows.Forms.CheckBox();
            this.m_cb_AutoWhite = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_btn_SoftTriggerCommand = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.m_lbl_WhiteRatio = new System.Windows.Forms.Label();
            this.m_txt_BalanceRatio = new System.Windows.Forms.TextBox();
            this.m_cb_RatioSelector = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_btn_StopDevice = new System.Windows.Forms.Button();
            this.m_btn_StartDevice = new System.Windows.Forms.Button();
            this.m_btn_OpenDevice = new System.Windows.Forms.Button();
            this.m_btn_CloseDevice = new System.Windows.Forms.Button();
            this.m_pic_ShowImage = new System.Windows.Forms.PictureBox();
            this.m_cb_TriggerMode = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_lbl_Gain = new System.Windows.Forms.Label();
            this.m_txt_Gain = new System.Windows.Forms.TextBox();
            this.m_lbl_Shutter = new System.Windows.Forms.Label();
            this.m_txt_Shutter = new System.Windows.Forms.TextBox();
            this.m_timer_UpdateAutoWhite = new System.Windows.Forms.Timer(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.m_pic2_ShowImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pic_ShowImage)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pic2_ShowImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cb_TriggerActivation
            // 
            this.m_cb_TriggerActivation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_TriggerActivation.FormattingEnabled = true;
            this.m_cb_TriggerActivation.Location = new System.Drawing.Point(102, 122);
            this.m_cb_TriggerActivation.Margin = new System.Windows.Forms.Padding(4);
            this.m_cb_TriggerActivation.Name = "m_cb_TriggerActivation";
            this.m_cb_TriggerActivation.Size = new System.Drawing.Size(149, 23);
            this.m_cb_TriggerActivation.TabIndex = 12;
            this.m_cb_TriggerActivation.SelectedIndexChanged += new System.EventHandler(this.m_cb_TriggerActivation_SelectedIndexChanged);
            // 
            // m_cb_TriggerSource
            // 
            this.m_cb_TriggerSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_TriggerSource.FormattingEnabled = true;
            this.m_cb_TriggerSource.Location = new System.Drawing.Point(102, 59);
            this.m_cb_TriggerSource.Margin = new System.Windows.Forms.Padding(4);
            this.m_cb_TriggerSource.Name = "m_cb_TriggerSource";
            this.m_cb_TriggerSource.Size = new System.Drawing.Size(149, 23);
            this.m_cb_TriggerSource.TabIndex = 8;
            this.m_cb_TriggerSource.SelectedIndexChanged += new System.EventHandler(this.m_cb_TriggerSource_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 122);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 15);
            this.label7.TabIndex = 11;
            this.label7.Text = "触发极性";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 9;
            this.label6.Text = "软触发";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 62);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "触发源";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 34);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "触发模式";
            // 
            // m_bSaveBmpImg
            // 
            this.m_bSaveBmpImg.AutoSize = true;
            this.m_bSaveBmpImg.Location = new System.Drawing.Point(23, 25);
            this.m_bSaveBmpImg.Margin = new System.Windows.Forms.Padding(4);
            this.m_bSaveBmpImg.Name = "m_bSaveBmpImg";
            this.m_bSaveBmpImg.Size = new System.Drawing.Size(98, 19);
            this.m_bSaveBmpImg.TabIndex = 23;
            this.m_bSaveBmpImg.Text = "保存BMP图";
            this.m_bSaveBmpImg.UseVisualStyleBackColor = true;
            // 
            // m_cb_AutoWhite
            // 
            this.m_cb_AutoWhite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_AutoWhite.FormattingEnabled = true;
            this.m_cb_AutoWhite.Location = new System.Drawing.Point(102, 22);
            this.m_cb_AutoWhite.Margin = new System.Windows.Forms.Padding(4);
            this.m_cb_AutoWhite.Name = "m_cb_AutoWhite";
            this.m_cb_AutoWhite.Size = new System.Drawing.Size(149, 23);
            this.m_cb_AutoWhite.TabIndex = 18;
            this.m_cb_AutoWhite.SelectedIndexChanged += new System.EventHandler(this.m_cb_AutoWhite_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_bSaveBmpImg);
            this.groupBox1.Location = new System.Drawing.Point(4, 522);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(259, 54);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图像保存";
            // 
            // m_btn_SoftTriggerCommand
            // 
            this.m_btn_SoftTriggerCommand.Location = new System.Drawing.Point(102, 85);
            this.m_btn_SoftTriggerCommand.Margin = new System.Windows.Forms.Padding(4);
            this.m_btn_SoftTriggerCommand.Name = "m_btn_SoftTriggerCommand";
            this.m_btn_SoftTriggerCommand.Size = new System.Drawing.Size(151, 29);
            this.m_btn_SoftTriggerCommand.TabIndex = 10;
            this.m_btn_SoftTriggerCommand.Text = "发送软触发命令";
            this.m_btn_SoftTriggerCommand.UseVisualStyleBackColor = true;
            this.m_btn_SoftTriggerCommand.Click += new System.EventHandler(this.m_btn_SoftTriggerCommand_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.m_lbl_WhiteRatio);
            this.groupBox4.Controls.Add(this.m_txt_BalanceRatio);
            this.groupBox4.Controls.Add(this.m_cb_RatioSelector);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.m_cb_AutoWhite);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(4, 375);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(259, 139);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "白平衡调节";
            // 
            // m_lbl_WhiteRatio
            // 
            this.m_lbl_WhiteRatio.AutoSize = true;
            this.m_lbl_WhiteRatio.Location = new System.Drawing.Point(14, 106);
            this.m_lbl_WhiteRatio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lbl_WhiteRatio.Name = "m_lbl_WhiteRatio";
            this.m_lbl_WhiteRatio.Size = new System.Drawing.Size(82, 15);
            this.m_lbl_WhiteRatio.TabIndex = 21;
            this.m_lbl_WhiteRatio.Text = "白平衡系数";
            // 
            // m_txt_BalanceRatio
            // 
            this.m_txt_BalanceRatio.Location = new System.Drawing.Point(149, 103);
            this.m_txt_BalanceRatio.Margin = new System.Windows.Forms.Padding(4);
            this.m_txt_BalanceRatio.Name = "m_txt_BalanceRatio";
            this.m_txt_BalanceRatio.Size = new System.Drawing.Size(89, 25);
            this.m_txt_BalanceRatio.TabIndex = 22;
            this.m_txt_BalanceRatio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txt_BalanceRatio_KeyPress);
            this.m_txt_BalanceRatio.Leave += new System.EventHandler(this.m_txt_BalanceRatio_Leave);
            // 
            // m_cb_RatioSelector
            // 
            this.m_cb_RatioSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_RatioSelector.FormattingEnabled = true;
            this.m_cb_RatioSelector.Location = new System.Drawing.Point(102, 55);
            this.m_cb_RatioSelector.Margin = new System.Windows.Forms.Padding(4);
            this.m_cb_RatioSelector.Name = "m_cb_RatioSelector";
            this.m_cb_RatioSelector.Size = new System.Drawing.Size(149, 23);
            this.m_cb_RatioSelector.TabIndex = 20;
            this.m_cb_RatioSelector.SelectedIndexChanged += new System.EventHandler(this.m_cb_RatioSelector_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 63);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 15);
            this.label9.TabIndex = 19;
            this.label9.Text = "通道选择";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "自动白平衡";
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
            // m_cb_TriggerMode
            // 
            this.m_cb_TriggerMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cb_TriggerMode.FormattingEnabled = true;
            this.m_cb_TriggerMode.Location = new System.Drawing.Point(102, 31);
            this.m_cb_TriggerMode.Margin = new System.Windows.Forms.Padding(4);
            this.m_cb_TriggerMode.Name = "m_cb_TriggerMode";
            this.m_cb_TriggerMode.Size = new System.Drawing.Size(149, 23);
            this.m_cb_TriggerMode.TabIndex = 6;
            this.m_cb_TriggerMode.SelectedIndexChanged += new System.EventHandler(this.m_cb_TriggerMode_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.m_cb_TriggerActivation);
            this.groupBox5.Controls.Add(this.m_cb_TriggerSource);
            this.groupBox5.Controls.Add(this.m_btn_SoftTriggerCommand);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.m_cb_TriggerMode);
            this.groupBox5.Location = new System.Drawing.Point(4, 113);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(259, 155);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "触发控制";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.m_lbl_Gain);
            this.groupBox3.Controls.Add(this.m_txt_Gain);
            this.groupBox3.Controls.Add(this.m_lbl_Shutter);
            this.groupBox3.Controls.Add(this.m_txt_Shutter);
            this.groupBox3.Location = new System.Drawing.Point(4, 276);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(259, 91);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基本参数设置";
            // 
            // m_lbl_Gain
            // 
            this.m_lbl_Gain.AutoSize = true;
            this.m_lbl_Gain.Location = new System.Drawing.Point(44, 61);
            this.m_lbl_Gain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lbl_Gain.Name = "m_lbl_Gain";
            this.m_lbl_Gain.Size = new System.Drawing.Size(37, 15);
            this.m_lbl_Gain.TabIndex = 15;
            this.m_lbl_Gain.Text = "增益";
            // 
            // m_txt_Gain
            // 
            this.m_txt_Gain.Location = new System.Drawing.Point(130, 58);
            this.m_txt_Gain.Margin = new System.Windows.Forms.Padding(4);
            this.m_txt_Gain.Name = "m_txt_Gain";
            this.m_txt_Gain.Size = new System.Drawing.Size(89, 25);
            this.m_txt_Gain.TabIndex = 16;
            this.m_txt_Gain.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txt_Gain_KeyPress);
            this.m_txt_Gain.Leave += new System.EventHandler(this.m_txt_Gain_Leave);
            // 
            // m_lbl_Shutter
            // 
            this.m_lbl_Shutter.AutoSize = true;
            this.m_lbl_Shutter.Location = new System.Drawing.Point(27, 28);
            this.m_lbl_Shutter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.m_lbl_Shutter.Name = "m_lbl_Shutter";
            this.m_lbl_Shutter.Size = new System.Drawing.Size(67, 15);
            this.m_lbl_Shutter.TabIndex = 13;
            this.m_lbl_Shutter.Text = "曝光时间";
            // 
            // m_txt_Shutter
            // 
            this.m_txt_Shutter.Location = new System.Drawing.Point(130, 26);
            this.m_txt_Shutter.Margin = new System.Windows.Forms.Padding(4);
            this.m_txt_Shutter.Name = "m_txt_Shutter";
            this.m_txt_Shutter.Size = new System.Drawing.Size(88, 25);
            this.m_txt_Shutter.TabIndex = 14;
            this.m_txt_Shutter.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.m_txt_Shutter_KeyPress);
            this.m_txt_Shutter.Leave += new System.EventHandler(this.m_txt_Shutter_Leave);
            // 
            // m_timer_UpdateAutoWhite
            // 
            this.m_timer_UpdateAutoWhite.Enabled = true;
            this.m_timer_UpdateAutoWhite.Interval = 1000;
            this.m_timer_UpdateAutoWhite.Tick += new System.EventHandler(this.m_timer_UpdateAutoWhite_Tick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox5);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.groupBox4);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(1135, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(269, 587);
            this.flowLayoutPanel1.TabIndex = 26;
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
            this.panel1.Controls.Add(this.m_pic_ShowImage);
            this.panel1.Controls.Add(this.m_pic2_ShowImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1135, 587);
            this.panel1.TabIndex = 28;
            // 
            // GxSingleCam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1404, 587);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GxSingleCam_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pic_ShowImage)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pic2_ShowImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cb_TriggerActivation;
        private System.Windows.Forms.ComboBox m_cb_TriggerSource;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox m_bSaveBmpImg;
        private System.Windows.Forms.ComboBox m_cb_AutoWhite;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button m_btn_SoftTriggerCommand;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button m_btn_StopDevice;
        private System.Windows.Forms.Button m_btn_StartDevice;
        private System.Windows.Forms.Button m_btn_OpenDevice;
        private System.Windows.Forms.Button m_btn_CloseDevice;
        private System.Windows.Forms.PictureBox m_pic_ShowImage;
        private System.Windows.Forms.ComboBox m_cb_TriggerMode;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label m_lbl_Gain;
        private System.Windows.Forms.TextBox m_txt_Gain;
        private System.Windows.Forms.Label m_lbl_Shutter;
        private System.Windows.Forms.TextBox m_txt_Shutter;
        private System.Windows.Forms.Label m_lbl_WhiteRatio;
        private System.Windows.Forms.TextBox m_txt_BalanceRatio;
        private System.Windows.Forms.ComboBox m_cb_RatioSelector;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer m_timer_UpdateAutoWhite;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.PictureBox m_pic2_ShowImage;
        private System.Windows.Forms.Panel panel1;
    }
}

