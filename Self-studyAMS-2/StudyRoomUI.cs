using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_studyAMS
{
    public partial class StudyRoomUI : Form
    {
        public StudyRoomUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form form = new Login();
            this.Hide();
            form.ShowDialog();
            this.Dispose();
            Application.ExitThread();
        }
    }
}
