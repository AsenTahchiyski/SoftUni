using System;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    internal abstract class Instrument : Article, IInstrument
    {
        private string color;

        protected internal Instrument(string make, string model, decimal price, string color, bool isElectronic)
            : base(make, model, price)
        {
            this.Color = color;
            this.IsElectronic = isElectronic;
        }

        public string Color
        {
            get { return this.color; }
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterRequired, "color"));
                }
                this.color = value;
            }
        }

        public bool IsElectronic { get; protected set; }
    }
}
