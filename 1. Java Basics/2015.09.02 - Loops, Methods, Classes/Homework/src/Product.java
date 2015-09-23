import java.math.BigDecimal;
import java.util.Comparator;

public class Product implements Comparator<Product> {
    private String name;
    private BigDecimal price;

    public Product(String name, BigDecimal price) {
        this.setName(name);
        this.setPrice(price);
    }

    public String getName() {
        return this.name;
    }

    public void setName(String name) {
        if (name == null || name == "") {
            throw new IllegalArgumentException("Product name must be specified.");
        }
        this.name = name;
    }

    public BigDecimal getPrice() {
        return this.price;
    }

    public void setPrice(BigDecimal price) {
        if (price.compareTo(BigDecimal.ZERO) < 0) {
            throw new IllegalArgumentException("Price cannot be negative.");
        }
        this.price = price;
    }

    @Override
    public int compare(Product first, Product second) {
        return first.price.compareTo(second.price);
    }
}
