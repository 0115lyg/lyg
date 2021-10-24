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
    public partial class ReservationUI : Form
    {
        Factory fac = new Factory();
        string studentID = "2010312440123";

        public string StudentID { get => studentID; set => studentID = value; }

        public ReservationUI()
        {
            InitializeComponent();
            label1.Text = StudentID;
            showReservationData();
            showLibrary();
            showDate();
            showTime();
        }

        public ReservationUI(string studentid)
        {
            InitializeComponent();
            StudentID = studentid;
            label1.Text = studentid;
            showReservationData();
            showLibrary();
            showDate();
            showTime();
        }


        private void button1_Click(object sender, EventArgs e) //返回
        {
            Form form = new Login();
            this.Hide();
            form.ShowDialog();
            this.Dispose();
            Application.ExitThread();
        }

        public void addListTitle()//查找表格的表头设置
        {
            listView1.BeginUpdate();

            ColumnHeader ch = new ColumnHeader();//声明表头，并创建对象
            ch.Text = "位置";  //表头的显示名称
            ch.Name = "1";  //表头绑定的code值
            ch.Width = 150;
            listView1.Columns.Add(ch);//添加表头到ListView中

            ColumnHeader ch1 = new ColumnHeader();
            ch1.Text = "时间";
            ch1.Name = "2";
            ch1.Width = 150;
            listView1.Columns.Add(ch1);

            ColumnHeader ch2 = new ColumnHeader();
            ch2.Text = "状态";
            ch2.Name = "3";
            ch2.Width = 60;
            listView1.Columns.Add(ch2); 
        }
        public void showReservationData() // 显示预约记录和预约状态
        {
            ReservationDaoImpl reservationDaoImpl = (ReservationDaoImpl)fac.produce("reservationDaoImpl");
            List<Reservation> reservations = reservationDaoImpl.findAllReservation(StudentID);
            if(reservations.Count == 0)
            {
                return;
            }
            listView1.Items.Clear();
            addListTitle();
            listView1.BeginUpdate();

            foreach (Reservation re in reservations)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = re.Site;
                lvItem.SubItems.Add(re.Time);
                lvItem.SubItems.Add(re.Condition);
                listView1.Items.Add(lvItem);
            }
            listView1.EndUpdate();

            string state = reservations[reservations.Count - 1].Condition;
            if(state == "违约" || state == "已取消" || state == "履约")
            {
                label2.Text = "暂无预约";
            }
            else if (state == "有约")
            {
                label2.Text = "已有预约";
            }
        }
        public void showLibrary() // 显示图书馆
        {
            StudyRoomDaoImpl studyRoomDaoImpl = (StudyRoomDaoImpl)fac.produce("studyRoomDaoImpl");
            List<string> library = studyRoomDaoImpl.findAllLibrary();
            foreach(string s in library)
            {
                listBox1.Items.Add(s);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) // 显示区域
        {
            listBox2.Items.Clear();
            StudyRoomDaoImpl studyRoomDaoImpl = (StudyRoomDaoImpl)fac.produce("studyRoomDaoImpl");
            if (listBox1.SelectedItem != null)
            {
                List<string> zone = studyRoomDaoImpl.findAllZone(listBox1.SelectedItem.ToString());
                foreach (string s in zone)
                {
                    listBox2.Items.Add(s);
                }
                listBox3.Items.Clear();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e) // 显示座位号
        {
            listBox3.Items.Clear();
            StudyRoomDaoImpl studyRoomDaoImpl = (StudyRoomDaoImpl)fac.produce("studyRoomDaoImpl");
            if (listBox1.SelectedItem != null && listBox2.SelectedItem != null)
            {
                List<string> seat = studyRoomDaoImpl.findAllSeat(listBox1.SelectedItem.ToString(), listBox2.SelectedItem.ToString());
                foreach (string s in seat)
                {
                    listBox3.Items.Add(s);
                }
            }
        }
        public void showDate() // 显示日期
        {
            string date = null;
            for (int i = 1; i <= 5; i++)
            {
                date = DateTime.Today.AddDays(i).ToShortDateString();
                date = date.Replace("/", "-");
                comboBox1.Items.Add(date);
            }

        }
        public void showTime() // 显示可选时间段
        {
            comboBox2.Items.Add("8:00-11:30");
            comboBox2.Items.Add("14:00-17:30");
            comboBox2.Items.Add("19:00-22:30");
        }
        private void button2_Click(object sender, EventArgs e) // 取消预约
        {

        }
        private void button3_Click(object sender, EventArgs e) // 确定预约
        {
            if(listBox1.SelectedItem==null|| listBox2.SelectedItem == null|| listBox3.SelectedItem == null || comboBox1.SelectedItem == null || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("请选择预约地点和时间！");
                return;
            }
            Reservation reservation = (Reservation)fac.produce("reservation");
            StudyRoom studyRoom = (StudyRoom)fac.produce("studyRoom");
            ReservationDaoImpl reservationDaoImpl = (ReservationDaoImpl)fac.produce("reservationDaoImpl");
            StudyRoomDaoImpl studyRoomDaoImpl = (StudyRoomDaoImpl)fac.produce("studyRoomDaoImpl");
            studyRoom.Library = listBox1.SelectedItem.ToString();
            studyRoom.Zone = listBox2.SelectedItem.ToString();
            studyRoom.Seat = listBox3.SelectedItem.ToString();
            studyRoom.Date = comboBox1.SelectedItem.ToString();
            string[] times = comboBox2.SelectedItem.ToString().Split('-');
            studyRoom.StartTime = times[0];
            studyRoom.EndTime = times[1];
            string state = studyRoomDaoImpl.findState(studyRoom);
            if(state == "可选")
            {
                studyRoom.State = "有约";
                studyRoomDaoImpl.updateStudyRoom(studyRoom);

                reservation.Studentid = StudentID;
                reservation.Condition = "有约";
                reservation.Site = studyRoom.Library + studyRoom.Zone + studyRoom.Seat + "号";
                reservation.Time = studyRoom.Date + " " + comboBox2.SelectedItem.ToString();
                reservationDaoImpl.insertReservation(reservation, this);
            }
            else if(state == "有约")
            {
                MessageBox.Show("抱歉，该时间段已被预约！");
            }
        }
    }
}
