namespace MusicShop.Models
{
    using System.Text;
    using MusicShopManager.Models;
    using MusicShopManager.Interfaces;

    internal class AcousticGuitar : Guitar, IAcousticGuitar
    {
        protected internal AcousticGuitar(string make, string model, decimal price, string color, string bodyWood, string fretboardWood, bool caseIncluded, StringMaterial stringMaterial)
            : base(make, model, price, color, false, bodyWood, fretboardWood, 6)
        {
            this.CaseIncluded = caseIncluded;
            this.StringMaterial = stringMaterial;
        }

        public bool CaseIncluded { get; protected set; }

        public StringMaterial StringMaterial { get; protected set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("= {0} {1} =", this.Make, this.Model));
            output.AppendLine(string.Format("Price: ${0:F2}", this.Price));
            output.AppendLine(string.Format("Color: {0}", this.Color));
            output.AppendLine(string.Format("Electronic: {0}", this.IsElectronic == true ? "yes" : "no"));
            output.AppendLine(string.Format("Strings: {0}", this.NumberOfStrings));
            output.AppendLine(string.Format("Body wood: {0}", this.BodyWood));
            output.AppendLine(string.Format("Fingerboard wood: {0}", this.FingerboardWood));
            output.AppendLine(string.Format("Case included: {0}", this.CaseIncluded == true ? "yes" : "no"));
            output.Append(string.Format("String material: {0}", this.StringMaterial));
            return output.ToString();
        }
    }
}
