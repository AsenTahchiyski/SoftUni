namespace MusicShop.Models
{
    using System.Text;
    using MusicShopManager.Interfaces;

    internal class BassGuitar : Guitar, IBassGuitar
    {
        protected internal BassGuitar(string make, string model, decimal price, string color, string bodyWood, string fretboardWood)
            : base(make, model, price, color, true, bodyWood, fretboardWood, 4)
        {
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("= {0} {1} =", this.Make, this.Model));
            output.AppendLine(string.Format("Price: ${0:F2}", this.Price));
            output.AppendLine(string.Format("Color: {0}", this.Color));
            output.AppendLine(string.Format("Electronic: {0}", this.IsElectronic == true ? "yes" : "no"));
            output.AppendLine(string.Format("Strings: {0}", this.NumberOfStrings));
            output.AppendLine(string.Format("Body wood: {0}", this.BodyWood));
            output.Append(string.Format("Fingerboard wood: {0}", this.FingerboardWood));
            return output.ToString();
        }
    }
}
