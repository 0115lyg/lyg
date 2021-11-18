package demo.dao;

import demo.domain.Reservation;
import org.apache.ibatis.annotations.Mapper;
import java.util.List;

@Mapper
public interface ReservationMapper {
    public List<Reservation> findAllReservation(String studentId); // 查询预约记录
    public void updateReservation(Reservation reservation); // 更新状态
    public void insertReservation(Reservation reservation); // 增加预约记录
    public void deleteReservation(Reservation reservation); // 删除预约记录(管理员)
}
