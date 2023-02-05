using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InformationSystem
{
    public partial class AuForm : Form
    {
        public AuForm()
        {
            InitializeComponent(); ;
            PassField.PasswordChar = '*';
            DB db = new DB();
            try
            {
                db.openConnection();
                db.closeConnection();
            }
            catch(SqlException)
            {
                db.closeConnection();
                Application.Exit();
            }

        }

        private void showPass_CheckedChanged(object sender, EventArgs e)
        {
            if (showPass.Checked)
            {
                PassField.PasswordChar = '\0';
            }
            else
            {
                PassField.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (LoginField.Text == "")
                {
                    MessageBox.Show("Вы не ввели логин!");
                    return;
                }
                else if (PassField.Text == "")
                {
                    MessageBox.Show("Вы не ввели пароль!");
                    return;
                }
                String loginUser = LoginField.Text;
                String passUser = PassField.Text;
                DB db = new DB();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login`= @uL AND `password` = @uP", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;
                adapter.SelectCommand = command;
                adapter.Fill(table);
                if (table.Rows.Count > 0)
                {
                    if (Convert.ToInt32(table.Rows[0][3]) == (int)Role.Admin)
                    {
                        this.Hide();
                        AdminForm adF = new AdminForm();
                        adF.Show();
                    }
                    else if (Convert.ToInt32(table.Rows[0][3]) == (int)Role.HR)
                    {
                        this.Hide();
                        HRForm hr = new HRForm();
                        hr.Show();
                    }
                }
                else
                    MessageBox.Show("Неверно введен логин или пароль!");
            }
            catch { return; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
