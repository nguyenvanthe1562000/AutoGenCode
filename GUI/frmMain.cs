using BLL;
using BLL.Configuration_storage;
using BLL.GenarationCode;
using Common;
using Microsoft.WindowsAPICodePack.Dialogs;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;//xu lý 'Cross-thread operation not valid: Control 'toolStrip1' accessed from a thread other than the thread it was created on.'
        }
        BLLDatabase _BLLDatabase;
        BLL_Log_Fields_Selected _bLL_Log_Fields_Selected;
        BLL_Log_Last_Used _bLL_Log_Last_Used;
        BLLGenCode _bLLGenCode;
        BLL_Log_StringFilter _bll_log_StringFilter;

        string _dataBase;
        string _table;
        private void frmMain_Load(object sender, EventArgs e)
        {
            this.IsMdiContainer = true;
            _BLLDatabase = new BLLDatabase();
            _bLL_Log_Fields_Selected = new BLL_Log_Fields_Selected();
            _bLL_Log_Last_Used = new BLL_Log_Last_Used();
            _bLLGenCode = new BLLGenCode();
            _bll_log_StringFilter = new BLL_Log_StringFilter();

            tsb_DbConnection.PerformClick();

            LoadLog();

        }
        private void LoadLog()
        {
            //load db,namespace,url,api,code
            Log_Last_Used log = _bLL_Log_Last_Used.Load_Data();
            cbx_Database.Text = log.name_db_e;
            txt_ClassName.Text = log.name_api_e;
            txt_Namespace.Text = log.namespace_e;
            txt_UrlProject.Text = log.url_project_e;
            rtb_Main.Text = log.codeModel_e;

            //
        }

        private void tsb_DbConnection_Click(object sender, EventArgs e)
        {
            frmLogin frm = new frmLogin();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                cbx_Database.Items.Clear();
                foreach (var item in _BLLDatabase.GetDB(frm.strConnection))
                {
                    cbx_Database.Items.Add(item);
                }

            }
        }

        private void cbx_Database_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rad_Table.Checked)
            {
                _dataBase = cbx_Database.SelectedItem.ToString();
                var soucrce = _BLLDatabase.GetTB(_dataBase);
                soucrce.Sort();
                if (soucrce.Count != 0)
                {
                    lbx_Table.DataSource = soucrce;

                    var tasks = new List<Task>();
                    tasks.Add(Task.Run(() =>
                    {
                        cbx_FromTable.Items.Clear();

                        foreach (var item in soucrce)
                        {
                            cbx_FromTable.Items.Add(item);
                        }
                        cbx_FromTable.SelectedIndex = 0;
                    }));
                    tasks.Add(Task.Run(() =>
                    {
                        cbx_ToTable.Items.Clear();
                        foreach (var item in soucrce)
                        {
                            cbx_ToTable.Items.Add(item);
                        }
                        cbx_ToTable.SelectedIndex = cbx_ToTable.Items.Count - 1;
                    }));

                    Task task = Task.WhenAll(tasks);
                }
            }
            return;
        }

        private void lbx_Table_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgv_Table.AllowUserToAddRows = true;
            dgv_Table.AllowUserToDeleteRows = true;
            dgv_Table.Rows.Clear();
            if (rad_SProcedure.Checked)
            {
                rtb_Main.Text = "";
                var value = lbx_Table.SelectedValue.ToString();
                if (int.TryParse(value, out int id))
                {
                    dgv_Table.Rows.Clear();
                    var text = _BLLDatabase.GetStoreProcedureText(id);
                    rtb_Main.Text = text;
                    foreach (DataRow item in _BLLDatabase.GetStoreProcedureParameter(id).Rows)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgv_Table.Rows[0].Clone();
                        row.Cells[0].Value = item[0];
                        row.Cells[2].Value = item[1];
                        row.Cells[3].Value = item[2];
                        dgv_Table.Rows.Add(row);
                    }

                }


            }
            else if (rad_View.Checked)
            {

            }

            else
            {

                if (ckb_DefaultNamespace.Checked)
                {
                    txt_Namespace.Text = GetDefaultNameSpace();
                }
                _table = lbx_Table.SelectedValue.ToString();
                var table = _bLL_Log_Fields_Selected.Table(cbx_Database.Text, lbx_Table.SelectedValue.ToString());
                if (table.Count == 0)
                {
                    AutoSelectKeyWord();
                }
                else
                {
                    foreach (DataRow item in _BLLDatabase.GetField(lbx_Table.SelectedItem.ToString()).Rows)
                    {
                        DataGridViewRow row = (DataGridViewRow)dgv_Table.Rows[0].Clone();
                        row.Cells[0].Value = item[0];
                        row.Cells[1].Value = item[1];
                        row.Cells[2].Value = item[2];
                        row.Cells[3].Value = item[3];
                        row.Cells[4].Value = item[4];
                        row.Cells[5].Value = item[5];
                        row.Cells[6].Value = item[6];
                        var historyIsSave = table.FirstOrDefault(x => x[3].ToString().Equals(row.Cells[0].Value.ToString()));
                        if (historyIsSave != null)
                        {
                            row.Cells[7].Value = historyIsSave[4];
                            row.Cells[8].Value = historyIsSave[5];
                            row.Cells[9].Value = historyIsSave[6];
                            row.Cells[10].Value = historyIsSave[7];
                            row.Cells[11].Value = historyIsSave[8];
                            row.Cells[12].Value = historyIsSave[9];
                            row.Cells[13].Value = historyIsSave[10];
                            row.Cells[14].Value = historyIsSave[11];
                            row.Cells[15].Value = historyIsSave[12];
                        }
                        dgv_Table.Rows.Add(row);
                    }
                    txt_ClassName.Text = lbx_Table.SelectedItem.ToString();
                }


            }

            dgv_Table.AllowUserToAddRows = false;
            dgv_Table.AllowUserToDeleteRows = false;

        }

        private void AutoSelectKeyWord()
        {
            bool checkdropdownlabe = true;
            bool checkdropdownValue = true;
            foreach (DataRow item in _BLLDatabase.GetField(lbx_Table.SelectedItem.ToString()).Rows)
            {
                DataGridViewRow row = (DataGridViewRow)dgv_Table.Rows[0].Clone();
                row.Cells[0].Value = item[0];
                row.Cells[1].Value = item[1];
                row.Cells[2].Value = item[2];
                row.Cells[3].Value = item[3];
                row.Cells[4].Value = item[4];
                row.Cells[5].Value = item[5];
                row.Cells[6].Value = item[6];
                var fieldName = item[0].ToString().ToLower();
                var type = item[2].ToString().ToLower();
                var isPk = item[4].ToString().ToLower();
                var isFK = item[5].ToString().ToLower();
                var identity = item[6].ToString().ToLower();
                if (!string.IsNullOrWhiteSpace(isPk) && !string.IsNullOrWhiteSpace(identity))
                {
                    row.Cells[7].Value = "c";// model
                    row.Cells[8].Value = "pri";//delete
                    row.Cells[9].Value = string.Empty;//insert
                    row.Cells[10].Value = "c";//getall
                    row.Cells[11].Value = "pri";//update
                    row.Cells[12].Value = "prc";//search
                    row.Cells[13].Value = "jir";//seveformlist
                    if (checkdropdownValue)
                    {
                        checkdropdownValue = false;
                        row.Cells[14].Value = "cv";//dropdown
                    }
                    row.Cells[15].Value = "prc";//getbyid    
                }

                else if (fieldName.Contains("id") && !string.IsNullOrWhiteSpace(identity))
                {
                    row.Cells[7].Value = "c";//model
                    row.Cells[8].Value = "pri";//delete
                    row.Cells[9].Value = "pi";//insert
                    row.Cells[10].Value = "c";//getall
                    row.Cells[11].Value = "pri";//update
                    row.Cells[12].Value = "cpr";//search
                    row.Cells[13].Value = "jri";//seveformlist
                    if (checkdropdownValue)
                    {
                        checkdropdownValue = false;
                        row.Cells[14].Value = "cv";//dropdown
                    }
                    row.Cells[15].Value = "pcr";//getbyid    

                }
                else if (fieldName.Contains("CreateAt") || fieldName.Contains("CreatedBy") || fieldName.Contains("ModifiedBy") || fieldName.Contains("ModifiedAt"))
                {

                    row.Cells[7].Value = "c";//model
                    row.Cells[8].Value = " ";//delete
                    row.Cells[9].Value = " ";//insert
                    row.Cells[10].Value = "c";//getall
                    row.Cells[11].Value = " ";//update
                    row.Cells[12].Value = "c";//search
                    row.Cells[13].Value = "";//seveformlist

                    row.Cells[15].Value = "c";//getbyid    

                }
                else if (type.Contains("date") && (fieldName.Contains("tao") || fieldName.Contains("create")))
                {
                    row.Cells[7].Value = "c";//model
                    row.Cells[8].Value = "";//delete
                    row.Cells[9].Value = "pi";//insert
                    row.Cells[10].Value = "c";//getall
                    row.Cells[11].Value = "pi";//update
                    row.Cells[12].Value = "ck";//search
                    row.Cells[13].Value = "ji";//seveformlist
                    row.Cells[14].Value = "";//dropdown
                    row.Cells[15].Value = "c";//getbyid
                }
                else
                {
                    row.Cells[7].Value = "c";//model
                    row.Cells[8].Value = "";//delete
                    row.Cells[9].Value = "pi";//insert
                    row.Cells[10].Value = "c";//getall
                    row.Cells[11].Value = "pi";//update
                    row.Cells[12].Value = "c";//search
                    row.Cells[13].Value = "ji";//seveformlist
                    row.Cells[14].Value = "";//dropdown
                    row.Cells[15].Value = "c";//getbyid
                }
                if ((fieldName.Contains("name") || fieldName.Contains("ten")) && checkdropdownlabe)
                {
                    row.Cells[14].Value = "cl";//dropdown
                    checkdropdownlabe = false;
                }
                dgv_Table.Rows.Add(row);
            }
        }

        private void tsb_Export_Click(object sender, EventArgs e)
        {
            var language = string.Empty;
            var layer = string.Empty;
            GetLanguageAndLayer(ref language, ref layer);
            var model = GetFieldsSelected_Sql(language);
            string msgError = string.Empty;
            string result = string.Empty;
            //luu nhat ky su dung keyword
            Thread _saveLogFieldsSelected = new Thread(SaveLogFieldsSelected);
            _saveLogFieldsSelected.IsBackground = true;
            _saveLogFieldsSelected.Start();
            //

            int fromTable = cbx_FromTable.SelectedIndex;
            int toTable = cbx_ToTable.SelectedIndex;
            var listtable = new List<string>();
            for (int i = fromTable; i <= toTable; i++)
            {
                listtable.Add(lbx_Table.Items[i].ToString());
            }
            result = _bLLGenCode.Generate(txt_Namespace.Text, txt_ClassName.Text, model, language, layer, listtable, out msgError);
            if (!string.IsNullOrEmpty(msgError))
            {
                var s = MessageBox.Show(msgError, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            rtb_Main.Text = result;
        }

        private Dictionary<string, List<string>> GetFieldsSelected_Sql(string language)
        {
            Dictionary<string, List<string>> fields = new Dictionary<string, List<string>>();
            for (int i = 7; i < dgv_Table.Columns.Count; i++)
            {
                List<string> field = new List<string>();

                for (int j = 0; j < dgv_Table.Rows.Count; j++)
                {
                    if (dgv_Table.Rows[j].Cells[i].Value != null)
                    {
                        string name = dgv_Table.Rows[j].Cells[0].Value.ToString();
                        string type = dgv_Table.Rows[j].Cells[2].Value.ToString();
                        string lenght = dgv_Table.Rows[j].Cells[3].Value.ToString();
                        string isNull = dgv_Table.Rows[j].Cells[1].Value.ToString();
                        char[] require = dgv_Table.Rows[j].Cells[i].Value.ToString().ToCharArray().Distinct().ToArray();
                        foreach (var key in require)
                        {
                            field.Add(GetFieldSql.Convert(type, lenght, name, key, language));
                        }
                        //if (require.Contains('c'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'c', language));
                        //}
                        //if (require.Contains('r'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'r', language));
                        //}
                        //if (require.Contains('p'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'p', language));
                        //}
                        //if (require.Contains('k'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'k', language));
                        //}
                        //if (require.Contains('b'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'b', language));
                        //}
                        //if (require.Contains('a'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'a', language));
                        //}
                        //if (require.Contains('d'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'd', language));
                        //}
                        //if (require.Contains('l'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'l', language));
                        //}
                        //if (require.Contains('v'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'v', language));
                        //}
                        //if (require.Contains('e'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'e', language));
                        //}
                        //if (require.Contains('m'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'm', language));
                        //}
                        //if (require.Contains('j'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'j', language));
                        //}
                        //if (require.Contains('i'))
                        //{
                        //    field.Add(GetFieldSql.Convert(type, lenght, name, 'i', language));
                        //}
                    }
                }
                fields.Add(dgv_Table.Columns[i].HeaderText.ToLower(), field);
            }
            return fields;
        }
        //ghi lại các column đã  thay đổi
        void SaveLogFieldsSelected()
        {
            try
            {
                List<Log_Fields_Selected> lst = new List<Log_Fields_Selected>();
                bool checkFieldNull = true;
                for (int i = 0; i < dgv_Table.Rows.Count; i++)
                {

                    for (int j = 0; j < dgv_Table.Columns.Count; j++)
                    {
                        if (dgv_Table.Rows[i].Cells[j].Value == null)
                        {
                            dgv_Table.Rows[i].Cells[j].Value = string.Empty; ;
                        }
                    }
                    string strr = dgv_Table.Rows[i].Cells["Update"].Value.ToString();
                    Log_Fields_Selected log = new Log_Fields_Selected();
                    log.database_e = _dataBase;
                    log.table_e = _table;
                    log.fields_e = dgv_Table.Rows[i].Cells[0].Value.ToString();
                    log.models_e = dgv_Table.Rows[i].Cells["Model"].Value.ToString();
                    log.delete_e = dgv_Table.Rows[i].Cells["Delete"].Value.ToString();
                    log.insert_e = dgv_Table.Rows[i].Cells["Insert"].Value.ToString();
                    log.update_e = dgv_Table.Rows[i].Cells["Update"].Value.ToString();
                    log.getAll_e = dgv_Table.Rows[i].Cells["GetAll"].Value.ToString();
                    log.search_e = dgv_Table.Rows[i].Cells["Search"].Value.ToString();
                    log.saveFromList_e = dgv_Table.Rows[i].Cells["SaveFromList"].Value.ToString();
                    log.dropdown_e = dgv_Table.Rows[i].Cells["Dropdown"].Value.ToString();
                    log.getById_e = dgv_Table.Rows[i].Cells["GetById"].Value.ToString();
                    lst.Add(log);
                }

                _bLL_Log_Fields_Selected.Save(lst);
            }
            catch (Exception ex)
            {
                return;
            }
        }

        private void txt_Search_KeyDown(object sender, KeyEventArgs e)
        {
            if (lbx_Table.Items.Count > 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    string db = cbx_Database.SelectedItem.ToString();
                    
                     var lst = _BLLDatabase.GetTB(db).Where(x => x.ToUpper().Contains(txt_Search.Text.ToUpper()));
                    lbx_Table.DataSource = lst.ToList();
                }
            }
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            try
            {
                string db = cbx_Database.SelectedItem.ToString();
                lbx_Table.DataSource = _BLLDatabase.GetTB(db);
            }
            catch (Exception)
            {

                return;
            }

        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _bLL_Log_Last_Used.Save(cbx_Database.Text, txt_Namespace.Text, txt_ClassName.Text, txt_UrlProject.Text, rtb_Main.Text);
        }

        private void tsb_Save_Click(object sender, EventArgs e)
        {

            string language = string.Empty;
            string layer = string.Empty;
            GetLanguageAndLayer(ref language, ref layer);
            string fileName = GetFileName(language, layer);
            string content = rtb_Main.Text;
            string msgEr = string.Empty;
            try
            {
                if (language.Equals(Layer.LANGUAGESQL))
                {
                    _BLLDatabase.ExecuteQuery(content, out msgEr);
                    if (!string.IsNullOrEmpty(msgEr))
                    {
                        MessageBox.Show(msgEr);
                    }
                    else
                        MessageBox.Show("Lưu thành công", "Meseage");
                    return;
                }
                string filter = _bll_log_StringFilter.Load_Data(language, layer);
                var listFolder = Common.ReadSaveFile.FindFolder(txt_UrlProject.Text, filter);
                if (listFolder.Count > 1 || listFolder.Count == 0)
                {
                    frmShowDirectoryList frm = new frmShowDirectoryList(txt_UrlProject.Text, listFolder, filter, language, layer, fileName, content);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Lưu thành công");
                    }
                }
                else
                {
                    var saveAble = ReadSaveFile.SaveFileToProject(listFolder[0], language, fileName, content, out msgEr);
                    if (!saveAble)
                    {
                        MessageBox.Show(msgEr);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lưu file:" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
            }
        }
        string GetFileName(string language, string layer)
        {
            if (language.Equals(Layer.LANGUAGECSHARP))
            {
                return txt_ClassName.Text + _bll_log_StringFilter.Load_Data(language, layer) + ".cs";
            }
            else if (language.Equals(Layer.LANGUAGESQL))
            {
                return string.Empty;
            }
            else
            {
                if (rad_ViewHTMLA.Checked)
                {
                    return txt_ClassName.Text + txt_Namespace.Text + ".html";
                }
                else
                {
                    return txt_ClassName.Text + txt_Namespace.Text + ".ts";
                }
            }
        }
        void GetLanguageAndLayer(ref string language, ref string layer)
        {
            //get language
            if (rad_Angular.Checked)
                language = Layer.LANGUAGEANGULAR;
            else if (rad_Csharp.Checked)
                language = Layer.LANGUAGECSHARP;
            else
                language = Layer.LANGUAGESQL;
            //get layer
            //csharp
            if (rdb_ViewModel.Checked && rad_Csharp.Checked)
            {
                layer = Layer.MODEL;
            }
            else if (rdb_ControllerAPI.Checked && rad_Csharp.Checked)
            {
                layer = Layer.API;
            }
            else if (rdb_ServiceBLL.Checked && rad_Csharp.Checked)
            {
                layer = Layer.SERVICE;
            }
            else if (rdb_Interface.Checked && rad_Csharp.Checked)
            {
                layer = Layer.INTERFACE;
            }
            else if (rdb_DropDown.Checked && rad_Csharp.Checked)
            {
                layer = Layer.DROPDOWNOPTION;
            }
            else if (rdb_DataAccess.Checked && rad_Csharp.Checked)
            {
                layer = Layer.DATAACCESS;
            }
            else if (rad_Entity.Checked && rad_Csharp.Checked)
            {
                layer = Layer.ENTITY;
            }
            //sql
            else if (rdb_StoreProcedure.Checked && rad_SQL.Checked)
            {
                layer = Layer.STOREPROCEDURE;
            }
            else if (rad_TriggerEvtLog.Checked && rad_SQL.Checked)
            {
                layer = Layer.TRIGGEREVENTLOG;
            }
            //angular
            else if (rad_ViewHTMLA.Checked && rad_Angular.Checked)
            {
                layer = Layer.VIEW;
            }
            else if (rad_ComponentA.Checked && rad_Angular.Checked)
            {
                layer = Layer.COMPONENT;
            }
            else if (rad_ServiceApiA.Checked && rad_Angular.Checked)
            {
                layer = Layer.SERVICE;
            }
            else if (rad_ModelA.Checked && rad_Angular.Checked)
            {
                layer = Layer.MODEL;
            }

        }
        //string GetFilterByLanguageAndLayer(string language,la)
        //{
        //    if (rad_Angular.Checked)
        //        language = Layer.LANGUAGEANGULAR;
        //    else if (rad_Csharp.Checked)
        //        language = Layer.LANGUAGECSHARP;
        //    else
        //        language = Layer.LANGUAGESQL;
        //}
        private void storeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsb_ConFig_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmConFig>().Count() == 0)
            {
                frmConFig frmConFig = new frmConFig();
                frmConFig.Show();
            }
        }

        private void conFigLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsb_ConFig.PerformClick();
        }

        private void tsb_Tutorial_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmTutorial>().Count() == 0)
            {
                frmTutorial frmTutorial = new frmTutorial();
                frmTutorial.Show();
            }

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsb_Save.PerformClick();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tsb_Export.PerformClick();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                rtb_Main.Text = Common.ReadSaveFile.ReadFile(openFileDialog.FileName);
            }

        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Csharp.Checked)
            {
                tabMethod.SelectedTab = tpage_Csharp;

            }

        }

        private void rad_Angular_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Angular.Checked)
            {
                tabMethod.SelectedTab = tpage_Angular;
            }

        }

        private void rad_SQL_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_SQL.Checked)
            {
                tabMethod.SelectedTab = pn_Sql;
            }
        }

        private void txt_UrlProject_DoubleClick(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();

            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                txt_UrlProject.Text = dialog.FileName;
            }
        }

        private void tsb_SaveAll_Click(object sender, EventArgs e)
        {

            this.Invoke(new Action(() =>
             {
                 Thread _saveLogFieldsSelected = new Thread(SaveAll);
                 _saveLogFieldsSelected.IsBackground = true;
                 _saveLogFieldsSelected.Start();
             }));

        }

        void SaveAll()
        {
            Panel panel = null;
            if (rad_Csharp.Checked)
            {
                panel = pn_Csharp;
            }
            else if (rad_Angular.Checked)
            {
                panel = pn_Angular;
            }
            else
            {
                panel = pn_Sql;
            }

            for (int i = 0; i < panel.Controls.Count; i++)
            {
                if (panel.Controls[i].GetType() == rad_Csharp.GetType())
                {
                    ((RadioButton)panel.Controls[i]).Checked = true;
                    tsb_Export.PerformClick();
                    tsb_Save.PerformClick();
                }
            }
        }

        private void mnu_SaveAll_Click(object sender, EventArgs e)
        {
            tsb_SaveAll.PerformClick();
        }

        private void tsb_SaveAllForOne_Click(object sender, EventArgs e)
        {

            int fromTable = cbx_FromTable.SelectedIndex;
            int toTable = cbx_ToTable.SelectedIndex;

            for (int i = fromTable; i <= toTable; i++)
            {
                lbx_Table.SelectedIndex = i;
                tsb_Export.PerformClick();
                tsb_Save.PerformClick();
            }

        }

        private void tsb_ShowDicList_Click(object sender, EventArgs e)
        {
            frmShowDirectoryList frm = new frmShowDirectoryList();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Lưu thành công");
            }
            frm.Dispose();
        }
        string GetDefaultNameSpace()
        {
            var language = string.Empty;
            var layer = string.Empty;
            GetLanguageAndLayer(ref language, ref layer);
            return ConFig.GetFileDefaultNameSpace(layer);
        }
        private void rdb_ViewModel_CheckedChanged(object sender, EventArgs e)
        {
            txt_Namespace.Text = GetDefaultNameSpace();
        }

        private void rdb_ServiceBLL_CheckedChanged(object sender, EventArgs e)
        {
            txt_Namespace.Text = GetDefaultNameSpace();
        }

        private void rdb_DataAccess_CheckedChanged(object sender, EventArgs e)
        {
            txt_Namespace.Text = GetDefaultNameSpace();
        }

        private void rad_Entity_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad_interFaceDAL_CheckedChanged(object sender, EventArgs e)
        {
            txt_Namespace.Text = GetDefaultNameSpace();
        }

        private void rdb_DropDown_CheckedChanged(object sender, EventArgs e)
        {
            txt_Namespace.Text = GetDefaultNameSpace();
        }

        private void rdb_Interface_CheckedChanged(object sender, EventArgs e)
        {
            txt_Namespace.Text = GetDefaultNameSpace();
        }

        private void rdb_ControllerAPI_CheckedChanged(object sender, EventArgs e)
        {
            txt_Namespace.Text = GetDefaultNameSpace();
        }

        private void rad_SProcedure_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_SProcedure.Checked)
            {

                _dataBase = cbx_Database.SelectedItem.ToString();
                var soucrce = _BLLDatabase.GetListStoreProcedure(_dataBase);
                soucrce.Sort();
                if (soucrce.Count != 0)
                {
                    Dictionary<string, int> pairs = new Dictionary<string, int>();
                    foreach (var item in soucrce)
                    {
                        var store = item.Split('-');
                        pairs.Add(store[0], Convert.ToInt32(store[1]));
                    }
                    lbx_Table.DataSource = new BindingSource(pairs, null);
                    lbx_Table.DisplayMember = "Key";
                    lbx_Table.ValueMember = "Value";
                }

            }
        }

        private void rad_View_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rad_Table_CheckedChanged(object sender, EventArgs e)
        {
            if (rad_Table.Checked)
            {
                _dataBase = cbx_Database.SelectedItem.ToString();
                var soucrce = _BLLDatabase.GetTB(_dataBase);
                soucrce.Sort();
                if (soucrce.Count != 0)
                {
                    lbx_Table.DataSource = soucrce;

                    var tasks = new List<Task>();
                    tasks.Add(Task.Run(() =>
                    {
                        cbx_FromTable.Items.Clear();

                        foreach (var item in soucrce)
                        {
                            cbx_FromTable.Items.Add(item);
                        }
                        cbx_FromTable.SelectedIndex = 0;
                    }));
                    tasks.Add(Task.Run(() =>
                    {
                        cbx_ToTable.Items.Clear();
                        foreach (var item in soucrce)
                        {
                            cbx_ToTable.Items.Add(item);
                        }
                        cbx_ToTable.SelectedIndex = cbx_ToTable.Items.Count - 1;
                    }));

                    Task task = Task.WhenAll(tasks);
                }
            }
            return;
        }

        private void tsb_ShowFormSql_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<frmRunQuerySQL>().Count() == 0)
            {
                frmRunQuerySQL frmRunQuerySQL = new frmRunQuerySQL(_BLLDatabase, _dataBase);
                frmRunQuerySQL.Show();
            }
           
            
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
