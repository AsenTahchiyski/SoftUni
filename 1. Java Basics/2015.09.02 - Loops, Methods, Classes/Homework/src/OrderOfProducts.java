import java.io.IOException;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.text.DecimalFormat;
import java.text.MessageFormat;
import java.util.Hashtable;
import java.util.Map;

public class OrderOfProducts {
    public static void main(String[] args) {
        String productsPath = "ProductsOrders2.txt";
        String ordersPath = "Order2.txt";
        Hashtable<String, BigDecimal> products = getProducts(productsPath);
        Hashtable<String, BigDecimal> orders = getOrders(ordersPath);
        BigDecimal total = BigDecimal.ZERO;

        for (Map.Entry<String, BigDecimal> orderLine : orders.entrySet()) {
            BigDecimal currentProductPrice = products.get(orderLine.getKey());
            BigDecimal quantityPrice = currentProductPrice.multiply(orderLine.getValue());
            total = total.add(quantityPrice);
        }

        DecimalFormat outputFormat = new DecimalFormat();
        outputFormat.setMaximumFractionDigits(2);
        outputFormat.setMinimumFractionDigits(0);
        outputFormat.setGroupingUsed(false);
        System.out.println(outputFormat.format(total));
    }

    public static Hashtable<String, BigDecimal> getProducts(String filePath) {
        Hashtable<String, BigDecimal> products = new Hashtable<>();
        try {
            for (String line : Files.readAllLines(Paths.get(filePath))) {
                String[] productData = line.split(" ");
                String name = productData[0];
                BigDecimal price = new BigDecimal(productData[1]);
                products.put(name, price);
            }
        } catch (IOException e) {
            System.out.println("Error, products file not found.");
        }
        return products;
    }

    public static Hashtable<String, BigDecimal> getOrders(String filePath) {
        Hashtable<String, BigDecimal> orders = new Hashtable<>();
        try {
            for (String line : Files.readAllLines(Paths.get(filePath))) {
                String[] orderData = line.split(" ");
                String name = orderData[1];
                BigDecimal quantity = new BigDecimal(orderData[0]);
                if (!orders.containsKey(name)) {
                    orders.put(name, BigDecimal.ZERO);
                }
                orders.put(name, orders.get(name).add(quantity));
            }
        } catch (IOException e) {
            System.out.println("Error, order file not found.");
        }
        return orders;
    }
}
