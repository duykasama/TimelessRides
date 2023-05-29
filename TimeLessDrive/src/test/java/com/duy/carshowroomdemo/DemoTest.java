package com.duy.carshowroomdemo;

import com.duy.carshowroomdemo.dto.ClientDto;
import com.duy.carshowroomdemo.dto.OffMeetingDto;
import com.duy.carshowroomdemo.dto.StaffDto;
import com.duy.carshowroomdemo.entity.*;
import com.duy.carshowroomdemo.mapper.MapperManager;
import com.duy.carshowroomdemo.repository.*;
import com.duy.carshowroomdemo.util.Util;
import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.Test;
import org.modelmapper.ModelMapper;
import org.modelmapper.convention.MatchingStrategies;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.jdbc.AutoConfigureTestDatabase;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.test.annotation.Rollback;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;


@DataJpaTest
@AutoConfigureTestDatabase(replace = AutoConfigureTestDatabase.Replace.NONE)
@Rollback(value = false)
public class DemoTest {
    @Autowired
    private CarRepository carRepository;
    @Autowired
    private InvoiceRepository invoiceRepository;
    @Autowired
    private AdminRepository adminRepository;
    @Autowired
    private CarDescriptionRepository carDescriptionRepository;
    @Autowired
    private CarImageRepository carImageRepository;
    @Autowired
    private ClientRepository clientRepository;
    @Autowired
    private FeedbackRepository feedbackRepository;
    @Autowired
    private OffMeetingRepository offMeetingRepository;
    @Autowired
    private PostRepository postRepository;
    @Autowired
    private ShowroomRepository showroomRepository;
    @Autowired
    private StaffRepository staffRepository;

    public final String AVATAR_URL = "https://icon-library.com/images/anonymous-avatar-icon/anonymous-avatar-icon-25.jpg";
    public final String CAR_IMAGE_URL = "https://images.unsplash.com/photo-1502877338535-766e1452684a?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=872&q=80";

    @Test
    public void testAddData(){
        testAddAdmin();
        testAddShowroom();
        testAddStaff();
        testAddClient();
        testAddCarDescription();
        testAddCar();
        testAddCarImage();
        testAddPost();
        testAddInvoice();
        testAddOffMeeting();
        testAddFeedback();
    }

    @Test
    public void testAddShowroom(){
        for (int i = 1; i < 5; i++) {
            Showroom showroom = new Showroom();
            showroom.setName("Showroom " + i);
            showroom.setAddress("123 sample address");
            showroom.setCity("Thai Nguyen");
            showroom.setPhone(Util.getRandPhone());
            Showroom save = showroomRepository.save(showroom);

            Assertions.assertThat(save).isNotNull();
        }
    }

    @Test
    public void testAddStaff(){
        for (int i = 0; i < 100; i++) {
            List<Showroom> showroomList = new ArrayList<>();
            showroomRepository.findAll().forEach(showroomList::add);
            Staff staff = new Staff();
            staff.setRole("staff");
            staff.setName(Util.getRandName());
            staff.setAvatar(AVATAR_URL);
            staff.setPhone(Util.getRandPhone());
            staff.setGender(Util.getRandGender());
            staff.setPassword(Util.encodePassword("password123"));
            staff.setAddress("123 sample address");
            staff.setDob(Util.getRandDate(LocalDate.of(1980,1,1), LocalDate.of(2000,12,31)));
            staff.setEmail(Util.getRandEmail(staff.getName() , staff.getDob()));
            staff.setJoinDate(Util.getRandDate(LocalDate.of(2020,1,1), LocalDate.now()));
            staff.setShowroom(showroomList.get(Util.getRandInt(showroomList.size())));

            Staff save = staffRepository.save(staff);
            Assertions.assertThat(save).isNotNull();
        }
        Staff staff = new Staff();
        List<Showroom> showroomList = new ArrayList<>();
        showroomRepository.findAll().forEach(showroomList::add);
        staff.setRole("staff");
        staff.setName(Util.getRandName());
        staff.setAvatar(AVATAR_URL);
        staff.setEmail("duy@gmail.com");
        staff.setPhone(Util.getRandPhone());
        staff.setGender("male");
        staff.setPassword(Util.encodePassword("123"));
        staff.setAddress("123 sample address");
        staff.setDob(Util.getRandBirthDay());
        staff.setJoinDate(LocalDate.now());
        staff.setShowroom(showroomList.get(Util.getRandInt(showroomList.size())));

        Staff save = staffRepository.save(staff);
        Assertions.assertThat(save).isNotNull();


    }

    @Test
    public void testAddAdmin(){
        Admin admin = new Admin();
        admin.setEmail("hai@gmail.com");
        admin.setAvatar(AVATAR_URL);
        admin.setRole("admin");
        admin.setPassword(Util.encodePassword("123"));
        admin.setName("hai");
        adminRepository.save(admin);
    }

    @Test
    public void testAddClient(){
        for (int i = 0; i < 100; i++) {
            Client client = new Client();
            client.setRole("client");
            client.setName(Util.getRandName());
            client.setAvatar(AVATAR_URL);
            client.setPhone(Util.getRandPhone());
            client.setPassword(Util.encodePassword("password123"));
            client.setAddress("123 sample address");
            client.setGender(Util.getRandGender());
            client.setDob(Util.getRandDate(LocalDate.of(1980,1,1), LocalDate.of(2000,12,31)));
            client.setEmail(Util.getRandEmail(client.getName(), client.getDob()));
            client.setJoinDate(Util.getRandDate(LocalDate.of(2020,1,1), LocalDate.now()));
            client.setTax("I dont know this field");

            Client save = clientRepository.save(client);

            Assertions.assertThat(save).isNotNull();
        }
    }

    @Test
    public void testAddCarDescription(){
        for (int i = 0; i < 100; i++) {
            CarDescription carDescription = new CarDescription();
            carDescription.setColor(Util.getRandColor());
            carDescription.setFuelType(Util.getRandFuelType());
            carDescription.setNoOfSeat((short) Util.getRandInt(4,8));
            carDescription.setHp((short) (Util.getRandInt(1800) + 200));
            carDescription.setWheelSize((short) (Util.getRandInt(35) + 35));
            carDescription.setBoughtYear((short) (Util.getRandInt(30) + 1990));
            carDescription.setWidth((short) (Util.getRandInt(50) + 150));
            carDescription.setLength((short) (Util.getRandInt(50) + 400));
            carDescription.setHeight((short) (Util.getRandInt(10) + 175));
            carDescription.setKmSpend("i dont know this field");
            carDescription.setManufacturedYear((short) (carDescription.getBoughtYear() - Util.getRandInt(5)));
            carDescription.setOthers(Util.getRandText(30));
            CarDescription save = carDescriptionRepository.save(carDescription);

            Assertions.assertThat(save).isNotNull();
        }
    }

    @Test
    public void testAddCar(){
        List<CarDescription> carDescriptionList = new ArrayList<>();
        carDescriptionRepository.findAll().forEach(carDescriptionList::add);
        List<Showroom> showroomList = new ArrayList<>();
        showroomRepository.findAll().forEach(showroomList::add);
        carDescriptionList.forEach((x) -> {
            Car car = new Car();
            car.setCarDescription(x);
            car.setShowroom(showroomList.get(Util.getRandInt(showroomList.size())));
            car.setName(Util.getRandCarName());
            car.setBrand(Util.getRandBrand());
            car.setPrice(Util.getRandPrice());
            car.setStatus("Available");

            Car save = carRepository.save(car);

            Assertions.assertThat(save).isNotNull();
        });
    }

    @Test
    public void testAddCarImage(){
        for (int i = 0; i < 300; i++) {
            List<Car> carList = new ArrayList<>();
            carRepository.findAll().forEach(carList::add);
            CarImage carImage = new CarImage();
            carImage.setCar(carList.get(Util.getRandInt(carList.size())));
            carImage.setLink(CAR_IMAGE_URL);

            CarImage save = carImageRepository.save(carImage);

            Assertions.assertThat(save).isNotNull();
        }
    }

    @Test
    public void testAddPost(){
        List<Car> carList = new ArrayList<>();
        carRepository.findAll().forEach(carList::add);
        List<Client> clientList = new ArrayList<>();
        clientRepository.findAll().forEach(clientList::add);


        carList.forEach(x -> {
            Post post = new Post();
            post.setCar(x);
            post.setClient(clientList.get(Util.getRandInt(clientList.size())));
            post.setDescription(Util.getRandText(30));
            post.setStatus("Pending");
            post.setCreatedAt(Util.getRandDate(LocalDate.of(2019,1,1), LocalDate.of(2021,12,31)));

            Post save = postRepository.save(post);

            Assertions.assertThat(save).isNotNull();
        });
    }

    @Test
    public void testAddInvoice(){

        List<Staff> staffList = new ArrayList<>();
        staffRepository.findAll().forEach(staffList::add);
        List<Client> clientList = new ArrayList<>();
        clientRepository.findAll().forEach(clientList::add);
        List<Car> carList = new ArrayList<>();
        carRepository.findAll().forEach(carList::add);
        Invoice invoice = new Invoice();

        carList.forEach(x -> {
            invoice.setStaff(staffList.get(Util.getRandInt(staffList.size())));
            invoice.setClient(clientList.get(Util.getRandInt(clientList.size())));
            invoice.setCar(x);
            invoice.setTotal(Util.getRandPrice());
            invoice.setCreatedAt(Util.getRandDate(LocalDate.of(2020,1,1), LocalDate.now()));
            invoice.setStatus("Paid");

            Invoice save = invoiceRepository.save(invoice);

            Assertions.assertThat(save).isNotNull();
        });
    }

    @Test
    public void testAddOffMeeting(){
        for (int i = 0; i < 100; i++) {
            List<Staff> staffList = new ArrayList<>();
            staffRepository.findAll().forEach(staffList::add);
            List<Client> clientList = new ArrayList<>();
            clientRepository.findAll().forEach(clientList::add);
            OffMeeting offMeeting = new OffMeeting();
            offMeeting.setStaff(staffList.get(Util.getRandInt(staffList.size())));
            offMeeting.setClient(clientList.get(Util.getRandInt(clientList.size())));
            offMeeting.setMeetingDate(Util.getRandDate(LocalDate.of(2023, 7,1), LocalDate.of(2023, 9,1)));
            offMeeting.setCreatedAt(Util.getRandDate(LocalDate.of(2023, 5,20), LocalDate.now()));
            offMeeting.setDescription(Util.getRandText(30));
            offMeeting.setStatus("Not yet");

            OffMeeting save = offMeetingRepository.save(offMeeting);

            Assertions.assertThat(save).isNotNull();
        }
    }

    @Test
    public void testAddFeedback(){
        for (int i = 0; i < 100; i++) {
            List<Client> clientList = new ArrayList<>();
            clientRepository.findAll().forEach(clientList::add);
            Feedback feedback = new Feedback();
            feedback.setClient(clientList.get(Util.getRandInt(clientList.size())));
            feedback.setCreatedAt(Util.getRandDate(LocalDate.of(2022,1,1), LocalDate.now()));
            feedback.setDescription(Util.getRandText(30));

            Feedback save = feedbackRepository.save(feedback);

            Assertions.assertThat(save).isNotNull();
        }

    }

    @Test
    public void testDeleteStaff(){
        staffRepository.deleteAll();
    }

    @Test
    public void testDeleteCar(){
        List<Car> carList = new ArrayList<>();
        Iterable<Car> all = carRepository.findAll();
        all.forEach(carList::add);
        Car car = carList.get(0);
        System.out.println(car.getCarDescription().getColor());
        carRepository.delete(car);
        Iterable<Car> all1 = carRepository.findAll();

        Assertions.assertThat(all1).isEmpty();

    }

    @Test
    public void testLoadInvoice(){
        invoiceRepository.save(new Invoice());
        List<Invoice> invoiceList = new ArrayList<>();
        invoiceRepository.findAll().forEach(invoiceList::add);
//        invoiceList.get(0).setCar(new Car());
        Invoice save = invoiceRepository.save(invoiceList.get(0));
        Assertions.assertThat(save).isNotNull();
    }

    @Test
    public void testLoadCar(){
        Car car = carRepository.findById("1").get();
        Assertions.assertThat(car).isNotNull();
    }

    @Test
    public void testArray(){
        List<Integer> list = new ArrayList<>();
        for (int i = 0; i < 5; i++) {
            Scanner scanner = new Scanner(System.in);
            list.set(i, scanner.nextInt());
        }
        list.forEach(x-> System.out.println(x));
    }

    @Test
    public void testMapper(){
        ModelMapper modelMapper = new ModelMapper();
        modelMapper.getConfiguration().setMatchingStrategy(MatchingStrategies.LOOSE);
        List<OffMeetingDto> offMeetingDtoList = new ArrayList<>();

        offMeetingRepository.findAll().forEach(x -> {
            OffMeetingDto offMeetingDto = modelMapper.map(x, OffMeetingDto.class);
            offMeetingDto.setClient(modelMapper.map(x.getClient(), ClientDto.class));
            offMeetingDto.setStaff(modelMapper.map(x.getStaff(), StaffDto.class));
            offMeetingDtoList.add(offMeetingDto);
        });

        Assertions.assertThat(offMeetingDtoList).isNotEmpty();

        OffMeetingDto offMeetingDto = offMeetingDtoList.get(0);

        System.out.println(offMeetingDto.getClient() + offMeetingDto.getMeetingDate().toString() + offMeetingDto.getDescription()
                            + offMeetingDto.getStatus() + offMeetingDto.getStaff()
        );

    }

    @Test
    public void testMappers(){
        MapperManager mapperManager = new MapperManager();
        Client client = clientRepository.findById("55").get();
        ClientDto dto = mapperManager.getClientMapper().toDto(client);
        Client entity = mapperManager.getClientMapper().toEntity(dto);

        List<OffMeetingDto> offMeetingDtoList = new ArrayList<>();

        offMeetingRepository.findOffMeetingsByClient(entity).forEach(x -> {
            offMeetingDtoList.add(mapperManager.getOffMeetingMapper().toDto(x));
        });

        offMeetingDtoList.forEach(x -> System.out.println(x.toString()));


    }

    @Test
    public void testLogin(){
//        offMeetingRepository.findAll(Sort.by("meetingDate")).forEach(x -> System.out.println(x.getMeetingDate()));
//        offMeetingRepository.findAll(PageRequest.of(1, 10), Sort.by("meetingDate")).forEach(x -> System.out.println(x.getMeetingDate()));
        System.out.println("==========================================================");
        Util.writeRandomParagraph(10000);

//        PageImpl page = new PageImpl<>(offMeetingRepository.findAll(), PageRequest.of(0, 10), offMeetingRepository.count());
////        System.out.println(page.getTotalElements());
////        System.out.println(page.getTotalPages());
//        offMeetingRepository.findAll(page.nextPageable()).forEach(x -> System.out.println(x.getMeetingDate()));
//        page = new PageImpl(page.getContent(), page.nextPageable(), page.getTotalElements());
//        offMeetingRepository.findAll(page.nextPageable()).forEach(x -> System.out.println(x.getMeetingDate()));



//        System.out.println("==========================================================");
//        offMeetingRepository.findAll(page.nextPageable()).forEach(x -> System.out.println(x.getMeetingDate()));




//        offMeetingRepository.findAll(PageRequest.of(0, 10)).forEach(x -> System.out.println(x.getMeetingDate()));
//        offMeetingRepository.findAll(PageRequest.of(0, 10, Sort.Direction.ASC, "meetingDate")).forEach(x -> System.out.println(x.getMeetingDate()));
//        System.out.println("==========================================================");
//        offMeetingRepository.findAll(PageRequest.of(, 10, Sort.by("meetingDate"))).forEach(x -> System.out.println(x.getMeetingDate()));
    }
    @Test
    public void testADd(){
        Client client = new Client();
        client.setRole("client");
        client.setName(Util.getRandName());
        client.setAvatar(AVATAR_URL);
        client.setPhone(Util.getRandPhone());
        client.setPassword(Util.encodePassword("password123"));
        client.setAddress("123 sample address");
        client.setGender(Util.getRandGender());
        client.setDob(Util.getRandDate(LocalDate.of(1980,1,1), LocalDate.of(2000,12,31)));
        client.setEmail("hai123@gmail.com");
        client.setJoinDate(Util.getRandDate(LocalDate.of(2020,1,1), LocalDate.now()));
        client.setTax("I dont know this field");

        Client save = clientRepository.save(client);

        Assertions.assertThat(save).isNotNull();
    }

}
