namespace Customer
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Customer :ICloneable, IComparable<Customer>
    {
        public string FirstName { get; set; }
        public string MidName { get; set; }
        public string LastName { get; set; }
        public long ID { get; set; }
        public string Address { get; set; }
        public string MobilePhone { get; set; }
        public string Email { get; set; }
        public List<Payment> Payments { get; set; }
        CustomerType Type { get; set; }

        public Customer(string fName, string mName, string lName, long id, string address, string mobile, string email, List<Payment> payments, CustomerType type)
        {
            this.FirstName = fName;
            this.MidName = mName;
            this.LastName = lName;
            this.ID = id;
            this.Address = address;
            this.MobilePhone = mobile;
            this.Email = email;
            this.Payments = payments;
            this.Type = type;
        }

        public override bool Equals(object obj)
        {
            Customer a = obj as Customer;
            if (a == null)
            {
                throw new NullReferenceException("Invalid customer.");
            }
            return this.ID == a.ID;
        }

        public static bool operator == (Customer a, Customer b)
        {
            return Customer.Equals(a, b);
        }

        public static bool operator !=(Customer a, Customer b)
        {
            return !(Customer.Equals(a, b));
        }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode() ^ this.LastName.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("({0}) {1} {2} {3}\nEmail: {4}; Mobile: {5}; Type: {6}",
                this.ID, this.FirstName, this.MidName, this.LastName, this.Email, this.MobilePhone, this.Type);
        }

        public object Clone()
        {
            string fName = this.FirstName.ToString();
            string mName = this.MidName.ToString();
            string lname = this.LastName.ToString();
            long id = this.ID;
            string address = this.Address.ToString();
            string mobile = this.MobilePhone.ToString();
            string email = this.Email.ToString();
            List<Payment> payments = this.Payments.ToList();
            CustomerType type = this.Type;

            return new Customer(fName, mName, lname, id, address, mobile, email, payments, type);
        }

        public int CompareTo(Customer other)
        {
            if (this.FirstName != other.FirstName)
            {
                return ~this.FirstName.CompareTo(other.LastName);
            }
            else if (this.MidName != other.MidName)
            {
                return ~this.MidName.CompareTo(other.MidName);
            }
            else if (this.LastName != other.LastName)
            {
                return ~this.LastName.CompareTo(other.LastName);
            }
            else if (this.ID != other.ID)
            {
                return ~this.ID.CompareTo(other.ID);
            }
            return 0;
        }
    }
}
