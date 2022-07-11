namespace MemoryTest
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.panTop = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panDetail = new System.Windows.Forms.Panel();
            this.rbMsg = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcBanner = new System.Windows.Forms.PictureBox();
            this.panTop.SuspendLayout();
            this.panDetail.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // panTop
            // 
            this.panTop.Controls.Add(this.textBox1);
            this.panTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTop.Location = new System.Drawing.Point(0, 0);
            this.panTop.Name = "panTop";
            this.panTop.Size = new System.Drawing.Size(624, 36);
            this.panTop.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("新細明體", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(624, 36);
            this.textBox1.TabIndex = 0;
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.rbMsg);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetail.Location = new System.Drawing.Point(0, 36);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(624, 405);
            this.panDetail.TabIndex = 1;
            // 
            // rbMsg
            // 
            this.rbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbMsg.Location = new System.Drawing.Point(0, 0);
            this.rbMsg.Name = "rbMsg";
            this.rbMsg.Size = new System.Drawing.Size(624, 405);
            this.rbMsg.TabIndex = 0;
            this.rbMsg.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pcBanner);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 374);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(624, 67);
            this.panel1.TabIndex = 2;
            // 
            // pcBanner
            // 
            this.pcBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcBanner.BackgroundImage")));
            this.pcBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcBanner.Location = new System.Drawing.Point(0, 0);
            this.pcBanner.Name = "pcBanner";
            this.pcBanner.Size = new System.Drawing.Size(624, 67);
            this.pcBanner.TabIndex = 0;
            this.pcBanner.TabStop = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panDetail);
            this.Controls.Add(this.panTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "MemoryTest";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panTop.ResumeLayout(false);
            this.panTop.PerformLayout();
            this.panDetail.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBanner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panTop;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panDetail;
        private System.Windows.Forms.RichTextBox rbMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcBanner;
    }
}

