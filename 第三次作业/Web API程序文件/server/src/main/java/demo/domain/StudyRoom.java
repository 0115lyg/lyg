package demo.domain;

public class StudyRoom {
    private Integer id;
    private String library;    //图书馆
    private String zone;       //分区
    private String seat;  //座位号
    //以上三个属性确定唯一一个自习室

    private String state; //状态：使用中，可选，有约
    private String date;      //日期
    private String startTime; //开始时间
    private String endTime;   //结束时间

    public Integer getId() {
        return id;
    }

    public String getLibrary() {
        return library;
    }

    public String getZone() {
        return zone;
    }

    public String getSeat() {
        return seat;
    }

    public String getState() {
        return state;
    }

    public String getDate() {
        return date;
    }

    public String getStartTime() {
        return startTime;
    }

    public String getEndTime() {
        return endTime;
    }

    public void setId(Integer id) {
        this.id = id;
    }

    public void setLibrary(String library) {
        this.library = library;
    }

    public void setZone(String zone) {
        this.zone = zone;
    }

    public void setSeat(String seat) {
        this.seat = seat;
    }

    public void setState(String state) {
        this.state = state;
    }

    public void setDate(String date) {
        this.date = date;
    }

    public void setStartTime(String startTime) {
        this.startTime = startTime;
    }

    public void setEndTime(String endTime) {
        this.endTime = endTime;
    }

    @Override
    public String toString() {
        return "StudyRoom{" +
                "id=" + id +
                ", library='" + library + '\'' +
                ", zone='" + zone + '\'' +
                ", seat='" + seat + '\'' +
                ", state='" + state + '\'' +
                ", date='" + date + '\'' +
                ", startTime='" + startTime + '\'' +
                ", endTime='" + endTime + '\'' +
                '}';
    }

    public StudyRoom(Integer id, String library, String zone, String seat, String state, String date, String startTime, String endTime) {
        this.id = id;
        this.library = library;
        this.zone = zone;
        this.seat = seat;
        this.state = state;
        this.date = date;
        this.startTime = startTime;
        this.endTime = endTime;
    }
}
