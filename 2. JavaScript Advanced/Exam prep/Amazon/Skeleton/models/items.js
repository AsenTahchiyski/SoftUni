var models = models || {};

if(!Object.prototype.extends) {
    Object.prototype.extends = function (parent) {
        this.prototype = Object.create(parent.prototype);
        this.prototype.constructor = this;
    }
}

var Item = (function() {
    function Item(title, description, price) {
        this.title = title;
        this.description = description;
        this.price = price;
        this._customerReviews = [];
    }

    Item.prototype.addCustomerReview = function(review) {
        this._customerReviews.push(review);
    };

    Item.prototype.getCustomerReviews = function() {
        return this._customerReviews;
    };

    return Item;
})();

var UsedItem = (function() {
    function UsedItem(title, description, price, condition) {
        Item.call(this, title, description, price);
        this.condition = condition;
    }

    UsedItem.extends(Item);
    return UsedItem;
})();

models.getItem = function(title, description, price) {
    return new Item(title, description, price);
};
models.getUsedItem = UsedItem.prototype.UsedItem;