package Problem2_1lvShop;

import Problem2_1lvShop.controller.Customer;
import Problem2_1lvShop.controller.PurchaseManager;
import Problem2_1lvShop.models.AgeRestriction;
import Problem2_1lvShop.models.FoodProduct;

import java.math.BigDecimal;
import java.util.Date;

public class Demo {
    public static void main(String[] args) {
        FoodProduct cigars = new FoodProduct(
                "420 Blaze it fgt", new BigDecimal(6.90), 1400, AgeRestriction.Adult, new Date(2016));
        Customer pecata = new Customer("Pecata", 17, new BigDecimal(30.00));
        Customer gopeto = new Customer("Gopeto", 18, new BigDecimal(0.44));
        try {
            PurchaseManager.processPurchase(cigars, pecata);
        } catch (IllegalArgumentException ex) {
            System.out.println(ex.getMessage());
        }

        try {
            PurchaseManager.processPurchase(cigars, gopeto);
        } catch (IllegalArgumentException ex) {
            System.out.println(ex.getMessage());
        }
    }
}
