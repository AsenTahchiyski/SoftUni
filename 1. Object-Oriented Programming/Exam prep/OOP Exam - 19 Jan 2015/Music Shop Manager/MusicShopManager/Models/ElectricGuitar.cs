namespace MusicShop.Models
{
    using System;
    using System.Text;
    using MusicShopManager.Interfaces;

    internal class ElectricGuitar : Guitar, IElectricGuitar
    {
        private int adaptersNum;
        private int fretsNum;

        protected internal ElectricGuitar(string make, string model, decimal price, string color, string bodyWood, string fretboardWood, int adapters, int frets)
            : base(make, model, price, color, true, bodyWood, fretboardWood, 6)
        {
            this.NumberOfAdapters = adapters;
            this.NumberOfFrets = frets;
        }

        public int NumberOfAdapters
        {
            get { return this.adaptersNum; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterNonNegative, "number of adapters"));
                }
                this.adaptersNum = value;
            }
        }

        public int NumberOfFrets
        {
            get { return this.fretsNum; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterPositive, "number of frets"));
                }
                this.fretsNum = value;
            }
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
            output.AppendLine(string.Format("Fingerboard wood: {0}", this.FingerboardWood));
            output.AppendLine(string.Format("Adapters: {0}", this.NumberOfAdapters));
            output.Append(string.Format("Frets: {0}", this.NumberOfFrets));
            return output.ToString();
        }
    }
}
