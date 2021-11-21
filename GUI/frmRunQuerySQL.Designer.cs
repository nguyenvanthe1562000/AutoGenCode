
namespace WindowsFormsApp1
{
    partial class frmRunQuerySQL
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRunQuerySQL));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ẩnResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.miChangeColors = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_hideResult = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.fctb = new FastColoredTextBoxNS.FastColoredTextBox();
            this.split_main = new System.Windows.Forms.SplitContainer();
            this.tabCtrl_Result = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).BeginInit();
            this.split_main.Panel1.SuspendLayout();
            this.split_main.Panel2.SuspendLayout();
            this.split_main.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.ẩnResultToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(122, 70);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.runToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.runToolStripMenuItem.Text = "Run";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // ẩnResultToolStripMenuItem
            // 
            this.ẩnResultToolStripMenuItem.Name = "ẩnResultToolStripMenuItem";
            this.ẩnResultToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.ẩnResultToolStripMenuItem.Text = "Ẩn result";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miChangeColors,
            this.mnu_hideResult});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(776, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // miChangeColors
            // 
            this.miChangeColors.Enabled = false;
            this.miChangeColors.Name = "miChangeColors";
            this.miChangeColors.Size = new System.Drawing.Size(87, 20);
            this.miChangeColors.Text = "Đổi màu chữ";
            this.miChangeColors.Click += new System.EventHandler(this.miChangeColors_Click);
            // 
            // mnu_hideResult
            // 
            this.mnu_hideResult.Name = "mnu_hideResult";
            this.mnu_hideResult.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnu_hideResult.Size = new System.Drawing.Size(66, 20);
            this.mnu_hideResult.Text = "Ẩn result";
            this.mnu_hideResult.Click += new System.EventHandler(this.mnu_hideResult_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "script_16x16.png");
            this.imageList1.Images.SetKeyName(1, "app_16x16.png");
            this.imageList1.Images.SetKeyName(2, "1302166543_virtualbox.png");
            this.imageList1.Images.SetKeyName(3, "icons8_table.ico");
            // 
            // fctb
            // 
            this.fctb.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fctb.AutoIndentCharsPatterns = "";
            this.fctb.AutoScrollMinSize = new System.Drawing.Size(0, 14);
            this.fctb.BackBrush = null;
            this.fctb.CharHeight = 14;
            this.fctb.CharWidth = 8;
            this.fctb.CommentPrefix = "--";
            this.fctb.ContextMenuStrip = this.contextMenuStrip1;
            this.fctb.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fctb.DefaultMarkerSize = 8;
            this.fctb.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fctb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fctb.Font = new System.Drawing.Font("Courier New", 9.75F);
            this.fctb.IsReplaceMode = false;
            this.fctb.Language = FastColoredTextBoxNS.Language.SQL;
            this.fctb.LeftBracket = '(';
            this.fctb.Location = new System.Drawing.Point(0, 0);
            this.fctb.Name = "fctb";
            this.fctb.Paddings = new System.Windows.Forms.Padding(0);
            this.fctb.RightBracket = ')';
            this.fctb.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.fctb.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("fctb.ServiceColors")));
            this.fctb.Size = new System.Drawing.Size(776, 417);
            this.fctb.TabIndex = 4;
            this.fctb.ToolTipDelay = 500;
            this.fctb.WordWrap = true;
            this.fctb.Zoom = 100;
            this.fctb.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.fctb_TextChanged);
            this.fctb.SelectionChangedDelayed += new System.EventHandler(this.fctb_SelectionChangedDelayed);
            this.fctb.Load += new System.EventHandler(this.fctb_Load);
            // 
            // split_main
            // 
            this.split_main.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.split_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.split_main.Location = new System.Drawing.Point(0, 24);
            this.split_main.Name = "split_main";
            this.split_main.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // split_main.Panel1
            // 
            this.split_main.Panel1.Controls.Add(this.fctb);
            this.split_main.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // split_main.Panel2
            // 
            this.split_main.Panel2.Controls.Add(this.tabCtrl_Result);
            this.split_main.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.split_main.Panel2Collapsed = true;
            this.split_main.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.split_main.Size = new System.Drawing.Size(776, 417);
            this.split_main.SplitterDistance = 207;
            this.split_main.SplitterIncrement = 10;
            this.split_main.SplitterWidth = 6;
            this.split_main.TabIndex = 6;
            // 
            // tabCtrl_Result
            // 
            this.tabCtrl_Result.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrl_Result.Location = new System.Drawing.Point(0, 0);
            this.tabCtrl_Result.Name = "tabCtrl_Result";
            this.tabCtrl_Result.SelectedIndex = 0;
            this.tabCtrl_Result.Size = new System.Drawing.Size(150, 46);
            this.tabCtrl_Result.TabIndex = 0;
            // 
            // frmRunQuerySQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(776, 441);
            this.Controls.Add(this.split_main);
            this.Controls.Add(this.menuStrip1);
            this.Name = "frmRunQuerySQL";
            this.Text = "RunQuerySQL";
            this.Load += new System.EventHandler(this.frmRunQuerySQL_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fctb)).EndInit();
            this.split_main.Panel1.ResumeLayout(false);
            this.split_main.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.split_main)).EndInit();
            this.split_main.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem miChangeColors;
        private System.Windows.Forms.ImageList imageList1;
        private FastColoredTextBoxNS.FastColoredTextBox fctb;
        private System.Windows.Forms.SplitContainer split_main;
        private System.Windows.Forms.TabControl tabCtrl_Result;
        private System.Windows.Forms.ToolStripMenuItem ẩnResultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnu_hideResult;
    }
}