using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Model;

namespace WindowsFormsApp1
{


    public partial class frmConFig : Form
    {
        private bool checkchangepath;
        private bool checkchangecontent;
        ConfigLayer _config;
        private string _pathCode;


        public frmConFig()
        {
            InitializeComponent();


        }

        private void frmConFig_Load(object sender, EventArgs e)
        {
            btn_DataAccess.PerformClick();
            LoadConfigMethodPath();
        }
        void LoadConfigMethodPath()
        {
            _config = new ConfigLayer();
            cbx_ConfigLayer.DisplayMember = "ConfigLayer";
            cbx_ConfigLayer.ValueMember = "Method";
            cbx_ConfigLayer.DataSource = ConFig.GetAllLayer();
        }


        private void ChangePathToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    TextBox sourceControlTextbox = owner.SourceControl as TextBox;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        checkchangepath = true;
                        sourceControlTextbox.Text = openFileDialog.FileName;
                    }

                }
            }
        }

        private void ShowContentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripItem menuItem = sender as ToolStripItem;
            if (menuItem != null)
            {
                ContextMenuStrip owner = menuItem.Owner as ContextMenuStrip;
                if (owner != null)
                {
                    Control sourceControl = owner.SourceControl;
                    TextBox sourceControlTextbox = owner.SourceControl as TextBox;
                    rtb_ConfigCode.Text = ReadSaveFile.ReadFile(sourceControlTextbox.Text);
                    _pathCode = sourceControlTextbox.Text;
                }
            }
        }

        private void rtb_ConfigCode_TextChanged(object sender, EventArgs e)
        {

        }
        void SaveAble()
        {
            if (checkchangepath)
            {
                DialogResult result = MessageBox.Show("Đường dẫn đã thay đổi ban có muốn lưu thay đổi", "Lưu thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    changepath();
                    if (ConFig.SaveFileConfig(_config))
                    {
                        checkchangepath = false;
                    }
                }
            }
            if (checkchangecontent)
            {
                DialogResult result = MessageBox.Show(" ban có muốn lưu thay đổi", "Lưu thay đổi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    ReadSaveFile.WirteFile(_pathCode, rtb_ConfigCode.Text);
                    checkchangecontent = false;
                }
            }
        }
        void save()
        {
            if (checkchangecontent)
            {
                changepath();
                ReadSaveFile.WirteFile(_pathCode, rtb_ConfigCode.Text);
                checkchangecontent = false;
            }
            if (checkchangepath)
            {
                changepath();
                if (ConFig.SaveFileConfig(_config))
                {
                    checkchangepath = false;
                }
            }

        }

        private void btn_Interface_Click(object sender, EventArgs e)
        {
        }

        private void btn_Service_Click(object sender, EventArgs e)
        {
        }

        private void btn_Store_Click(object sender, EventArgs e)
        {
        }

        private void btn_Model_Click(object sender, EventArgs e)
        {
        }
        private void btn_DataAccess_Click(object sender, EventArgs e)
        {
        }




        private void txt_insert_TextChanged(object sender, EventArgs e)
        {


        }

        private void txt_Update_TextChanged(object sender, EventArgs e)
        {



        }

        private void txt_Delete_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_GetById_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_GetAll_TextChanged(object sender, EventArgs e)
        {



        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {


        }

        private void txt_DropDown_TextChanged(object sender, EventArgs e)
        {


        }

        private void txt_saveFromList_TextChanged(object sender, EventArgs e)
        {


        }

        private void txt_Main_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmConFig_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveAble();
        }

        private void btn_Tutorial_Click(object sender, EventArgs e)
        {
            frmTutorial frmTutorial = new frmTutorial();
            frmTutorial.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReadFile(txt_insert.Text);
        }

        private void btn_ReadMain_Click(object sender, EventArgs e)
        {
            ReadFile(txt_Main.Text);
        }
        void ReadFile(string path)
        {
            SaveAble();
            rtb_ConfigCode.Text = ReadSaveFile.ReadFile(path);
            _pathCode = path;
        }

        private void btn_ReadUpdate_Click(object sender, EventArgs e)
        {
            ReadFile(txt_Update.Text);
        }

        private void btn_ReadDelete_Click(object sender, EventArgs e)
        {
            ReadFile(txt_Delete.Text);


        }

        private void btn_ReadGetByID_Click(object sender, EventArgs e)
        {
            ReadFile(txt_GetById.Text);

        }

        private void btn_ReadGetAll_Click(object sender, EventArgs e)
        {
            ReadFile(txt_GetAll.Text);
        }

        private void btn_ReadSearch_Click(object sender, EventArgs e)
        {
            ReadFile(txt_Search.Text);
        }

        private void btn_ReadDropDown_Click(object sender, EventArgs e)
        {
            ReadFile(txt_DropDown.Text);
        }

        private void btn_ReadSaveFromList_Click(object sender, EventArgs e)
        {
            ReadFile(txt_SaveFromList.Text);
        }

        private void rtb_ConfigCode_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangecontent = true;
        }

        private void btn_API_Click(object sender, EventArgs e)
        {
        }

        private void btn_DropdownOption_Click(object sender, EventArgs e)
        {
        }

        private void lưuThayĐổiToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            save();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            btn_save.PerformClick();
        }

        private void txt_insert_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_Update_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_Delete_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_GetById_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_GetAll_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_DropDown_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_SaveFromList_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void txt_SaveFromList_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void txt_Main_KeyDown(object sender, KeyEventArgs e)
        {
            checkchangepath = true;
        }

        private void cbx_ConfigLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (checkchangepath)
            {
                changepath();
            }
            ConfigMethod method = cbx_ConfigLayer.SelectedValue as ConfigMethod;
            //object method= 
            //MessageBox.Show(method);
            txt_Delete.Text = method.Delete;
            txt_GetAll.Text = method.GetAll;
            txt_GetById.Text = method.GetById;
            txt_DropDown.Text = method.DropDown;
            txt_Search.Text = method.Search;
            txt_Update.Text = method.Update;
            txt_insert.Text = method.Insert;
            txt_Main.Text = method.Main;
            txt_SaveFromList.Text = method.saveFromList;           
        }
        void changepath()
        {

            var layer = cbx_ConfigLayer.SelectedItem.ToString().Split('-');
            ConfigMethod tempMethod = new ConfigMethod();
            _config.Language = layer[0];
            _config.Layer = layer[1];
            tempMethod.Delete = txt_Delete.Text;
            tempMethod.GetAll = txt_GetAll.Text;
            tempMethod.GetById = txt_GetById.Text;
            tempMethod.DropDown = txt_DropDown.Text;
            tempMethod.Search = txt_Search.Text;
            tempMethod.Update = txt_Update.Text;
            tempMethod.Insert = txt_insert.Text;
            tempMethod.Main = txt_Main.Text;
            tempMethod.saveFromList = txt_SaveFromList.Text;
            _config.Method = tempMethod;
        }
    }
}
