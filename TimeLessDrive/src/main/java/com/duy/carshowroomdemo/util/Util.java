package com.duy.carshowroomdemo.util;

import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;

import java.io.*;
import java.time.LocalDate;
import java.util.Random;
import java.util.concurrent.ThreadLocalRandom;

public class Util {
    static Random random = new Random();
    static BCryptPasswordEncoder passwordEncoder= new BCryptPasswordEncoder();
    public static String getRandPhone(){
        String phone = "09";


        for (int i = 0; i < 8; i++) {
            phone += random.nextInt(10);
        }

        return phone;
    }

    public static String getRandEmail(String name, LocalDate dob) {
        String[] s = name.split(" ");
        String[] d = dob.toString().split("-");
        return s[2] + s[0].charAt(0) + s[1].charAt(0) + d[2] + d[1] + "@gmail.com";
    }

    public static String getRandGender(){
        return (random.nextInt(2) == 0) ? "male":"female";
    }

    public static int getRandInt(int upperBound) {
        return random.nextInt(upperBound);
    }

    public static String getRandName() {
        String[] lastNames = {"Nguyen", "Cao", "Doan", "Dang", "Le", "Tran", "Pham", "Duong", "Dinh", "Ha"};
        String[] middleNames = {"Quoc", "Huynh", "Hoang", "Thanh", "Binh", "Huu", "Hong", "Thi", "Ngoc", "Minh"};
        String[] firstNames = {"Thai", "Kiet", "Khoi", "Huan", "Long", "Nhat", "Dat", "Tri", "Quan", "Khang"};
        return lastNames[getRandInt(lastNames.length)] + " " + middleNames[getRandInt(middleNames.length)] + " " + firstNames[getRandInt(firstNames.length)];
    }

    public static String getRandColor() {
        String[] colors = {"red", "blue", "yellow", "white", "black", "brown", "violet", "emerald", "green", "pink"};
        return colors[getRandInt(colors.length)];
    }

    public static String getRandFuelType() {
        String[] fuelTypes = {"Diesel", "Gasoline", "Bio-diesel", "Ethanol"};
        return fuelTypes[getRandInt(fuelTypes.length)];
    }

    public static String getRandCarName() {
        String[] carNames = {"BOLT EV", "TRAX", "TRAILBLAZER", "EQUINOX", "BLAZER", "TRAVERSE", "TAHOE", "2024 Mustang", "Escape", "Bronco Sport", "Explorer", "Expedition"};
        return carNames[getRandInt(carNames.length)];
    }

    public static String getRandBrand() {
        String[] brands = {"Chevy", "Ford", " Volkswagen Beetel", "Cadilac", "Corolla", "Herbie", "", "Mitsubishi", "Camry", "Alfa Romeo", "Toyota", "Ferrari", "Kia"};
        return brands[Util.getRandInt(brands.length)];
    }

    public static Long getRandPrice() {
        return (getRandInt(4500) + 500) * 1000000L;
    }

    public static int getRandInt(int lowerBound, int upperBound) {
        return getRandInt(upperBound - lowerBound) + lowerBound;
    }

    public static LocalDate getRandBirthDay(){
        LocalDate date1 = LocalDate.of(1980, 1, 1);
        LocalDate date2 = LocalDate.of(2000, 1, 1);

        long randomEpochDay = ThreadLocalRandom.current().longs(date1.toEpochDay(), date2.toEpochDay()).findAny().getAsLong();
        return LocalDate.ofEpochDay(randomEpochDay);
    }

    public static LocalDate getRandDate(LocalDate date1, LocalDate date2){
        long randomEpochDay = ThreadLocalRandom.current().longs(date1.toEpochDay(), date2.toEpochDay()).findAny().getAsLong();
        return LocalDate.ofEpochDay(randomEpochDay);
    }

    public static String encodePassword(String rawPW){
        return passwordEncoder.encode(rawPW);
    }

    public static boolean isValidPW(String rawPW, String encodedPW){
        return passwordEncoder.matches(rawPW, encodedPW);
    }

    public static String getRandText(int wordCount){
        String text = "";
        while (wordCount > 0) {
            int noOfWords = getRandInt(10,15);
            wordCount -= noOfWords;
            for (int i = 0; i < noOfWords; i++) {
                int noOfChar = getRandInt(1,8);
                for (int j = 0; j < noOfChar; j++) {
                    text += (char) (getRandInt(1,26) + 97);
                }
                if(i != (noOfWords - 1)){
                    text += " ";
                }
            }
            text += ". ";
        }
        return text;
    }

    public static void writeRandomParagraph(int wordCount){
        String text = "";
        while (wordCount > 0) {
            int noOfWords = getRandInt(10,15);
            wordCount -= noOfWords;
            for (int i = 0; i < noOfWords; i++) {
                int noOfChar = getRandInt(1,8);
                for (int j = 0; j < noOfChar; j++) {
                    text += (char) (getRandInt(1,26) + 97);
                }
                if(i != (noOfWords - 1)){
                    text += " ";
                }
            }
            text += ". ";
        }
        try {
            final String path = "D:\\text.txt";
            FileWriter fileWriter = new FileWriter(path);
            fileWriter.write(text);
            fileWriter.close();
        } catch (IOException e) {
            throw new RuntimeException(e);
        }
    }
}
