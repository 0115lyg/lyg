package demo.controller;

import demo.dao.StudyRoomMapper;
import demo.domain.StudyRoom;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

@Controller
public class StudyRoomController {

    @Autowired
    private StudyRoomMapper studyRoomMapper;

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/library")
    @ResponseBody
    public List<String> findAllLibrary(){
        List<String> librarys = studyRoomMapper.findAllLibrary();
        return librarys;
    }

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/zone")
    @ResponseBody
    public List<String> findAllZone(String library){
        List<String> zones = studyRoomMapper.findAllZone(library);
        return zones;
    }

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/seat")
    @ResponseBody
    public List<String> findAllSeat(String library, String zone){
        List<String> seat = studyRoomMapper.findAllSeat(library, zone);
        return seat;
    }

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/state")
    @ResponseBody
    public String findState(){
        StudyRoom studyRoom = new StudyRoom(10,"信息馆","1F创客空间","001","可选","2021-10-25","8:00","11:30");
        String state = studyRoomMapper.findState(studyRoom);
        return state;
    }

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/update/state")
    @ResponseBody
    public void updateStudyRoom(){
        StudyRoom studyRoom = new StudyRoom(10,"信息馆","1F创客空间","001","可选","2021-10-25","8:00","11:30");
        studyRoomMapper.updateStudyRoom(studyRoom);
    }

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/insert/StudyRoom")
    @ResponseBody
    public void insertStudyRoom(){
        studyRoomMapper.insertStudyRoom("信息馆","1F创客空间","011");
    }

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/delete/StudyRoom")
    @ResponseBody
    public void deleteStudyRoom(){
        studyRoomMapper.deleteStudyRoom("信息馆","1F创客空间","011");
    }
}
