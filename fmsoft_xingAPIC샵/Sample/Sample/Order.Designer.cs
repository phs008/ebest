namespace Sample
{
    partial class Order
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_매도 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_매도종목 = new System.Windows.Forms.Button();
            this.num_매도가격 = new System.Windows.Forms.NumericUpDown();
            this.num_매도수량 = new System.Windows.Forms.NumericUpDown();
            this.btn_매도주문 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.txt_매도종목 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tab_매수 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_매수종목 = new System.Windows.Forms.Button();
            this.num_매수가격 = new System.Windows.Forms.NumericUpDown();
            this.num_매수수량 = new System.Windows.Forms.NumericUpDown();
            this.btn_매수주문 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_매수종목 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tab_정정 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_정정주문번호 = new System.Windows.Forms.Button();
            this.num_정정가격 = new System.Windows.Forms.NumericUpDown();
            this.num_정정수량 = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_정정종목 = new System.Windows.Forms.Label();
            this.btn_정정주문 = new System.Windows.Forms.Button();
            this.txt_정정주문번호 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tab_취소 = new System.Windows.Forms.TabPage();
            this.btn_취소주문번호 = new System.Windows.Forms.Button();
            this.num_취소수량 = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_취소종목 = new System.Windows.Forms.Label();
            this.btn_취소주문 = new System.Windows.Forms.Button();
            this.txt_취소주문번호 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_AccName = new System.Windows.Forms.Label();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.cmb_AccNum = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1.SuspendLayout();
            this.tab_매도.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_매도가격)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_매도수량)).BeginInit();
            this.tab_매수.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_매수가격)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_매수수량)).BeginInit();
            this.tab_정정.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_정정가격)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_정정수량)).BeginInit();
            this.tab_취소.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_취소수량)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tab_매도);
            this.tabControl1.Controls.Add(this.tab_매수);
            this.tabControl1.Controls.Add(this.tab_정정);
            this.tabControl1.Controls.Add(this.tab_취소);
            this.tabControl1.Location = new System.Drawing.Point(16, 53);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(204, 175);
            this.tabControl1.TabIndex = 37;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tab_매도
            // 
            this.tab_매도.BackColor = System.Drawing.Color.LightSkyBlue;
            this.tab_매도.Controls.Add(this.button3);
            this.tab_매도.Controls.Add(this.btn_매도종목);
            this.tab_매도.Controls.Add(this.num_매도가격);
            this.tab_매도.Controls.Add(this.num_매도수량);
            this.tab_매도.Controls.Add(this.btn_매도주문);
            this.tab_매도.Controls.Add(this.label17);
            this.tab_매도.Controls.Add(this.label18);
            this.tab_매도.Controls.Add(this.txt_매도종목);
            this.tab_매도.Controls.Add(this.label19);
            this.tab_매도.Location = new System.Drawing.Point(4, 22);
            this.tab_매도.Name = "tab_매도";
            this.tab_매도.Size = new System.Drawing.Size(196, 149);
            this.tab_매도.TabIndex = 0;
            this.tab_매도.Text = "매도";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(122, 61);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(22, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "호";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_매도종목
            // 
            this.btn_매도종목.Location = new System.Drawing.Point(162, 6);
            this.btn_매도종목.Name = "btn_매도종목";
            this.btn_매도종목.Size = new System.Drawing.Size(22, 23);
            this.btn_매도종목.TabIndex = 16;
            this.btn_매도종목.Text = "▦";
            this.btn_매도종목.UseVisualStyleBackColor = true;
            this.btn_매도종목.Click += new System.EventHandler(this.btn_매도종목_Click);
            // 
            // num_매도가격
            // 
            this.num_매도가격.DecimalPlaces = 2;
            this.num_매도가격.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_매도가격.Location = new System.Drawing.Point(54, 62);
            this.num_매도가격.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.num_매도가격.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_매도가격.Name = "num_매도가격";
            this.num_매도가격.Size = new System.Drawing.Size(62, 21);
            this.num_매도가격.TabIndex = 15;
            this.num_매도가격.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_매도가격.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_매도가격.ValueChanged += new System.EventHandler(this.num_매도가격_ValueChanged);
            // 
            // num_매도수량
            // 
            this.num_매도수량.Location = new System.Drawing.Point(56, 35);
            this.num_매도수량.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_매도수량.Name = "num_매도수량";
            this.num_매도수량.Size = new System.Drawing.Size(41, 21);
            this.num_매도수량.TabIndex = 14;
            this.num_매도수량.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_매도수량.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_매도주문
            // 
            this.btn_매도주문.Location = new System.Drawing.Point(56, 101);
            this.btn_매도주문.Name = "btn_매도주문";
            this.btn_매도주문.Size = new System.Drawing.Size(75, 23);
            this.btn_매도주문.TabIndex = 13;
            this.btn_매도주문.Text = "매도주문";
            this.btn_매도주문.UseVisualStyleBackColor = true;
            this.btn_매도주문.Click += new System.EventHandler(this.btn_매도주문_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(19, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(29, 12);
            this.label17.TabIndex = 11;
            this.label17.Text = "가격";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(19, 37);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(29, 12);
            this.label18.TabIndex = 9;
            this.label18.Text = "수량";
            // 
            // txt_매도종목
            // 
            this.txt_매도종목.Location = new System.Drawing.Point(56, 8);
            this.txt_매도종목.Name = "txt_매도종목";
            this.txt_매도종목.Size = new System.Drawing.Size(100, 21);
            this.txt_매도종목.TabIndex = 8;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(19, 14);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(29, 12);
            this.label19.TabIndex = 7;
            this.label19.Text = "종목";
            // 
            // tab_매수
            // 
            this.tab_매수.BackColor = System.Drawing.Color.LightSalmon;
            this.tab_매수.Controls.Add(this.button2);
            this.tab_매수.Controls.Add(this.btn_매수종목);
            this.tab_매수.Controls.Add(this.num_매수가격);
            this.tab_매수.Controls.Add(this.num_매수수량);
            this.tab_매수.Controls.Add(this.btn_매수주문);
            this.tab_매수.Controls.Add(this.label7);
            this.tab_매수.Controls.Add(this.label11);
            this.tab_매수.Controls.Add(this.txt_매수종목);
            this.tab_매수.Controls.Add(this.label12);
            this.tab_매수.Location = new System.Drawing.Point(4, 22);
            this.tab_매수.Name = "tab_매수";
            this.tab_매수.Size = new System.Drawing.Size(196, 149);
            this.tab_매수.TabIndex = 1;
            this.tab_매수.Text = "매수";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(22, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "호";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_매수종목
            // 
            this.btn_매수종목.Location = new System.Drawing.Point(162, 6);
            this.btn_매수종목.Name = "btn_매수종목";
            this.btn_매수종목.Size = new System.Drawing.Size(22, 23);
            this.btn_매수종목.TabIndex = 23;
            this.btn_매수종목.Text = "▦";
            this.btn_매수종목.UseVisualStyleBackColor = true;
            this.btn_매수종목.Click += new System.EventHandler(this.btn_매수종목_Click);
            // 
            // num_매수가격
            // 
            this.num_매수가격.DecimalPlaces = 2;
            this.num_매수가격.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_매수가격.Location = new System.Drawing.Point(54, 62);
            this.num_매수가격.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.num_매수가격.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_매수가격.Name = "num_매수가격";
            this.num_매수가격.Size = new System.Drawing.Size(62, 21);
            this.num_매수가격.TabIndex = 22;
            this.num_매수가격.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_매수가격.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_매수가격.ValueChanged += new System.EventHandler(this.num_매도가격_ValueChanged);
            // 
            // num_매수수량
            // 
            this.num_매수수량.Location = new System.Drawing.Point(56, 35);
            this.num_매수수량.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_매수수량.Name = "num_매수수량";
            this.num_매수수량.Size = new System.Drawing.Size(41, 21);
            this.num_매수수량.TabIndex = 21;
            this.num_매수수량.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_매수수량.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btn_매수주문
            // 
            this.btn_매수주문.Location = new System.Drawing.Point(56, 101);
            this.btn_매수주문.Name = "btn_매수주문";
            this.btn_매수주문.Size = new System.Drawing.Size(75, 23);
            this.btn_매수주문.TabIndex = 20;
            this.btn_매수주문.Text = "매수주문";
            this.btn_매수주문.UseVisualStyleBackColor = true;
            this.btn_매수주문.Click += new System.EventHandler(this.btn_매수주문_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 19;
            this.label7.Text = "가격";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "수량";
            // 
            // txt_매수종목
            // 
            this.txt_매수종목.Location = new System.Drawing.Point(56, 8);
            this.txt_매수종목.Name = "txt_매수종목";
            this.txt_매수종목.Size = new System.Drawing.Size(100, 21);
            this.txt_매수종목.TabIndex = 17;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 14);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 12);
            this.label12.TabIndex = 16;
            this.label12.Text = "종목";
            // 
            // tab_정정
            // 
            this.tab_정정.BackColor = System.Drawing.Color.YellowGreen;
            this.tab_정정.Controls.Add(this.button1);
            this.tab_정정.Controls.Add(this.btn_정정주문번호);
            this.tab_정정.Controls.Add(this.num_정정가격);
            this.tab_정정.Controls.Add(this.num_정정수량);
            this.tab_정정.Controls.Add(this.label13);
            this.tab_정정.Controls.Add(this.label14);
            this.tab_정정.Controls.Add(this.lbl_정정종목);
            this.tab_정정.Controls.Add(this.btn_정정주문);
            this.tab_정정.Controls.Add(this.txt_정정주문번호);
            this.tab_정정.Controls.Add(this.label16);
            this.tab_정정.Location = new System.Drawing.Point(4, 22);
            this.tab_정정.Name = "tab_정정";
            this.tab_정정.Size = new System.Drawing.Size(196, 149);
            this.tab_정정.TabIndex = 2;
            this.tab_정정.Text = "정정";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(132, 89);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "호";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_정정주문번호
            // 
            this.btn_정정주문번호.Location = new System.Drawing.Point(167, 8);
            this.btn_정정주문번호.Name = "btn_정정주문번호";
            this.btn_정정주문번호.Size = new System.Drawing.Size(22, 23);
            this.btn_정정주문번호.TabIndex = 20;
            this.btn_정정주문번호.Text = "▦";
            this.btn_정정주문번호.UseVisualStyleBackColor = true;
            this.btn_정정주문번호.Click += new System.EventHandler(this.btn_정정주문번호_Click);
            // 
            // num_정정가격
            // 
            this.num_정정가격.DecimalPlaces = 2;
            this.num_정정가격.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_정정가격.Location = new System.Drawing.Point(65, 90);
            this.num_정정가격.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            131072});
            this.num_정정가격.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_정정가격.Name = "num_정정가격";
            this.num_정정가격.Size = new System.Drawing.Size(62, 21);
            this.num_정정가격.TabIndex = 19;
            this.num_정정가격.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_정정가격.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.num_정정가격.ValueChanged += new System.EventHandler(this.num_매도가격_ValueChanged);
            // 
            // num_정정수량
            // 
            this.num_정정수량.Location = new System.Drawing.Point(67, 63);
            this.num_정정수량.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_정정수량.Name = "num_정정수량";
            this.num_정정수량.Size = new System.Drawing.Size(41, 21);
            this.num_정정수량.TabIndex = 18;
            this.num_정정수량.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_정정수량.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(30, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "가격";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(32, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(29, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "수량";
            // 
            // lbl_정정종목
            // 
            this.lbl_정정종목.AutoSize = true;
            this.lbl_정정종목.Location = new System.Drawing.Point(59, 38);
            this.lbl_정정종목.Name = "lbl_정정종목";
            this.lbl_정정종목.Size = new System.Drawing.Size(0, 12);
            this.lbl_정정종목.TabIndex = 14;
            // 
            // btn_정정주문
            // 
            this.btn_정정주문.Location = new System.Drawing.Point(56, 117);
            this.btn_정정주문.Name = "btn_정정주문";
            this.btn_정정주문.Size = new System.Drawing.Size(75, 23);
            this.btn_정정주문.TabIndex = 13;
            this.btn_정정주문.Text = "정정주문";
            this.btn_정정주문.UseVisualStyleBackColor = true;
            this.btn_정정주문.Click += new System.EventHandler(this.btn_정정주문_Click);
            // 
            // txt_정정주문번호
            // 
            this.txt_정정주문번호.Location = new System.Drawing.Point(61, 10);
            this.txt_정정주문번호.Name = "txt_정정주문번호";
            this.txt_정정주문번호.Size = new System.Drawing.Size(100, 21);
            this.txt_정정주문번호.TabIndex = 8;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 13);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 12);
            this.label16.TabIndex = 7;
            this.label16.Text = "주문번호";
            // 
            // tab_취소
            // 
            this.tab_취소.BackColor = System.Drawing.Color.Gray;
            this.tab_취소.Controls.Add(this.btn_취소주문번호);
            this.tab_취소.Controls.Add(this.num_취소수량);
            this.tab_취소.Controls.Add(this.label10);
            this.tab_취소.Controls.Add(this.lbl_취소종목);
            this.tab_취소.Controls.Add(this.btn_취소주문);
            this.tab_취소.Controls.Add(this.txt_취소주문번호);
            this.tab_취소.Controls.Add(this.label8);
            this.tab_취소.Location = new System.Drawing.Point(4, 22);
            this.tab_취소.Name = "tab_취소";
            this.tab_취소.Size = new System.Drawing.Size(196, 149);
            this.tab_취소.TabIndex = 3;
            this.tab_취소.Text = "취소";
            // 
            // btn_취소주문번호
            // 
            this.btn_취소주문번호.Location = new System.Drawing.Point(166, 10);
            this.btn_취소주문번호.Name = "btn_취소주문번호";
            this.btn_취소주문번호.Size = new System.Drawing.Size(22, 23);
            this.btn_취소주문번호.TabIndex = 23;
            this.btn_취소주문번호.Text = "▦";
            this.btn_취소주문번호.UseVisualStyleBackColor = true;
            this.btn_취소주문번호.Click += new System.EventHandler(this.btn_취소주문번호_Click);
            // 
            // num_취소수량
            // 
            this.num_취소수량.Location = new System.Drawing.Point(56, 72);
            this.num_취소수량.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.num_취소수량.Name = "num_취소수량";
            this.num_취소수량.Size = new System.Drawing.Size(41, 21);
            this.num_취소수량.TabIndex = 22;
            this.num_취소수량.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.num_취소수량.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 74);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "수량";
            // 
            // lbl_취소종목
            // 
            this.lbl_취소종목.AutoSize = true;
            this.lbl_취소종목.Location = new System.Drawing.Point(56, 44);
            this.lbl_취소종목.Name = "lbl_취소종목";
            this.lbl_취소종목.Size = new System.Drawing.Size(0, 12);
            this.lbl_취소종목.TabIndex = 20;
            // 
            // btn_취소주문
            // 
            this.btn_취소주문.Location = new System.Drawing.Point(56, 108);
            this.btn_취소주문.Name = "btn_취소주문";
            this.btn_취소주문.Size = new System.Drawing.Size(75, 23);
            this.btn_취소주문.TabIndex = 6;
            this.btn_취소주문.Text = "취소주문";
            this.btn_취소주문.UseVisualStyleBackColor = true;
            this.btn_취소주문.Click += new System.EventHandler(this.btn_취소주문_Click);
            // 
            // txt_취소주문번호
            // 
            this.txt_취소주문번호.Location = new System.Drawing.Point(60, 10);
            this.txt_취소주문번호.Name = "txt_취소주문번호";
            this.txt_취소주문번호.Size = new System.Drawing.Size(100, 21);
            this.txt_취소주문번호.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "주문번호";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 42;
            this.label3.Text = "비밀번호";
            // 
            // lbl_AccName
            // 
            this.lbl_AccName.AutoSize = true;
            this.lbl_AccName.Location = new System.Drawing.Point(174, 6);
            this.lbl_AccName.Name = "lbl_AccName";
            this.lbl_AccName.Size = new System.Drawing.Size(61, 12);
            this.lbl_AccName.TabIndex = 41;
            this.lbl_AccName.Text = "AccName";
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(59, 26);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(100, 21);
            this.txt_Pass.TabIndex = 40;
            this.txt_Pass.UseSystemPasswordChar = true;
            // 
            // cmb_AccNum
            // 
            this.cmb_AccNum.BackColor = System.Drawing.Color.Black;
            this.cmb_AccNum.ForeColor = System.Drawing.Color.White;
            this.cmb_AccNum.FormattingEnabled = true;
            this.cmb_AccNum.Location = new System.Drawing.Point(59, 3);
            this.cmb_AccNum.Name = "cmb_AccNum";
            this.cmb_AccNum.Size = new System.Drawing.Size(115, 20);
            this.cmb_AccNum.TabIndex = 39;
            this.cmb_AccNum.SelectedIndexChanged += new System.EventHandler(this.cmb_AccNum_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 38;
            this.label1.Text = "계좌번호";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 236);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(237, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Tag = "메시지:";
            this.statusStrip1.Text = "Msg:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(222, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(237, 258);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_AccName);
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.cmb_AccNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "Order";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "주문창";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Order_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tab_매도.ResumeLayout(false);
            this.tab_매도.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_매도가격)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_매도수량)).EndInit();
            this.tab_매수.ResumeLayout(false);
            this.tab_매수.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_매수가격)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_매수수량)).EndInit();
            this.tab_정정.ResumeLayout(false);
            this.tab_정정.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_정정가격)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_정정수량)).EndInit();
            this.tab_취소.ResumeLayout(false);
            this.tab_취소.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_취소수량)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_매도;
        private System.Windows.Forms.NumericUpDown num_매도가격;
        private System.Windows.Forms.NumericUpDown num_매도수량;
        private System.Windows.Forms.Button btn_매도주문;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txt_매도종목;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tab_매수;
        private System.Windows.Forms.NumericUpDown num_매수가격;
        private System.Windows.Forms.NumericUpDown num_매수수량;
        private System.Windows.Forms.Button btn_매수주문;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_매수종목;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabPage tab_정정;
        private System.Windows.Forms.NumericUpDown num_정정가격;
        private System.Windows.Forms.NumericUpDown num_정정수량;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_정정종목;
        private System.Windows.Forms.Button btn_정정주문;
        private System.Windows.Forms.TextBox txt_정정주문번호;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TabPage tab_취소;
        private System.Windows.Forms.NumericUpDown num_취소수량;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbl_취소종목;
        private System.Windows.Forms.Button btn_취소주문;
        private System.Windows.Forms.TextBox txt_취소주문번호;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_AccName;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.ComboBox cmb_AccNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_매도종목;
        private System.Windows.Forms.Button btn_매수종목;
        private System.Windows.Forms.Button btn_정정주문번호;
        private System.Windows.Forms.Button btn_취소주문번호;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}