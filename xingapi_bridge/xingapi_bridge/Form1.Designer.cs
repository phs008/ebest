namespace xingapi_bridge
{
    partial class Form1
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.login_text_btn = new System.Windows.Forms.Button();
            this.console = new System.Windows.Forms.TextBox();
            this.buy_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // login_text_btn
            // 
            this.login_text_btn.Location = new System.Drawing.Point(24, 25);
            this.login_text_btn.Name = "login_text_btn";
            this.login_text_btn.Size = new System.Drawing.Size(115, 37);
            this.login_text_btn.TabIndex = 0;
            this.login_text_btn.Text = "로그인 테스트";
            this.login_text_btn.UseVisualStyleBackColor = true;
            this.login_text_btn.Click += new System.EventHandler(this.login_text_btn_Click);
            // 
            // console
            // 
            this.console.Location = new System.Drawing.Point(-2, 319);
            this.console.Multiline = true;
            this.console.Name = "console";
            this.console.ReadOnly = true;
            this.console.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.console.Size = new System.Drawing.Size(802, 127);
            this.console.TabIndex = 1;
            // 
            // buy_btn
            // 
            this.buy_btn.Location = new System.Drawing.Point(226, 25);
            this.buy_btn.Name = "buy_btn";
            this.buy_btn.Size = new System.Drawing.Size(106, 37);
            this.buy_btn.TabIndex = 2;
            this.buy_btn.Text = "가짜주문버튼";
            this.buy_btn.UseVisualStyleBackColor = true;
            this.buy_btn.Click += new System.EventHandler(this.buy_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buy_btn);
            this.Controls.Add(this.console);
            this.Controls.Add(this.login_text_btn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button login_text_btn;
        private System.Windows.Forms.TextBox console;
        private System.Windows.Forms.Button buy_btn;
    }
}

