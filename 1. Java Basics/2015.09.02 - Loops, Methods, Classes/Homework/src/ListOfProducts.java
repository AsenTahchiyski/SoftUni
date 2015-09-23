import java.io.IOException;
import java.math.BigDecimal;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.Collections;

public class ListOfProducts {
    public static void main(String[] args) {
        String filePath = "Products1.txt";
        ArrayList<Product> products = new ArrayList<>();
        try {
            for (String line : Files.readAllLines(Paths.get(filePath))) {
                String[] productData = line.split(" ");
                String name = productData[0];
                BigDecimal price = new BigDecimal(productData[1]);
                Product product = new Product(name, price);
                products.add(product);
            }
        } catch (IOException e) {
            System.out.println("Error, file not found.");
            return;
        }

        Collections.sort(products, (Product p1, Product p2) -> p1.getPrice().compareTo(p2.getPrice()));

        for (Product product : products) {
            System.out.println(product.getPrice() + " " + product.getName());
        }
    }
}
