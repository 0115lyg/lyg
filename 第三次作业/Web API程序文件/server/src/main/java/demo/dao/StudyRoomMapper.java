package demo.dao;

import demo.domain.StudyRoom;
import org.apache.ibatis.annotations.Mapper;
import java.util.List;

@Mapper
public interface StudyRoomMapper {
    public List<String> findAllLibrary(); // 查询图书馆
    public List<String> findAllZone(String library); // 根据图书馆查询分区
    public List<String> findAllSeat(String library, String zone); // 根据图书馆和分区查询座位号
    public String findState(StudyRoom studyRoom); // 根据图书馆，分区，座位号，日期，开始时间，结束时间，查询状态
    public void updateStudyRoom(StudyRoom studyRoom); // 更新状态
    public void insertStudyRoom(String library, String zone, String seat); // 增加自习室
    public void deleteStudyRoom(String library, String zone, String seat); // 删除自习室
}
