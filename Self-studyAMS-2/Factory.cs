using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_studyAMS
{
    class Factory : IFactory
    {
        public object produce(string name)
        {
            string studentID = "";
            object production = null;
            switch (name) {
                case "reservation":
                    production = new Reservation("", "", "", "", "");
                    break;
                case "studyRoom":
                    production = new StudyRoom("", "", "", "", "", "", "");
                    break;
                case "reservationDaoImpl":
                    production = new ReservationDaoImpl();
                    break;
                case "studyRoomDaoImpl":
                    production = new StudyRoomDaoImpl();
                    break;
                case "reservationUI":
                    production = new ReservationUI(studentID);
                    break;
                case "studyRoomUI":
                    production = new StudyRoomUI();
                    break;
                default:
                    production = null;
                    break;
            }
            return production;
        }
    }
    
}
