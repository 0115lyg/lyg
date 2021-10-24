using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Self_studyAMS
{
    public partial class Login : Form
    {
        static string connString = "Host=localhost; Port=5432; Username=postgres; Password=157367qerw; Database=MyDatabase;";
        NpgsqlConnection conn = null;
        NpgsqlDataAdapter nda = null;
        public Login()
        {
            InitializeComponent();
        }

        private void loginbtn_Click(object sender, EventArgs e)
        {
            string account = textBox1.Text;
            string password = textBox2.Text;
            bool judgeAccount = false;
            bool judgePassword = false;
            string studentid = null;
            Form form = null;

            DataSet ds = new DataSet();
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "select * from 预约账号;";
                nda = new NpgsqlDataAdapter(sql, conn);
                nda.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show("查询失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                    conn.Close();
            }

            if (radioButton1.Checked)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    string tmp = Convert.ToString(ds.Tables[0].Rows[i]["账号"]);
                    string tmp1 = Convert.ToString(ds.Tables[0].Rows[i]["密码"]);
                    if (account == tmp)
                    {
                        if (password == tmp1)
                        {
                            studentid = Convert.ToString(ds.Tables[0].Rows[i]["学号"]);
                            judgeAccount = true;
                            judgePassword = true;
                            break;
                        }
                        judgeAccount = true;
                    }
                }
                if (judgeAccount)
                {
                    if (judgePassword)
                    {
                        form = new ReservationUI(studentid);
                    }
                    else
                        MessageBox.Show("学生密码错误");
                }
                else
                    MessageBox.Show("学生账号错误");
            }
            else if (radioButton2.Checked)
            {
                if (account == "admin")
                {
                    if (password == "123456")
                    {
                        form = new StudyRoomUI();
                    }
                    else
                        MessageBox.Show("管理员密码错误");
                }
                else
                    MessageBox.Show("管理员账号错误");
            }
            else
            {
                MessageBox.Show("请选择学生或者管理员");
                return;
            }

            if (form != null)
            {
                this.Hide();
                form.ShowDialog();
                this.Dispose();
                Application.ExitThread();
            }
        }

        private void logoutbtn_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
            Application.ExitThread();
        }
    }
}
