package Problem2_1lvShop.interfaces;

import java.math.BigDecimal;
import java.util.Date;

public interface Expirable {
    BigDecimal getPreExpirationPrice();
    Date getExpirationDate();
}
