namespace Visitor.Models
{
    using CustomerService.Models;
    using Interfaces;

    public class FreePurchaseVisitor : ICustomerVisitor
    {
        public void Visit(Customer customer)
        {
            customer.AddFreePurchase(new Purchase("SteamOp", 0.0));
        }
    }
}
