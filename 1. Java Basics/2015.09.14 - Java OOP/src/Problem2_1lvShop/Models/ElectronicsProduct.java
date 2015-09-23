package Problem2_1lvShop.models;

import java.math.BigDecimal;
import java.util.Calendar;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public abstract class ElectronicsProduct extends Product{
    private Date warrantyExpiration;

    protected ElectronicsProduct(String name, BigDecimal price, double quantity,
                                 AgeRestriction restriction, Date warrantyExpiration) {
        super(name, price, quantity, restriction);
        this.setWarrantyExpiration(warrantyExpiration);
    }

    public Date getWarrantyExpiration() {
        return this.warrantyExpiration;
    }

    public void setWarrantyExpiration(Date warrantyExpiration) {
        if (this.getDateDiff(warrantyExpiration, Calendar.getInstance().getTime(), TimeUnit.DAYS) < 0) {
            throw new IllegalArgumentException("Warranty expiration date cannot be in the past.");
        }

        this.warrantyExpiration = warrantyExpiration;
    }
}
