using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Self_studyAMS
{
    class StudyRoomDaoImpl : IStudyRoomDao
    {
        // 数据库连接
        static string connString = "Host=localhost; Port=5432; Username=postgres; Password=157367qerw; Database=MyDatabase;";
        NpgsqlConnection conn = null;
        NpgsqlCommand cmd = null;
        NpgsqlDataAdapter nda = null;
        public List<string> findAllLibrary() // 查询图书馆
        {
            List<string> library = new List<string>();
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string sql = "select 图书馆 from 自习室记录 group by 图书馆;";
                nda = new NpgsqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                nda.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    library.Add(Convert.ToString(ds.Tables[0].Rows[i]["图书馆"]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询自习室图书馆信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return library;
        }
    
        public List<string> findAllZone(string library) // 根据图书馆查询分区
        {
            List<string> zone = new List<string>();
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string sql = "select 分区 from 自习室记录 where 图书馆 = '{0}' group by 分区;";
                sql = string.Format(sql, library);
                nda = new NpgsqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                nda.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    zone.Add(Convert.ToString(ds.Tables[0].Rows[i]["分区"]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询自习室分区信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return zone;
        }

        public List<string> findAllSeat(string library, string zone) // 根据图书馆和分区查询座位号
        {
            List<string> seat = new List<string>();
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string sql = "select 座位号 from 自习室记录 where 图书馆 = '{0}' and 分区 = '{1}' group by 座位号 order by 座位号;";
                sql = string.Format(sql, library, zone);
                nda = new NpgsqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                nda.Fill(ds);
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    seat.Add(Convert.ToString(ds.Tables[0].Rows[i]["座位号"]));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询自习室座位号信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return seat;
        }

        public string findState(StudyRoom studyRoom) // 根据图书馆，分区，座位号，日期，开始时间，结束时间，查询状态
        {
            string state = "";
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string sql = "select 状态 from 自习室记录 where 图书馆 = '{0}' and 分区 = '{1}' and 座位号 = '{2}' and 日期 = '{3}' and 开始时间 = '{4}' and 结束时间 = '{5}';";
                sql = string.Format(sql, studyRoom.Library, studyRoom.Zone, studyRoom.Seat, studyRoom.Date, studyRoom.StartTime, studyRoom.EndTime); ;
                nda = new NpgsqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                nda.Fill(ds);
                state = Convert.ToString(ds.Tables[0].Rows[0]["状态"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("查询自习室状态信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return state;
        }

        public void updateStudyRoom(StudyRoom studyRoom) // 更新状态
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "update 自习室记录 set 状态='{0}' where 图书馆 = '{1}' and 分区 = '{2}' and 座位号 = '{3}' and 日期 = '{4}' and 开始时间 = '{5}' and 结束时间 = '{6}';";
                sql = string.Format(sql, studyRoom.State,  studyRoom.Library, studyRoom.Zone, studyRoom.Seat, studyRoom.Date, studyRoom.StartTime, studyRoom.EndTime);
                cmd = new NpgsqlCommand(sql, conn);
                int returnvalue = cmd.ExecuteNonQuery();
                if (returnvalue != -1)
                {
                    Console.WriteLine("更新自习室信息成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("更新自习室信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void insertStudyRoom(string library, string zone, string seat) // 增加自习室
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();
                string sql = "insert into 自习室记录 (图书馆,分区,座位号,状态) values ('{0}','{1}','{2}','可选');";
                sql = string.Format(sql, library, zone, seat);
                cmd = new NpgsqlCommand(sql, conn);
                int returnvalue = cmd.ExecuteNonQuery();
                if (returnvalue != -1)
                {
                    Console.WriteLine("插入自习室信息成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("插入自习室信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
        public void deleteStudyRoom(string library, string zone, string seat) // 删除自习室
        {
            try
            {
                conn = new NpgsqlConnection(connString);
                conn.Open();

                string sql = "delete from 自习室记录 where 图书馆 = '{0}' and 分区 = '{1}' and 座位号 = '{2}';";
                sql = string.Format(sql, library, zone, seat);
                cmd = new NpgsqlCommand(sql, conn);
                int returnvalue = cmd.ExecuteNonQuery();
                if (returnvalue != -1)
                {
                    Console.WriteLine("删除自习室信息成功！");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("删除自习室信息失败！" + ex.Message);
            }
            finally
            {
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}
