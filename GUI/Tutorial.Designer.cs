
namespace WindowsFormsApp1
{
    partial class frmTutorial
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
            this.rtb_Tutorial = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtb_Tutorial
            // 
            this.rtb_Tutorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_Tutorial.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_Tutorial.Location = new System.Drawing.Point(0, 0);
            this.rtb_Tutorial.Name = "rtb_Tutorial";
            this.rtb_Tutorial.ReadOnly = true;
            this.rtb_Tutorial.Size = new System.Drawing.Size(814, 450);
            this.rtb_Tutorial.TabIndex = 0;
            this.rtb_Tutorial.Text = "hướng dẫn";
            // 
            // frmTutorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 450);
            this.Controls.Add(this.rtb_Tutorial);
            this.Name = "frmTutorial";
            this.Text = "Tutorial";
            this.Load += new System.EventHandler(this.frmTutorial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_Tutorial;
    }
}