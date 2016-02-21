var models = models || {};

var CustomerReview = (function() {
    function CustomerReview(customer, content, rating, createdOn) {
        this.customer = customer;
        this.content = content;
        this.rating = rating;
        this.createdOn = createdOn;
    }

    return CustomerReview;
})();

models.getCustomerReview = function(customer, content, rating, createdOn) {
    return new CustomerReview(customer, content, rating, createdOn);
};