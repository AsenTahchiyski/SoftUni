namespace MusicShop.Models
{
    using System.Text;
    using MusicShopManager.Interfaces;

    internal class Microphone : Article, IMicrophone
    {
        protected internal Microphone(string make, string model, decimal price, bool hasCable)
            : base(make, model, price)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.HasCable = hasCable;
        }

        public bool HasCable { get; protected set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("= {0} {1} =", this.Make, this.Model));
            output.AppendLine(string.Format("Price: ${0:F2}", this.Price));
            output.Append(string.Format("Cable: {0}", this.HasCable == true ? "yes" : "no"));
            return output.ToString();
        }
    }
}
