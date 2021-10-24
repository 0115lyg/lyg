using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Self_studyAMS
{
    interface IReservationDao
    {
        // 查询预约记录
        List<Reservation> findAllReservation(string studentidid);

        // 更新状态
        void updateReservation(Reservation reservation);

        // 增加预约记录
        void insertReservation(Reservation reservation, Form form);

        // 删除预约记录(管理员)
        void deleteReservation(Reservation reservation);
    }
}
