using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Self_studyAMS
{
    interface IStudyRoomDao
    {
        // 查询图书馆
        List<string> findAllLibrary();

        // 根据图书馆查询分区
        List<string> findAllZone(string library);

        // 根据图书馆和分区查询座位号
        List<string> findAllSeat(string library, string zone);

        // 根据图书馆，分区，座位号，日期，开始时间，结束时间，查询状态
        string findState(StudyRoom studyRoom);


        // 更新状态
        void updateStudyRoom(StudyRoom studyRoom);
        
        
        // 增加自习室
        void insertStudyRoom(string library, string zone, string seat);
        // 删除自习室
        void deleteStudyRoom(string library, string zone, string seat);
    }
}
