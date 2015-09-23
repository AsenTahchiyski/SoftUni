package Problem2_1lvShop.controller;

import Problem2_1lvShop.models.AgeRestriction;
import Problem2_1lvShop.models.Product;

import java.math.BigDecimal;

public class PurchaseManager { // top level classes are static by default
    public static void processPurchase(Product product, Customer customer, double quantity) {
        if (product.getQuantity() < quantity) {
            throw new IllegalArgumentException("Not enough product quantity.");
        }

        if (product.getHasExpired()) {
            throw new IllegalArgumentException("Product has expired.");
        }

        if (customer.getBalance().compareTo(product.getPrice().multiply(new BigDecimal(quantity))) < 0) {
            throw new IllegalArgumentException("Not enough balance for this customer.");
        }

        if (product.getRestriction() == AgeRestriction.Adult &&
                customer.getRestriction() == AgeRestriction.Teenager) {
            throw new IllegalArgumentException("Customer has no permission to buy this product due to age restriction.");
        }

        product.buy();
        customer.setBalance(customer.getBalance().subtract(product.getPrice().multiply(new BigDecimal(quantity))));
    }

    public static void processPurchase(Product product, Customer customer) {
        processPurchase(product, customer, 1);
    }
}
