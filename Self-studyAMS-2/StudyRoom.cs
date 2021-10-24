using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_studyAMS
{
    class StudyRoom
    {
        private string library;    //图书馆
        private string zone;       //分区
        private string seat;  //座位号
        //以上三个属性确定唯一一个自习室

        private string state; //状态：使用中，可选，有约
        private string date;      //日期
        private string startTime; //开始时间
        private string endTime;   //结束时间

        public StudyRoom(string library, string zone, string seat, string state, string date, string startTime, string endTime)
        {
            this.Library = library;
            this.Zone = zone;
            this.Seat = seat;
            this.State = state;
            this.Date = date;
            this.StartTime = startTime;
            this.EndTime = endTime;
        }

        public string Library { get => library; set => library = value; }
        public string Zone { get => zone; set => zone = value; }
        public string Seat { get => seat; set => seat = value; }
        public string State { get => state; set => state = value; }
        public string Date { get => date; set => date = value; }
        public string StartTime { get => startTime; set => startTime = value; }
        public string EndTime { get => endTime; set => endTime = value; }
    }
}
