var models = models || {};

var ShoppingCart = (function() {
    function ShoppingCart() {
        this._items = [];
    }

    ShoppingCart.prototype.addItem = function(item) {
        this._items.push(item);
    };

    ShoppingCart.prototype.getTotalPrice = function() {
        var totalPrice = 0;
        this._items.forEach(function(i) {
            totalPrice += i.price;
        });
    };

    return ShoppingCart;
})();

models.getShoppingCart = ShoppingCart.prototype.ShoppingCart;