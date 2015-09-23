package Problem2_1lvShop.models;

import Problem2_1lvShop.interfaces.Buyable;
import java.math.BigDecimal;
import java.util.Date;
import java.util.concurrent.TimeUnit;

public abstract class Product implements Buyable {
    private String name;
    private BigDecimal price;
    private double quantity;
    private AgeRestriction restriction;
    private boolean hasExpired;

    protected Product(String name, BigDecimal price, double quantity, AgeRestriction restriction) {
        this.setName(name);
        this.setPrice(price);
        this.setQuantity(quantity);
        this.setRestriction(restriction);
        this.setHasExpired(false);
    }

    public String getName() {
        return this.name;
    }

    protected void setName(String name) {
        if (name == null || name == "") {
            throw new IllegalArgumentException("Product name must be specified.");
        }

        this.name = name;
    }

    public BigDecimal getPrice() {
        return this.price;
    }

    protected void setPrice(BigDecimal price) {
        if (price.compareTo(BigDecimal.ZERO) <= 0) {
            throw new IllegalArgumentException("Price must be positive.");
        }

        this.price = price;
    }

    public double getQuantity() {
        return this.quantity;
    }

    protected void setQuantity(double quantity) {
        if (quantity < 0) {
            throw new IllegalArgumentException("Quantity must be non-negative.");
        }

        this.quantity = quantity;
    }

    public AgeRestriction getRestriction() {
        return this.restriction;
    }

    public boolean getHasExpired() {
        return this.hasExpired;
    }

    public void setHasExpired(boolean hasExpired) {
        this.hasExpired = hasExpired;
    }

    protected void setRestriction(AgeRestriction restriction) {
        this.restriction = restriction;
    }

    @Override
    public void buy() {
        if (this.quantity <= 0) {
            throw new IllegalArgumentException("Not enough products available.");
        }

        this.quantity--;
    }

    protected long getDateDiff(Date date1, Date date2, TimeUnit timeUnit) {
        long diffInMillies = date2.getTime() - date1.getTime();
        return timeUnit.convert(diffInMillies,TimeUnit.DAYS);
    }
}
