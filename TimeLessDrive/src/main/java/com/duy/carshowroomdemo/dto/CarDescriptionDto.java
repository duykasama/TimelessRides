package com.duy.carshowroomdemo.dto;

import com.duy.carshowroomdemo.entity.CarDescription;
import lombok.*;

import java.io.Serializable;

/**
 * DTO for {@link CarDescription}
 */
@NoArgsConstructor
@AllArgsConstructor
@Data
public class CarDescriptionDto implements Serializable {
    private String id;
    private String make;
    private String model;
    private String bodyColor;
    private String interiorColor;
    private String interiorMaterial;
    private String body;
    private String licensePlate;
    private String fuelType;
    private String transmission;
    private String firstRegistration;
    private int seats;
    private int power;
    private int engineCapacity;
    private int co2Emission;
    private int kmsDriven;
    private String others;
}