using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_studyAMS
{
    class Reservation
    {
        private string id;          //预约序号
        private string studentid;     //学号
        private string condition;   //状态：违约，已取消，履约
        private string site;   //位置：包括图书馆+分区+座位号
        private string time;   //时间：包括日期+开始时间+结束时间

        public Reservation(string id, string studentid, string condition, string site, string time)
        {
            this.id = id;
            this.studentid = studentid;
            this.condition = condition;
            this.site = site;
            this.time = time;
        }
        public string Id { get => id; set => id = value; }
        public string Studentid { get => studentid; set => studentid = value; }
        public string Condition { get => condition; set => condition = value; }
        public string Site { get => site; set => site = value; }
        public string Time { get => time; set => time = value; }
    }
}
