using BLL;
using BLL.Configuration_storage;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        BLL_AccessDb accessDb;
        public string strConnection;
        BLL_Log_Database_Connection BLL_log_database_connection;
        List<Log_DataBase_Connection> lst_connection;
        public void button1_Click(object sender, EventArgs e)
        {

            string flag = string.Empty;
            accessDb = new BLL_AccessDb();
            string[] s = cbx_server.Text.Split('.');
            strConnection = string.Empty; 
            if (int.TryParse(s[0], out int a))
            {
                strConnection = $"Data Source={cbx_server.Text};Network Library=DBMSSOCN;Initial Catalog=master;User ID={txt_username.Text};Password={ txt_pass.Text};";
                flag = accessDb.ConnectDb(strConnection);
            }
            else if (cbx_authentication.SelectedIndex == 0)
            {
                strConnection = "Data Source=" + cbx_server.Text + ";Database=master;Integrated Security = SSPI;";
                flag = accessDb.ConnectDb(strConnection);
            }
            else
            {
              
                    strConnection = "Server=" + cbx_server.Text + ";Database=master;User Id=" + txt_username.Text + ";Password=" + txt_pass.Text + ";";
               
                   
                flag = accessDb.ConnectDb(strConnection);
            }
            if (flag.Equals("Success"))
            {
                BLL_log_database_connection.Save(cbx_server.Text, txt_username.Text, txt_pass.Text, ckb_RememberPass.Checked);
                DialogResult = DialogResult.OK;

                Close();
            }
            else
            {
                MessageBox.Show(flag);
                return;
            }

        }
        private void Login_Load(object sender, EventArgs e)
        {
            BLL_log_database_connection = new BLL_Log_Database_Connection();
            cbx_authentication.Items.AddRange(new string[] { "Windows Authentication", "SQL Server Authentication" });
            accessDb = new BLL_AccessDb();
            cbx_authentication.SelectedIndex = 0;
            LoadData();

       

        }
        private void cbx_authentication_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbx_authentication.SelectedIndex == 0)
            {
                txt_username.Text = string.Empty; ;
                txt_pass.Text = string.Empty; ;
                txt_username.Enabled = false;
                txt_pass.Enabled = false;
            }
            else
            {
                txt_username.Enabled = true;
                txt_pass.Enabled = true;
            }
        }
        void LoadData()
        {
            lst_connection = new List<Log_DataBase_Connection>();
            BLL_log_database_connection = new BLL_Log_Database_Connection();
            lst_connection = BLL_log_database_connection.Load();
            foreach (var item in lst_connection)
            {
              
                cbx_server.Items.Add(item);
                cbx_server.Tag = item;
                cbx_server.SelectedItem = item;
            }


        }
        private void cbx_server_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbx_authentication.SelectedIndex = 1;
            Log_DataBase_Connection _Connection = cbx_server.SelectedItem as Log_DataBase_Connection;
            txt_username.Text = _Connection.username_e;
            txt_pass.Text = _Connection.password_e;
            ckb_RememberPass.Checked = true;
        }
    }
}
