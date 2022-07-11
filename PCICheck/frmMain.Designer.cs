
namespace SATACheck
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
            this.rbMsg = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pcBanner = new System.Windows.Forms.PictureBox();
            this.panDetail = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcBanner)).BeginInit();
            this.panDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbMsg
            // 
            this.rbMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rbMsg.Location = new System.Drawing.Point(0, 0);
            this.rbMsg.Margin = new System.Windows.Forms.Padding(10);
            this.rbMsg.Name = "rbMsg";
            this.rbMsg.Size = new System.Drawing.Size(800, 488);
            this.rbMsg.TabIndex = 0;
            this.rbMsg.Text = "";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pcBanner);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 73);
            this.panel1.TabIndex = 5;
            // 
            // pcBanner
            // 
            this.pcBanner.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pcBanner.BackgroundImage")));
            this.pcBanner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcBanner.Location = new System.Drawing.Point(0, 0);
            this.pcBanner.Name = "pcBanner";
            this.pcBanner.Size = new System.Drawing.Size(800, 73);
            this.pcBanner.TabIndex = 0;
            this.pcBanner.TabStop = false;
            // 
            // panDetail
            // 
            this.panDetail.Controls.Add(this.rbMsg);
            this.panDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panDetail.Location = new System.Drawing.Point(0, 0);
            this.panDetail.Name = "panDetail";
            this.panDetail.Size = new System.Drawing.Size(800, 488);
            this.panDetail.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 488);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panDetail);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "PCICheck";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pcBanner)).EndInit();
            this.panDetail.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rbMsg;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pcBanner;
        private System.Windows.Forms.Panel panDetail;
    }
}

