namespace Sample
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.서버선택ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.서버선택ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.모의투자서버ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.실계좌서버ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.로그인ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.계좌ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.계좌리스트ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.거래내역조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.잔고조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.증거금조회ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.주문ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_매도주문 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_매수주문 = new System.Windows.Forms.ToolStripMenuItem();
            this.mun_정정주문 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_취소주문 = new System.Windows.Forms.ToolStripMenuItem();
            this.시세ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.현재가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.옵션전광판ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 26);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(274, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서버선택ToolStripMenuItem,
            this.계좌ToolStripMenuItem,
            this.주문ToolStripMenuItem,
            this.시세ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(274, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 서버선택ToolStripMenuItem
            // 
            this.서버선택ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.서버선택ToolStripMenuItem1,
            this.로그인ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.서버선택ToolStripMenuItem.Name = "서버선택ToolStripMenuItem";
            this.서버선택ToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.서버선택ToolStripMenuItem.Text = "로그인";
            // 
            // 서버선택ToolStripMenuItem1
            // 
            this.서버선택ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.모의투자서버ToolStripMenuItem,
            this.실계좌서버ToolStripMenuItem});
            this.서버선택ToolStripMenuItem1.Name = "서버선택ToolStripMenuItem1";
            this.서버선택ToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.서버선택ToolStripMenuItem1.Text = "서버선택";
            // 
            // 모의투자서버ToolStripMenuItem
            // 
            this.모의투자서버ToolStripMenuItem.Name = "모의투자서버ToolStripMenuItem";
            this.모의투자서버ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.모의투자서버ToolStripMenuItem.Text = "모의투자서버";
            this.모의투자서버ToolStripMenuItem.Click += new System.EventHandler(this.모의투자서버ToolStripMenuItem_Click);
            // 
            // 실계좌서버ToolStripMenuItem
            // 
            this.실계좌서버ToolStripMenuItem.Name = "실계좌서버ToolStripMenuItem";
            this.실계좌서버ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.실계좌서버ToolStripMenuItem.Text = "실계좌서버";
            this.실계좌서버ToolStripMenuItem.Click += new System.EventHandler(this.실계좌서버ToolStripMenuItem_Click);
            // 
            // 로그인ToolStripMenuItem
            // 
            this.로그인ToolStripMenuItem.Enabled = false;
            this.로그인ToolStripMenuItem.Name = "로그인ToolStripMenuItem";
            this.로그인ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.로그인ToolStripMenuItem.Text = "로그인";
            this.로그인ToolStripMenuItem.Click += new System.EventHandler(this.로그인ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // 계좌ToolStripMenuItem
            // 
            this.계좌ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.계좌리스트ToolStripMenuItem,
            this.거래내역조회ToolStripMenuItem,
            this.잔고조회ToolStripMenuItem,
            this.증거금조회ToolStripMenuItem});
            this.계좌ToolStripMenuItem.Name = "계좌ToolStripMenuItem";
            this.계좌ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.계좌ToolStripMenuItem.Text = "계좌";
            // 
            // 계좌리스트ToolStripMenuItem
            // 
            this.계좌리스트ToolStripMenuItem.Enabled = false;
            this.계좌리스트ToolStripMenuItem.Name = "계좌리스트ToolStripMenuItem";
            this.계좌리스트ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.계좌리스트ToolStripMenuItem.Text = "계좌리스트";
            this.계좌리스트ToolStripMenuItem.Click += new System.EventHandler(this.계좌리스트ToolStripMenuItem_Click);
            // 
            // 거래내역조회ToolStripMenuItem
            // 
            this.거래내역조회ToolStripMenuItem.Enabled = false;
            this.거래내역조회ToolStripMenuItem.Name = "거래내역조회ToolStripMenuItem";
            this.거래내역조회ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.거래내역조회ToolStripMenuItem.Text = "거래내역조회";
            this.거래내역조회ToolStripMenuItem.Click += new System.EventHandler(this.거래내역조회ToolStripMenuItem_Click);
            // 
            // 잔고조회ToolStripMenuItem
            // 
            this.잔고조회ToolStripMenuItem.Enabled = false;
            this.잔고조회ToolStripMenuItem.Name = "잔고조회ToolStripMenuItem";
            this.잔고조회ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.잔고조회ToolStripMenuItem.Text = "잔고조회";
            this.잔고조회ToolStripMenuItem.Click += new System.EventHandler(this.잔고조회ToolStripMenuItem_Click);
            // 
            // 증거금조회ToolStripMenuItem
            // 
            this.증거금조회ToolStripMenuItem.Enabled = false;
            this.증거금조회ToolStripMenuItem.Name = "증거금조회ToolStripMenuItem";
            this.증거금조회ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.증거금조회ToolStripMenuItem.Text = "증거금조회";
            this.증거금조회ToolStripMenuItem.Click += new System.EventHandler(this.증거금조회ToolStripMenuItem_Click);
            // 
            // 주문ToolStripMenuItem
            // 
            this.주문ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_매도주문,
            this.mnu_매수주문,
            this.mun_정정주문,
            this.mnu_취소주문});
            this.주문ToolStripMenuItem.Enabled = false;
            this.주문ToolStripMenuItem.Name = "주문ToolStripMenuItem";
            this.주문ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.주문ToolStripMenuItem.Text = "주문";
            // 
            // mnu_매도주문
            // 
            this.mnu_매도주문.Name = "mnu_매도주문";
            this.mnu_매도주문.Size = new System.Drawing.Size(118, 22);
            this.mnu_매도주문.Text = "매도주문";
            this.mnu_매도주문.Click += new System.EventHandler(this.mnu_매도주문_Click);
            // 
            // mnu_매수주문
            // 
            this.mnu_매수주문.Name = "mnu_매수주문";
            this.mnu_매수주문.Size = new System.Drawing.Size(118, 22);
            this.mnu_매수주문.Text = "매수주문";
            this.mnu_매수주문.Click += new System.EventHandler(this.mnu_매도주문_Click);
            // 
            // mun_정정주문
            // 
            this.mun_정정주문.Name = "mun_정정주문";
            this.mun_정정주문.Size = new System.Drawing.Size(118, 22);
            this.mun_정정주문.Text = "정정주문";
            this.mun_정정주문.Click += new System.EventHandler(this.mnu_매도주문_Click);
            // 
            // mnu_취소주문
            // 
            this.mnu_취소주문.Name = "mnu_취소주문";
            this.mnu_취소주문.Size = new System.Drawing.Size(118, 22);
            this.mnu_취소주문.Text = "취소주문";
            this.mnu_취소주문.Click += new System.EventHandler(this.mnu_매도주문_Click);
            // 
            // 시세ToolStripMenuItem
            // 
            this.시세ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.현재가ToolStripMenuItem,
            this.옵션전광판ToolStripMenuItem});
            this.시세ToolStripMenuItem.Enabled = false;
            this.시세ToolStripMenuItem.Name = "시세ToolStripMenuItem";
            this.시세ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.시세ToolStripMenuItem.Text = "시세";
            // 
            // 현재가ToolStripMenuItem
            // 
            this.현재가ToolStripMenuItem.Name = "현재가ToolStripMenuItem";
            this.현재가ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.현재가ToolStripMenuItem.Text = "현재가";
            this.현재가ToolStripMenuItem.Click += new System.EventHandler(this.현재가ToolStripMenuItem_Click);
            // 
            // 옵션전광판ToolStripMenuItem
            // 
            this.옵션전광판ToolStripMenuItem.Name = "옵션전광판ToolStripMenuItem";
            this.옵션전광판ToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.옵션전광판ToolStripMenuItem.Text = "옵션전광판";
            this.옵션전광판ToolStripMenuItem.Click += new System.EventHandler(this.옵션전광판ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(274, 48);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sample";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 서버선택ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 서버선택ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 모의투자서버ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 실계좌서버ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 로그인ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem 계좌ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 계좌리스트ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 거래내역조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 잔고조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 증거금조회ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 주문ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_매도주문;
        private System.Windows.Forms.ToolStripMenuItem mnu_매수주문;
        private System.Windows.Forms.ToolStripMenuItem mun_정정주문;
        private System.Windows.Forms.ToolStripMenuItem mnu_취소주문;
        private System.Windows.Forms.ToolStripMenuItem 시세ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 현재가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 옵션전광판ToolStripMenuItem;
    }
}

