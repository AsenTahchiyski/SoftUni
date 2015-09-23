namespace Visitor.Models
{
    using CustomerService.Models;
    using Interfaces;

    public class DiscountRaiseVisitor : ICustomerVisitor
    {
        public void Visit(Customer customer)
        {
            customer.RaiseDiscount(5.0);
        }
    }
}
