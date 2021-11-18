package demo.domain;

public class Reservation {
    private Integer id;          //预约序号
    private String studentId;     //学号
    private String condition;   //状态：违约，已取消，履约
    private String site;   //位置：包括图书馆+分区+座位号
    private String time;   //时间：包括日期+开始时间+结束时间

    public Integer getId() {
        return id;
    }

    public String getStudentId() {
        return studentId;
    }

    public String getCondition() {
        return condition;
    }

    public String getSite() {
        return site;
    }

    public String getTime() {
        return time;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public void setStudentId(String studentId) {
        this.studentId = studentId;
    }

    public void setCondition(String condition) {
        this.condition = condition;
    }

    public void setSite(String site) {
        this.site = site;
    }

    public void setTime(String time) {
        this.time = time;
    }

    @Override
    public String toString() {
        return "Reservation{" +
                "id='" + id + '\'' +
                ", studentId='" + studentId + '\'' +
                ", condition='" + condition + '\'' +
                ", site='" + site + '\'' +
                ", time='" + time + '\'' +
                '}';
    }

    public Reservation(Integer id, String studentId, String condition, String site, String time) {
        this.id = id;
        this.studentId = studentId;
        this.condition = condition;
        this.site = site;
        this.time = time;
    }
}
