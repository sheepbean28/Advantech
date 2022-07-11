
namespace SATACheck
{
    partial class SATACheck
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SATACheck));
            this.lblHDDChanels = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Output_result = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SN = new System.Windows.Forms.Label();
            this.SNinputTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHDDChanels
            // 
            this.lblHDDChanels.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHDDChanels.Location = new System.Drawing.Point(10, 97);
            this.lblHDDChanels.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblHDDChanels.Name = "lblHDDChanels";
            this.lblHDDChanels.ReadOnly = true;
            this.lblHDDChanels.Size = new System.Drawing.Size(680, 276);
            this.lblHDDChanels.TabIndex = 3;
            this.lblHDDChanels.Text = "";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(510, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(180, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Output_result
            // 
            this.Output_result.AutoSize = true;
            this.Output_result.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Output_result.Location = new System.Drawing.Point(9, 21);
            this.Output_result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Output_result.Name = "Output_result";
            this.Output_result.Size = new System.Drawing.Size(98, 45);
            this.Output_result.TabIndex = 11;
            this.Output_result.Text = "　　";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Output_result);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(117, 76);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total_Result";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(648, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Ver A3";
            // 
            // SN
            // 
            this.SN.AutoSize = true;
            this.SN.Location = new System.Drawing.Point(135, 13);
            this.SN.Name = "SN";
            this.SN.Size = new System.Drawing.Size(53, 15);
            this.SN.TabIndex = 21;
            this.SN.Text = "SN InPut";
            // 
            // SNinputTextBox
            // 
            this.SNinputTextBox.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SNinputTextBox.Location = new System.Drawing.Point(141, 31);
            this.SNinputTextBox.MaxLength = 10;
            this.SNinputTextBox.Name = "SNinputTextBox";
            this.SNinputTextBox.Size = new System.Drawing.Size(211, 53);
            this.SNinputTextBox.TabIndex = 22;
            this.SNinputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SNinputTextBox_keydown);
            // 
            // SATACheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(702, 383);
            this.Controls.Add(this.SNinputTextBox);
            this.Controls.Add(this.SN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblHDDChanels);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SATACheck";
            this.Text = "SATACheck";
            this.Load += new System.EventHandler(this.SATACheck_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox lblHDDChanels;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Output_result;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label SN;
        private System.Windows.Forms.TextBox SNinputTextBox;
    }
}

