namespace WindowsFormsApp1
{
    partial class frmConFig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConFig));
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.rtb_ConfigCode = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_save = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Store = new System.Windows.Forms.Button();
            this.btn_Service = new System.Windows.Forms.Button();
            this.btn_Model = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbx_ConfigLayer = new System.Windows.Forms.ComboBox();
            this.btn_API = new System.Windows.Forms.Button();
            this.btn_Tutorial = new System.Windows.Forms.Button();
            this.btn_ReadSaveFromList = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_SaveFromList = new System.Windows.Forms.TextBox();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ChangePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lưuThayĐổiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_ReadMain = new System.Windows.Forms.Button();
            this.btn_ReadDropDown = new System.Windows.Forms.Button();
            this.btn_ReadSearch = new System.Windows.Forms.Button();
            this.btn_ReadGetAll = new System.Windows.Forms.Button();
            this.btn_ReadGetByID = new System.Windows.Forms.Button();
            this.btn_ReadDelete = new System.Windows.Forms.Button();
            this.btn_ReadUpdate = new System.Windows.Forms.Button();
            this.btn_DropdownOption = new System.Windows.Forms.Button();
            this.btn_ReadInsert = new System.Windows.Forms.Button();
            this.btn_Interface = new System.Windows.Forms.Button();
            this.btn_DataAccess = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_DropDown = new System.Windows.Forms.TextBox();
            this.txt_Main = new System.Windows.Forms.TextBox();
            this.txt_GetAll = new System.Windows.Forms.TextBox();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.txt_Delete = new System.Windows.Forms.TextBox();
            this.txt_GetById = new System.Windows.Forms.TextBox();
            this.txt_insert = new System.Windows.Forms.TextBox();
            this.txt_Update = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // rtb_ConfigCode
            // 
            this.rtb_ConfigCode.AcceptsTab = true;
            this.rtb_ConfigCode.Dock = System.Windows.Forms.DockStyle.Right;
            this.rtb_ConfigCode.Location = new System.Drawing.Point(279, 0);
            this.rtb_ConfigCode.Name = "rtb_ConfigCode";
            this.rtb_ConfigCode.Size = new System.Drawing.Size(575, 459);
            this.rtb_ConfigCode.TabIndex = 7;
            this.rtb_ConfigCode.Text = "";
            this.rtb_ConfigCode.TextChanged += new System.EventHandler(this.rtb_ConfigCode_TextChanged);
            this.rtb_ConfigCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_ConfigCode_KeyDown);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 26);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeyDisplayString = "";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem3.Text = "Lưu thay đổi";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(202, 429);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(69, 23);
            this.btn_save.TabIndex = 30;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "transparency (1).png");
            this.imageList1.Images.SetKeyName(1, "eye.png");
            // 
            // btn_Store
            // 
            this.btn_Store.Location = new System.Drawing.Point(87, 368);
            this.btn_Store.Name = "btn_Store";
            this.btn_Store.Size = new System.Drawing.Size(92, 23);
            this.btn_Store.TabIndex = 21;
            this.btn_Store.Text = "Store Procedure";
            this.btn_Store.UseVisualStyleBackColor = true;
            this.btn_Store.Click += new System.EventHandler(this.btn_Store_Click);
            // 
            // btn_Service
            // 
            this.btn_Service.Location = new System.Drawing.Point(6, 368);
            this.btn_Service.Name = "btn_Service";
            this.btn_Service.Size = new System.Drawing.Size(75, 23);
            this.btn_Service.TabIndex = 20;
            this.btn_Service.Text = "Service";
            this.btn_Service.UseVisualStyleBackColor = true;
            this.btn_Service.Click += new System.EventHandler(this.btn_Service_Click);
            // 
            // btn_Model
            // 
            this.btn_Model.Location = new System.Drawing.Point(177, 339);
            this.btn_Model.Name = "btn_Model";
            this.btn_Model.Size = new System.Drawing.Size(75, 23);
            this.btn_Model.TabIndex = 19;
            this.btn_Model.Text = "Model";
            this.btn_Model.UseVisualStyleBackColor = true;
            this.btn_Model.Click += new System.EventHandler(this.btn_Model_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbx_ConfigLayer);
            this.groupBox1.Controls.Add(this.btn_API);
            this.groupBox1.Controls.Add(this.btn_Tutorial);
            this.groupBox1.Controls.Add(this.btn_ReadSaveFromList);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_SaveFromList);
            this.groupBox1.Controls.Add(this.btn_ReadMain);
            this.groupBox1.Controls.Add(this.btn_ReadDropDown);
            this.groupBox1.Controls.Add(this.btn_ReadSearch);
            this.groupBox1.Controls.Add(this.btn_ReadGetAll);
            this.groupBox1.Controls.Add(this.btn_ReadGetByID);
            this.groupBox1.Controls.Add(this.btn_ReadDelete);
            this.groupBox1.Controls.Add(this.btn_ReadUpdate);
            this.groupBox1.Controls.Add(this.btn_DropdownOption);
            this.groupBox1.Controls.Add(this.btn_save);
            this.groupBox1.Controls.Add(this.btn_ReadInsert);
            this.groupBox1.Controls.Add(this.btn_Store);
            this.groupBox1.Controls.Add(this.btn_Service);
            this.groupBox1.Controls.Add(this.btn_Model);
            this.groupBox1.Controls.Add(this.btn_Interface);
            this.groupBox1.Controls.Add(this.btn_DataAccess);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_DropDown);
            this.groupBox1.Controls.Add(this.txt_Main);
            this.groupBox1.Controls.Add(this.txt_GetAll);
            this.groupBox1.Controls.Add(this.txt_Search);
            this.groupBox1.Controls.Add(this.txt_Delete);
            this.groupBox1.Controls.Add(this.txt_GetById);
            this.groupBox1.Controls.Add(this.txt_insert);
            this.groupBox1.Controls.Add(this.txt_Update);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 459);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cấu hình link";
            // 
            // cbx_ConfigLayer
            // 
            this.cbx_ConfigLayer.FormattingEnabled = true;
            this.cbx_ConfigLayer.Location = new System.Drawing.Point(8, 19);
            this.cbx_ConfigLayer.Name = "cbx_ConfigLayer";
            this.cbx_ConfigLayer.Size = new System.Drawing.Size(257, 21);
            this.cbx_ConfigLayer.TabIndex = 47;
            this.cbx_ConfigLayer.SelectedIndexChanged += new System.EventHandler(this.cbx_ConfigLayer_SelectedIndexChanged);
            // 
            // btn_API
            // 
            this.btn_API.Location = new System.Drawing.Point(185, 368);
            this.btn_API.Name = "btn_API";
            this.btn_API.Size = new System.Drawing.Size(56, 23);
            this.btn_API.TabIndex = 46;
            this.btn_API.Text = "API";
            this.btn_API.UseVisualStyleBackColor = true;
            this.btn_API.Click += new System.EventHandler(this.btn_API_Click);
            // 
            // btn_Tutorial
            // 
            this.btn_Tutorial.Location = new System.Drawing.Point(83, 429);
            this.btn_Tutorial.Name = "btn_Tutorial";
            this.btn_Tutorial.Size = new System.Drawing.Size(113, 23);
            this.btn_Tutorial.TabIndex = 45;
            this.btn_Tutorial.Text = "Hướng dẫn";
            this.btn_Tutorial.UseVisualStyleBackColor = true;
            this.btn_Tutorial.Click += new System.EventHandler(this.btn_Tutorial_Click);
            // 
            // btn_ReadSaveFromList
            // 
            this.btn_ReadSaveFromList.ImageIndex = 1;
            this.btn_ReadSaveFromList.ImageList = this.imageList1;
            this.btn_ReadSaveFromList.Location = new System.Drawing.Point(246, 229);
            this.btn_ReadSaveFromList.Name = "btn_ReadSaveFromList";
            this.btn_ReadSaveFromList.Size = new System.Drawing.Size(23, 21);
            this.btn_ReadSaveFromList.TabIndex = 44;
            this.btn_ReadSaveFromList.UseVisualStyleBackColor = true;
            this.btn_ReadSaveFromList.Click += new System.EventHandler(this.btn_ReadSaveFromList_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 236);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 43;
            this.label9.Text = "saveFromList";
            // 
            // txt_SaveFromList
            // 
            this.txt_SaveFromList.ContextMenuStrip = this.ContextMenu;
            this.txt_SaveFromList.Location = new System.Drawing.Point(87, 229);
            this.txt_SaveFromList.Name = "txt_SaveFromList";
            this.txt_SaveFromList.Size = new System.Drawing.Size(153, 20);
            this.txt_SaveFromList.TabIndex = 42;
            this.txt_SaveFromList.TextChanged += new System.EventHandler(this.txt_saveFromList_TextChanged);
            this.txt_SaveFromList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SaveFromList_KeyDown);
            this.txt_SaveFromList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_SaveFromList_MouseDown);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ChangePathToolStripMenuItem,
            this.ShowContentToolStripMenuItem,
            this.lưuThayĐổiToolStripMenuItem});
            this.ContextMenu.Name = "contextMenuStrip1";
            this.ContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ContextMenu.Size = new System.Drawing.Size(183, 70);
            // 
            // ChangePathToolStripMenuItem
            // 
            this.ChangePathToolStripMenuItem.Name = "ChangePathToolStripMenuItem";
            this.ChangePathToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ChangePathToolStripMenuItem.Text = "Thay đổi đường dẫn";
            this.ChangePathToolStripMenuItem.Click += new System.EventHandler(this.ChangePathToolStripMenuItem_Click);
            // 
            // ShowContentToolStripMenuItem
            // 
            this.ShowContentToolStripMenuItem.Name = "ShowContentToolStripMenuItem";
            this.ShowContentToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.ShowContentToolStripMenuItem.Text = "hiển thị nội dung";
            this.ShowContentToolStripMenuItem.Click += new System.EventHandler(this.ShowContentToolStripMenuItem_Click);
            // 
            // lưuThayĐổiToolStripMenuItem
            // 
            this.lưuThayĐổiToolStripMenuItem.Name = "lưuThayĐổiToolStripMenuItem";
            this.lưuThayĐổiToolStripMenuItem.ShortcutKeyDisplayString = "";
            this.lưuThayĐổiToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.lưuThayĐổiToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.lưuThayĐổiToolStripMenuItem.Text = "Lưu thay đổi";
            this.lưuThayĐổiToolStripMenuItem.Click += new System.EventHandler(this.lưuThayĐổiToolStripMenuItem_Click);
            // 
            // btn_ReadMain
            // 
            this.btn_ReadMain.ImageIndex = 1;
            this.btn_ReadMain.ImageList = this.imageList1;
            this.btn_ReadMain.Location = new System.Drawing.Point(246, 256);
            this.btn_ReadMain.Name = "btn_ReadMain";
            this.btn_ReadMain.Size = new System.Drawing.Size(23, 21);
            this.btn_ReadMain.TabIndex = 41;
            this.btn_ReadMain.UseVisualStyleBackColor = true;
            this.btn_ReadMain.Click += new System.EventHandler(this.btn_ReadMain_Click);
            // 
            // btn_ReadDropDown
            // 
            this.btn_ReadDropDown.ImageIndex = 1;
            this.btn_ReadDropDown.ImageList = this.imageList1;
            this.btn_ReadDropDown.Location = new System.Drawing.Point(246, 202);
            this.btn_ReadDropDown.Name = "btn_ReadDropDown";
            this.btn_ReadDropDown.Size = new System.Drawing.Size(23, 21);
            this.btn_ReadDropDown.TabIndex = 40;
            this.btn_ReadDropDown.UseVisualStyleBackColor = true;
            this.btn_ReadDropDown.Click += new System.EventHandler(this.btn_ReadDropDown_Click);
            // 
            // btn_ReadSearch
            // 
            this.btn_ReadSearch.ImageIndex = 1;
            this.btn_ReadSearch.ImageList = this.imageList1;
            this.btn_ReadSearch.Location = new System.Drawing.Point(246, 176);
            this.btn_ReadSearch.Name = "btn_ReadSearch";
            this.btn_ReadSearch.Size = new System.Drawing.Size(26, 21);
            this.btn_ReadSearch.TabIndex = 39;
            this.btn_ReadSearch.UseVisualStyleBackColor = true;
            this.btn_ReadSearch.Click += new System.EventHandler(this.btn_ReadSearch_Click);
            // 
            // btn_ReadGetAll
            // 
            this.btn_ReadGetAll.ImageIndex = 1;
            this.btn_ReadGetAll.ImageList = this.imageList1;
            this.btn_ReadGetAll.Location = new System.Drawing.Point(246, 150);
            this.btn_ReadGetAll.Name = "btn_ReadGetAll";
            this.btn_ReadGetAll.Size = new System.Drawing.Size(26, 21);
            this.btn_ReadGetAll.TabIndex = 38;
            this.btn_ReadGetAll.UseVisualStyleBackColor = true;
            this.btn_ReadGetAll.Click += new System.EventHandler(this.btn_ReadGetAll_Click);
            // 
            // btn_ReadGetByID
            // 
            this.btn_ReadGetByID.ImageIndex = 1;
            this.btn_ReadGetByID.ImageList = this.imageList1;
            this.btn_ReadGetByID.Location = new System.Drawing.Point(246, 128);
            this.btn_ReadGetByID.Name = "btn_ReadGetByID";
            this.btn_ReadGetByID.Size = new System.Drawing.Size(26, 21);
            this.btn_ReadGetByID.TabIndex = 37;
            this.btn_ReadGetByID.UseVisualStyleBackColor = true;
            this.btn_ReadGetByID.Click += new System.EventHandler(this.btn_ReadGetByID_Click);
            // 
            // btn_ReadDelete
            // 
            this.btn_ReadDelete.ImageIndex = 1;
            this.btn_ReadDelete.ImageList = this.imageList1;
            this.btn_ReadDelete.Location = new System.Drawing.Point(246, 102);
            this.btn_ReadDelete.Name = "btn_ReadDelete";
            this.btn_ReadDelete.Size = new System.Drawing.Size(26, 21);
            this.btn_ReadDelete.TabIndex = 36;
            this.btn_ReadDelete.UseVisualStyleBackColor = true;
            this.btn_ReadDelete.Click += new System.EventHandler(this.btn_ReadDelete_Click);
            // 
            // btn_ReadUpdate
            // 
            this.btn_ReadUpdate.ImageIndex = 1;
            this.btn_ReadUpdate.ImageList = this.imageList1;
            this.btn_ReadUpdate.Location = new System.Drawing.Point(246, 72);
            this.btn_ReadUpdate.Name = "btn_ReadUpdate";
            this.btn_ReadUpdate.Size = new System.Drawing.Size(26, 21);
            this.btn_ReadUpdate.TabIndex = 35;
            this.btn_ReadUpdate.UseVisualStyleBackColor = true;
            this.btn_ReadUpdate.Click += new System.EventHandler(this.btn_ReadUpdate_Click);
            // 
            // btn_DropdownOption
            // 
            this.btn_DropdownOption.Location = new System.Drawing.Point(4, 397);
            this.btn_DropdownOption.Name = "btn_DropdownOption";
            this.btn_DropdownOption.Size = new System.Drawing.Size(113, 23);
            this.btn_DropdownOption.TabIndex = 34;
            this.btn_DropdownOption.Text = "Dropdown Option";
            this.btn_DropdownOption.UseVisualStyleBackColor = true;
            this.btn_DropdownOption.Click += new System.EventHandler(this.btn_DropdownOption_Click);
            // 
            // btn_ReadInsert
            // 
            this.btn_ReadInsert.ImageIndex = 1;
            this.btn_ReadInsert.ImageList = this.imageList1;
            this.btn_ReadInsert.Location = new System.Drawing.Point(246, 46);
            this.btn_ReadInsert.Name = "btn_ReadInsert";
            this.btn_ReadInsert.Size = new System.Drawing.Size(26, 21);
            this.btn_ReadInsert.TabIndex = 22;
            this.btn_ReadInsert.UseVisualStyleBackColor = true;
            this.btn_ReadInsert.Click += new System.EventHandler(this.button6_Click);
            // 
            // btn_Interface
            // 
            this.btn_Interface.Location = new System.Drawing.Point(87, 339);
            this.btn_Interface.Name = "btn_Interface";
            this.btn_Interface.Size = new System.Drawing.Size(75, 23);
            this.btn_Interface.TabIndex = 18;
            this.btn_Interface.Text = "interface";
            this.btn_Interface.UseVisualStyleBackColor = true;
            this.btn_Interface.Click += new System.EventHandler(this.btn_Interface_Click);
            // 
            // btn_DataAccess
            // 
            this.btn_DataAccess.Location = new System.Drawing.Point(6, 339);
            this.btn_DataAccess.Name = "btn_DataAccess";
            this.btn_DataAccess.Size = new System.Drawing.Size(75, 23);
            this.btn_DataAccess.TabIndex = 17;
            this.btn_DataAccess.Text = "DataAccess";
            this.btn_DataAccess.UseVisualStyleBackColor = true;
            this.btn_DataAccess.Click += new System.EventHandler(this.btn_DataAccess_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 79);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Update";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 183);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Search";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 157);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "GetAll";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Delete";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "GetById";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Dropdown";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Insert";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Main";
            // 
            // txt_DropDown
            // 
            this.txt_DropDown.ContextMenuStrip = this.ContextMenu;
            this.txt_DropDown.Location = new System.Drawing.Point(87, 202);
            this.txt_DropDown.Name = "txt_DropDown";
            this.txt_DropDown.Size = new System.Drawing.Size(153, 20);
            this.txt_DropDown.TabIndex = 8;
            this.txt_DropDown.TextChanged += new System.EventHandler(this.txt_DropDown_TextChanged);
            this.txt_DropDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_DropDown_KeyDown);
            // 
            // txt_Main
            // 
            this.txt_Main.ContextMenuStrip = this.ContextMenu;
            this.txt_Main.Location = new System.Drawing.Point(87, 256);
            this.txt_Main.Name = "txt_Main";
            this.txt_Main.Size = new System.Drawing.Size(153, 20);
            this.txt_Main.TabIndex = 9;
            this.txt_Main.TextChanged += new System.EventHandler(this.txt_Main_TextChanged);
            this.txt_Main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Main_KeyDown);
            // 
            // txt_GetAll
            // 
            this.txt_GetAll.ContextMenuStrip = this.ContextMenu;
            this.txt_GetAll.Location = new System.Drawing.Point(87, 150);
            this.txt_GetAll.Name = "txt_GetAll";
            this.txt_GetAll.Size = new System.Drawing.Size(153, 20);
            this.txt_GetAll.TabIndex = 6;
            this.txt_GetAll.TextChanged += new System.EventHandler(this.txt_GetAll_TextChanged);
            this.txt_GetAll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_GetAll_KeyDown);
            // 
            // txt_Search
            // 
            this.txt_Search.ContextMenuStrip = this.ContextMenu;
            this.txt_Search.Location = new System.Drawing.Point(87, 176);
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(153, 20);
            this.txt_Search.TabIndex = 7;
            this.txt_Search.TextChanged += new System.EventHandler(this.txt_Search_TextChanged);
            this.txt_Search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Search_KeyDown);
            // 
            // txt_Delete
            // 
            this.txt_Delete.ContextMenuStrip = this.ContextMenu;
            this.txt_Delete.Location = new System.Drawing.Point(87, 98);
            this.txt_Delete.Name = "txt_Delete";
            this.txt_Delete.Size = new System.Drawing.Size(153, 20);
            this.txt_Delete.TabIndex = 4;
            this.txt_Delete.TextChanged += new System.EventHandler(this.txt_Delete_TextChanged);
            this.txt_Delete.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Delete_KeyDown);
            // 
            // txt_GetById
            // 
            this.txt_GetById.ContextMenuStrip = this.ContextMenu;
            this.txt_GetById.Location = new System.Drawing.Point(87, 124);
            this.txt_GetById.Name = "txt_GetById";
            this.txt_GetById.Size = new System.Drawing.Size(153, 20);
            this.txt_GetById.TabIndex = 5;
            this.txt_GetById.TextChanged += new System.EventHandler(this.txt_GetById_TextChanged);
            this.txt_GetById.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_GetById_KeyDown);
            // 
            // txt_insert
            // 
            this.txt_insert.ContextMenuStrip = this.ContextMenu;
            this.txt_insert.Location = new System.Drawing.Point(87, 46);
            this.txt_insert.Name = "txt_insert";
            this.txt_insert.Size = new System.Drawing.Size(153, 20);
            this.txt_insert.TabIndex = 2;
            this.txt_insert.TextChanged += new System.EventHandler(this.txt_insert_TextChanged);
            this.txt_insert.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_insert_KeyDown);
            // 
            // txt_Update
            // 
            this.txt_Update.ContextMenuStrip = this.ContextMenu;
            this.txt_Update.Location = new System.Drawing.Point(87, 72);
            this.txt_Update.Name = "txt_Update";
            this.txt_Update.Size = new System.Drawing.Size(153, 20);
            this.txt_Update.TabIndex = 3;
            this.txt_Update.TextChanged += new System.EventHandler(this.txt_Update_TextChanged);
            this.txt_Update.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_Update_KeyDown);
            // 
            // frmConFig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 459);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.rtb_ConfigCode);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmConFig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration Code";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmConFig_FormClosing);
            this.Load += new System.EventHandler(this.frmConFig_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.RichTextBox rtb_ConfigCode;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_ReadInsert;
        private System.Windows.Forms.Button btn_Store;
        private System.Windows.Forms.Button btn_Service;
        private System.Windows.Forms.Button btn_Model;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Interface;
        private System.Windows.Forms.Button btn_DataAccess;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_DropDown;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem ChangePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowContentToolStripMenuItem;
        private System.Windows.Forms.TextBox txt_Main;
        private System.Windows.Forms.TextBox txt_GetAll;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.TextBox txt_Delete;
        private System.Windows.Forms.TextBox txt_GetById;
        private System.Windows.Forms.TextBox txt_insert;
        private System.Windows.Forms.TextBox txt_Update;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_DropdownOption;
        private System.Windows.Forms.Button btn_ReadMain;
        private System.Windows.Forms.Button btn_ReadDropDown;
        private System.Windows.Forms.Button btn_ReadSearch;
        private System.Windows.Forms.Button btn_ReadGetAll;
        private System.Windows.Forms.Button btn_ReadGetByID;
        private System.Windows.Forms.Button btn_ReadDelete;
        private System.Windows.Forms.Button btn_ReadUpdate;
        private System.Windows.Forms.Button btn_ReadSaveFromList;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_SaveFromList;
        private System.Windows.Forms.Button btn_Tutorial;
        private System.Windows.Forms.Button btn_API;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem lưuThayĐổiToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbx_ConfigLayer;
    }
}