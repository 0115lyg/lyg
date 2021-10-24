using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Self_studyAMS
{
    class ReservationDaoImpl : IReservationDao
    {
        Factory fac = new Factory();
        // 数据库连接
        static string connString = "Host=localhost; Port=5432; Username=postgres; Password=157367qerw; Database=MyDatabase;";
        NpgsqlConnection conn = null;
        NpgsqlCommand cmd = null;
        NpgsqlDataAdapter nda = null;


        public List<Reservation> findAllReservation(string studentidid) // 查询预约记录
        {
            List<Reservation> reservations = new List<Reservation>();
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string sql = "select * from 预约记录 where 学号 = '{0}' order by 预约序号;";
                sql = string.Format(sql, studentidid);
                nda = new NpgsqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                nda.Fill(ds);
                for(int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    Reservation reservation = (Reservation)fac.produce("reservation");
                    reservation.Id = Convert.ToString(ds.Tables[0].Rows[i]["预约序号"]);
                    reservation.Studentid = studentidid;
                    reservation.Condition = Convert.ToString(ds.Tables[0].Rows[i]["状态"]);
                    reservation.Site = Convert.ToString(ds.Tables[0].Rows[i]["位置"]);
                    reservation.Time = Convert.ToString(ds.Tables[0].Rows[i]["时间"]);
                    reservations.Add(reservation);
                    //Console.WriteLine(reservation.Id + "," + reservation.Studentid + "," + reservation.Condition + "," + reservation.Site + "," + reservation.Time);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询预约记录信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return reservations;
        }

        public void updateReservation(Reservation reservation) // 更新状态
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "update 预约记录 set 状态='{0}' where 预约序号 = '{1}';";
                sql = string.Format(sql, reservation.Condition, reservation.Id);
                cmd = new NpgsqlCommand(sql, conn);
                int returnvalue = cmd.ExecuteNonQuery();
                if (returnvalue != -1)
                {
                    Console.WriteLine("更新预约记录信息成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("更新预约记录信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void insertReservation(Reservation reservation, Form form) // 增加预约记录
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "insert into 预约记录 (学号,状态,位置,时间) values ('{0}','{1}','{2}','{3}');";
                sql = string.Format(sql, reservation.Studentid, reservation.Condition, reservation.Site, reservation.Time);
                cmd = new NpgsqlCommand(sql, conn);
                int returnvalue = cmd.ExecuteNonQuery();
                if (returnvalue != -1)
                {
                    Console.WriteLine("增加预约记录信息成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("增加预约记录信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            notifyAllObservers(reservation, form);
        }

        public void deleteReservation(Reservation reservation) // 删除预约记录(管理员)
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "delete from 预约记录 where 预约序号 = '{0}'; ";
                sql = string.Format(sql, reservation.Id);
                cmd = new NpgsqlCommand(sql, conn);
                int returnvalue = cmd.ExecuteNonQuery();
                if (returnvalue != -1)
                {
                    Console.WriteLine("删除预约记录信息成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除预约记录信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void notifyAllObservers(Reservation reservation, Form form)
        {
            ReservationUI reservationUI = (ReservationUI)fac.produce("reservationUI");
            reservationUI.StudentID = reservation.Studentid;
            form.Hide();
            reservationUI.ShowDialog();
            form.Dispose();
            Application.ExitThread();
        }
    }
}
