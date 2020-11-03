namespace Sample
{
    partial class TradeHistory
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.cmb_AccNum = new System.Windows.Forms.ComboBox();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.lbl_AccName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtn_전체 = new System.Windows.Forms.RadioButton();
            this.rbtn_체결 = new System.Windows.Forms.RadioButton();
            this.rbtn_미체결 = new System.Windows.Forms.RadioButton();
            this.btn_조회 = new System.Windows.Forms.Button();
            this.btn_실시간 = new System.Windows.Forms.Button();
            this.btn_조회실시간 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "계좌번호";
            // 
            // cmb_AccNum
            // 
            this.cmb_AccNum.BackColor = System.Drawing.Color.Black;
            this.cmb_AccNum.ForeColor = System.Drawing.Color.White;
            this.cmb_AccNum.FormattingEnabled = true;
            this.cmb_AccNum.Location = new System.Drawing.Point(61, 4);
            this.cmb_AccNum.Name = "cmb_AccNum";
            this.cmb_AccNum.Size = new System.Drawing.Size(115, 20);
            this.cmb_AccNum.TabIndex = 1;
            this.cmb_AccNum.SelectedIndexChanged += new System.EventHandler(this.cmb_AccNum_SelectedIndexChanged);
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(311, 2);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(100, 21);
            this.txt_Pass.TabIndex = 2;
            this.txt_Pass.UseSystemPasswordChar = true;
            // 
            // lbl_AccName
            // 
            this.lbl_AccName.AutoSize = true;
            this.lbl_AccName.Location = new System.Drawing.Point(176, 7);
            this.lbl_AccName.Name = "lbl_AccName";
            this.lbl_AccName.Size = new System.Drawing.Size(61, 12);
            this.lbl_AccName.TabIndex = 3;
            this.lbl_AccName.Text = "AccName";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "비밀번호";
            // 
            // rbtn_전체
            // 
            this.rbtn_전체.AutoSize = true;
            this.rbtn_전체.Checked = true;
            this.rbtn_전체.Location = new System.Drawing.Point(10, 39);
            this.rbtn_전체.Name = "rbtn_전체";
            this.rbtn_전체.Size = new System.Drawing.Size(47, 16);
            this.rbtn_전체.TabIndex = 5;
            this.rbtn_전체.TabStop = true;
            this.rbtn_전체.Text = "전체";
            this.rbtn_전체.UseVisualStyleBackColor = true;
            this.rbtn_전체.CheckedChanged += new System.EventHandler(this.rbtn_전체_CheckedChanged);
            // 
            // rbtn_체결
            // 
            this.rbtn_체결.AutoSize = true;
            this.rbtn_체결.Location = new System.Drawing.Point(57, 39);
            this.rbtn_체결.Name = "rbtn_체결";
            this.rbtn_체결.Size = new System.Drawing.Size(47, 16);
            this.rbtn_체결.TabIndex = 6;
            this.rbtn_체결.Text = "체결";
            this.rbtn_체결.UseVisualStyleBackColor = true;
            this.rbtn_체결.CheckedChanged += new System.EventHandler(this.rbtn_전체_CheckedChanged);
            // 
            // rbtn_미체결
            // 
            this.rbtn_미체결.AutoSize = true;
            this.rbtn_미체결.Location = new System.Drawing.Point(104, 39);
            this.rbtn_미체결.Name = "rbtn_미체결";
            this.rbtn_미체결.Size = new System.Drawing.Size(59, 16);
            this.rbtn_미체결.TabIndex = 7;
            this.rbtn_미체결.Text = "미체결";
            this.rbtn_미체결.UseVisualStyleBackColor = true;
            this.rbtn_미체결.CheckedChanged += new System.EventHandler(this.rbtn_전체_CheckedChanged);
            // 
            // btn_조회
            // 
            this.btn_조회.Location = new System.Drawing.Point(165, 36);
            this.btn_조회.Name = "btn_조회";
            this.btn_조회.Size = new System.Drawing.Size(80, 23);
            this.btn_조회.TabIndex = 8;
            this.btn_조회.Text = "조회";
            this.btn_조회.UseVisualStyleBackColor = true;
            this.btn_조회.Click += new System.EventHandler(this.btn_조회_Click);
            // 
            // btn_실시간
            // 
            this.btn_실시간.Location = new System.Drawing.Point(248, 36);
            this.btn_실시간.Name = "btn_실시간";
            this.btn_실시간.Size = new System.Drawing.Size(80, 23);
            this.btn_실시간.TabIndex = 9;
            this.btn_실시간.Text = "실시간";
            this.btn_실시간.UseVisualStyleBackColor = true;
            this.btn_실시간.Click += new System.EventHandler(this.btn_실시간_Click);
            // 
            // btn_조회실시간
            // 
            this.btn_조회실시간.Location = new System.Drawing.Point(331, 36);
            this.btn_조회실시간.Name = "btn_조회실시간";
            this.btn_조회실시간.Size = new System.Drawing.Size(80, 23);
            this.btn_조회실시간.TabIndex = 10;
            this.btn_조회실시간.Text = "조회/실시간";
            this.btn_조회실시간.UseVisualStyleBackColor = true;
            this.btn_조회실시간.Click += new System.EventHandler(this.btn_조회실시간_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.label10, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 74);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 23);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(694, 1);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 21);
            this.label10.TabIndex = 13;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(595, 1);
            this.label9.Margin = new System.Windows.Forms.Padding(0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 21);
            this.label9.TabIndex = 13;
            this.label9.Text = "0";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(496, 1);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 21);
            this.label8.TabIndex = 13;
            this.label8.Text = "체결수량";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(397, 1);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 21);
            this.label7.TabIndex = 13;
            this.label7.Text = "옵션주문";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(298, 1);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(199, 1);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "0";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(100, 1);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 13;
            this.label4.Text = "체결수량";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(1, 1);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 21);
            this.label2.TabIndex = 12;
            this.label2.Text = "선물주문";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(10, 103);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(796, 276);
            this.dataGridView1.TabIndex = 12;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 388);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(818, 22);
            this.statusStrip1.TabIndex = 26;
            this.statusStrip1.Tag = "메시지:";
            this.statusStrip1.Text = "Msg:";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(803, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // TradeHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 410);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.btn_조회실시간);
            this.Controls.Add(this.btn_실시간);
            this.Controls.Add(this.btn_조회);
            this.Controls.Add(this.rbtn_미체결);
            this.Controls.Add(this.rbtn_체결);
            this.Controls.Add(this.rbtn_전체);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_AccName);
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.cmb_AccNum);
            this.Controls.Add(this.label1);
            this.Name = "TradeHistory";
            this.Text = "거래내역조회";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TradeHistory_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_AccName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtn_전체;
        private System.Windows.Forms.RadioButton rbtn_체결;
        private System.Windows.Forms.RadioButton rbtn_미체결;
        private System.Windows.Forms.Button btn_조회;
        private System.Windows.Forms.Button btn_실시간;
        private System.Windows.Forms.Button btn_조회실시간;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmb_AccNum;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txt_Pass;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}