namespace CustomerService
{
    using Data;
    using Visitor.Models;

    public class Program
    {
        static void Main()
        {
            var repository = new CustomerRepository();
            var visitorDiscount = new DiscountRaiseVisitor();
            var visitorFreeItem = new FreePurchaseVisitor();

            var premiumCustomers = repository.GetPremiumCustomers();
            foreach (var premiumCustomer in premiumCustomers)
            {
                premiumCustomer.Accept(visitorDiscount);
            }

            var allCustomers = repository.GetAll();
            foreach (var customer in allCustomers)
            {
                customer.Accept(visitorFreeItem);
            }
        }
    }
}
