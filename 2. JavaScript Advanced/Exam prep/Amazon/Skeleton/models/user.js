var models = models || {};

var User = (function() {
    function User(username, fullName, balance) {
        this.username = username;
        this.fullName = fullName;
        this._balance = balance;
        this._shoppingCart = [];
    }

    User.prototype.addItemToCart = function(item) {
        this._shoppingCart.push(item);
    };

    return User;
})();

models.getUser = function(username, fullName, balance) {
    return new User(username, fullName, balance);
};