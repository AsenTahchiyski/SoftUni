package Problem2_1lvShop.controller;

import Problem2_1lvShop.models.AgeRestriction;

import java.math.BigDecimal;

public class Customer {
    private final int adultAge = 18;

    private String name;
    private int age;
    private BigDecimal balance;

    public Customer(String name, int age, BigDecimal balance) {
        this.setName(name);
        this.setAge(age);
        this.setBalance(balance);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name == null || name == "") {
            throw new IllegalArgumentException("Customer name must be specified.");
        }

        this.name = name;
    }

    public int getAge() {
        return this.age;
    }

    public void setAge(int age) {
        if (age <= 0) {
            throw new IllegalArgumentException("Age must be positive.");
        }

        this.age = age;
    }

    public BigDecimal getBalance() {
        return this.balance;
    }

    public void setBalance(BigDecimal balance) {
        if (balance.compareTo(BigDecimal.ZERO) < 0) {
            throw new IllegalArgumentException("Balance must be non-negative.");
        }

        this.balance = balance;
    }

    public AgeRestriction getRestriction() {
        if (this.getAge() < adultAge) {
            return AgeRestriction.Teenager;
        } else {
            return AgeRestriction.Adult;
        }
    }
}
