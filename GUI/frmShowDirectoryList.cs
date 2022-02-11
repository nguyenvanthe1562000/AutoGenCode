using BLL.Configuration_storage;
using Common;
using Model.LogUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmShowDirectoryList : Form
    {
        public frmShowDirectoryList()
        {
            InitializeComponent();
            grb_ChangedAndSave.Visible = true;
            btn_SaveChange.Visible = true;
        }
        string _language = string.Empty;
        string _fileName = string.Empty;
        string _content = string.Empty;
        string _filter = string.Empty;
        string _layer = string.Empty;
        string _parentPath = string.Empty;


        public frmShowDirectoryList(string parentPath,List<string> lstPath, string filter, string language, string layer, string fileName, string content)
        {
            InitializeComponent();
            showList(lstPath);
            _filter = filter;
            _language = language;
            _fileName = fileName;
            _content = content;
            _layer = layer;
            _parentPath = parentPath;
            grb_ChangedAndSave.Visible = false;
            btn_SaveChange.Visible = false;
        }

        void showList(List<string> lstPath)
        {
            if (lstPath.Count == 0)
            {
                MessageBox.Show("Không Tìm Thấy");
            }
            lst_FilePath.Items.Clear();
            foreach (var item in lstPath)
            {
                lst_FilePath.Items.Add(item.ToString());
            }
        }

        private void DisplayAndInstall_Load(object sender, EventArgs e)
        {
            txt_Filter.Text = _filter;
            txt_FileName.Text = _fileName;
        }



        private void btn_Filter_Click(object sender, EventArgs e)
        {
         

            showList(ReadSaveFile.FindFolder(_parentPath, txt_Filter.Text));
            BLL_Log_StringFilter log_StringFilter = new BLL_Log_StringFilter();
            Log_StringFilter log_ = new Log_StringFilter(_language, _layer, txt_Filter.Text);
            log_StringFilter.Save(log_);
        }

        private void lst_FilePath_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.lst_FilePath.IndexFromPoint(e.Location);

            string path = lst_FilePath.Items[index].ToString();
            string msgEr = string.Empty;
            _fileName = txt_FileName.Text;
            var saveAble = ReadSaveFile.SaveFileToProject(path, _language, _fileName, _content, out msgEr);
            if (!saveAble)
            {
                MessageBox.Show(msgEr);
                return;
            }
            DialogResult = DialogResult.OK;
            Close();
        }

        private void txt_Filter_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
