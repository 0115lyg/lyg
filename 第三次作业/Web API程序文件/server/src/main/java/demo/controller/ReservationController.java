package demo.controller;

import demo.dao.ReservationMapper;
import demo.domain.Reservation;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;

import java.util.List;

@Controller
public class ReservationController {
    @Autowired
    private ReservationMapper reservationMapper;

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/reservation")
    @ResponseBody
    public List<Reservation> findAllReservation(){
        List<Reservation> reservations = reservationMapper.findAllReservation("2010312440123");
        return reservations;
    }
    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/update/reservation")
    @ResponseBody
    public void updateReservation(){
        Reservation reservation = new Reservation(4,"2010312440123","违约","总馆2F座位区004号","2021-10-23 19:30-20:00");
        reservationMapper.updateReservation(reservation);
    }
    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/insert/reservation")
    @ResponseBody
    public void insertReservation(){
        Reservation reservation = new Reservation(5,"2010312440123","违约","总馆2F座位区004号","2021-11-16 19:30-20:00");
        reservationMapper.insertReservation(reservation);

    }

    @CrossOrigin(origins = "*", maxAge = 3600)
    @RequestMapping("/delete/reservation")
    @ResponseBody
    public void deleteReservation(){
        Reservation reservation = new Reservation(5,"2010312440123","违约","总馆2F座位区004号","2021-11-16 19:30-20:00");
        reservationMapper.deleteReservation(reservation);
    }
}
