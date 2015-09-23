namespace MusicShop.Models
{
    using System;
    using MusicShopManager.Interfaces;

    internal abstract class Guitar : Instrument, IGuitar
    {
        private string bodyWood;
        private string fretboardWood;
        private int numberOfStrings;

        protected internal Guitar(string make, string model, decimal price, string color, bool isElectronic, string bodyWood, string fretboardWood, int numberOfStrings)
            : base(make, model, price, color, isElectronic)
        {
            this.BodyWood = bodyWood;
            this.FingerboardWood = fretboardWood;
            this.NumberOfStrings = numberOfStrings;
        }
        
        public string BodyWood
        {
            get { return this.bodyWood; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterRequired, "body wood"));
                }
                this.bodyWood = value;
            }
        }

        public string FingerboardWood
        {
            get { return this.fretboardWood; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterRequired, "fingerboard wood"));
                }
                this.fretboardWood = value;
            }
        }

        public int NumberOfStrings
        {
            get { return this.numberOfStrings; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterNonNegative, "number of strings"));
                }
                this.numberOfStrings = value;
            }
        }
    }
}
