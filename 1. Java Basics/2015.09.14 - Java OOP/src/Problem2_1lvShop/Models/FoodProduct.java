package Problem2_1lvShop.models;

import Problem2_1lvShop.interfaces.Expirable;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public class FoodProduct extends Product implements Expirable {
    private final int preExpirationDiscountPercent = 70;
    private final int productPreExpirationTermDays = 15;
    private Date expirationDate;

    public FoodProduct(String name, BigDecimal price, double quantity, AgeRestriction restriction, Date expirationDate) {
        super(name, price, quantity, restriction);
        this.setExpirationDate(expirationDate);
    }

    public Date getExpirationDate() {
        return this.expirationDate;
    }

    public void setExpirationDate(Date expirationDate) {
        if (this.getDateDiff(expirationDate, Calendar.getInstance().getTime(), TimeUnit.DAYS) < 0) {
            throw new IllegalArgumentException("Expiration date cannot be in the past.");
        }

        this.expirationDate = expirationDate;
    }

    @Override
    public BigDecimal getPreExpirationPrice() {
        return super.getPrice().multiply(new BigDecimal(preExpirationDiscountPercent / 100));
    }

    @Override
    public BigDecimal getPrice() {
        Date currentDate = Calendar.getInstance().getTime();
        if (this.getDateDiff(this.expirationDate, currentDate, TimeUnit.DAYS) >
                productPreExpirationTermDays) {
            return super.getPrice();
        } else {
            return this.getPreExpirationPrice();
        }
    }
}
