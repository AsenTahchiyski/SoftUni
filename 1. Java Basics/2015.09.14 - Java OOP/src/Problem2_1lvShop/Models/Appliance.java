package Problem2_1lvShop.models;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;

public class Appliance extends ElectronicsProduct {
    public Appliance(String name, BigDecimal price, double quantity, AgeRestriction restriction) {
        super(name, price, quantity, restriction, new Date(Long.MAX_VALUE));
    }

    @Override
    public void buy() {
        super.buy();
        Date expiration = new Date();
        Calendar cal = Calendar.getInstance();
        cal.setTime(expiration);
        cal.add(Calendar.MONTH, 6);
        this.setWarrantyExpiration(cal.getTime());
    }

    @Override
    public BigDecimal getPrice() {
        if (this.getQuantity() < 50) {
            return super.getPrice().multiply(new BigDecimal(1.05));
        } else {
            return super.getPrice();
        }
    }
}
