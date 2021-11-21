
namespace WindowsFormsApp1
{
    partial class frmShowDirectoryList
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Filter = new System.Windows.Forms.TextBox();
            this.txt_FileName = new System.Windows.Forms.TextBox();
            this.btn_Filter = new System.Windows.Forms.Button();
            this.lst_FilePath = new System.Windows.Forms.ListBox();
            this.grb_ChangedAndSave = new System.Windows.Forms.GroupBox();
            this.cbx_Language = new System.Windows.Forms.ComboBox();
            this.cbx_layer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_SaveChange = new System.Windows.Forms.Button();
            this.grb_ChangedAndSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filter folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Tên file";
            // 
            // txt_Filter
            // 
            this.txt_Filter.Location = new System.Drawing.Point(102, 5);
            this.txt_Filter.Name = "txt_Filter";
            this.txt_Filter.Size = new System.Drawing.Size(227, 20);
            this.txt_Filter.TabIndex = 3;
            this.txt_Filter.TextChanged += new System.EventHandler(this.txt_Filter_TextChanged);
            // 
            // txt_FileName
            // 
            this.txt_FileName.Location = new System.Drawing.Point(102, 31);
            this.txt_FileName.Name = "txt_FileName";
            this.txt_FileName.Size = new System.Drawing.Size(227, 20);
            this.txt_FileName.TabIndex = 4;
            // 
            // btn_Filter
            // 
            this.btn_Filter.Location = new System.Drawing.Point(335, 5);
            this.btn_Filter.Name = "btn_Filter";
            this.btn_Filter.Size = new System.Drawing.Size(57, 23);
            this.btn_Filter.TabIndex = 5;
            this.btn_Filter.Text = "filter";
            this.btn_Filter.UseVisualStyleBackColor = true;
            this.btn_Filter.Click += new System.EventHandler(this.btn_Filter_Click);
            // 
            // lst_FilePath
            // 
            this.lst_FilePath.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lst_FilePath.FormattingEnabled = true;
            this.lst_FilePath.Location = new System.Drawing.Point(0, 83);
            this.lst_FilePath.Name = "lst_FilePath";
            this.lst_FilePath.Size = new System.Drawing.Size(404, 160);
            this.lst_FilePath.TabIndex = 6;
            this.lst_FilePath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lst_FilePath_MouseDoubleClick);
            // 
            // grb_ChangedAndSave
            // 
            this.grb_ChangedAndSave.Controls.Add(this.label4);
            this.grb_ChangedAndSave.Controls.Add(this.label3);
            this.grb_ChangedAndSave.Controls.Add(this.cbx_layer);
            this.grb_ChangedAndSave.Controls.Add(this.cbx_Language);
            this.grb_ChangedAndSave.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grb_ChangedAndSave.Location = new System.Drawing.Point(0, 50);
            this.grb_ChangedAndSave.Name = "grb_ChangedAndSave";
            this.grb_ChangedAndSave.Size = new System.Drawing.Size(404, 33);
            this.grb_ChangedAndSave.TabIndex = 7;
            this.grb_ChangedAndSave.TabStop = false;
            this.grb_ChangedAndSave.Text = "changed and save filter";
            // 
            // cbx_Language
            // 
            this.cbx_Language.FormattingEnabled = true;
            this.cbx_Language.Location = new System.Drawing.Point(84, 12);
            this.cbx_Language.Name = "cbx_Language";
            this.cbx_Language.Size = new System.Drawing.Size(106, 21);
            this.cbx_Language.TabIndex = 0;
            // 
            // cbx_layer
            // 
            this.cbx_layer.FormattingEnabled = true;
            this.cbx_layer.Location = new System.Drawing.Point(231, 12);
            this.cbx_layer.Name = "cbx_layer";
            this.cbx_layer.Size = new System.Drawing.Size(121, 21);
            this.cbx_layer.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "language";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(196, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "layer";
            // 
            // btn_SaveChange
            // 
            this.btn_SaveChange.Location = new System.Drawing.Point(335, 33);
            this.btn_SaveChange.Name = "btn_SaveChange";
            this.btn_SaveChange.Size = new System.Drawing.Size(57, 23);
            this.btn_SaveChange.TabIndex = 8;
            this.btn_SaveChange.Text = "Lưu";
            this.btn_SaveChange.UseVisualStyleBackColor = true;
            // 
            // frmShowDirectoryList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 243);
            this.Controls.Add(this.btn_SaveChange);
            this.Controls.Add(this.grb_ChangedAndSave);
            this.Controls.Add(this.lst_FilePath);
            this.Controls.Add(this.btn_Filter);
            this.Controls.Add(this.txt_FileName);
            this.Controls.Add(this.txt_Filter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmShowDirectoryList";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lưu File";
            this.Load += new System.EventHandler(this.DisplayAndInstall_Load);
            this.grb_ChangedAndSave.ResumeLayout(false);
            this.grb_ChangedAndSave.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Filter;
        private System.Windows.Forms.TextBox txt_FileName;
        private System.Windows.Forms.Button btn_Filter;
        private System.Windows.Forms.ListBox lst_FilePath;
        private System.Windows.Forms.GroupBox grb_ChangedAndSave;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbx_layer;
        private System.Windows.Forms.ComboBox cbx_Language;
        private System.Windows.Forms.Button btn_SaveChange;
    }
}