using System;
using System.Text;

namespace MusicShop.Models
{
    using MusicShopManager.Interfaces;

    internal class Drums : Instrument, IDrums
    {
        private int width;
        private int height;

        protected internal Drums(string make, string model, decimal price, string color, int width, int height)
            : base (make, model, price, color, false)
        {
            this.Height = height;
            this.Width = width;
        }
        
        public int Width
        {
            get { return this.width; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterPositive, "width"));
                }
                this.width = value;
            }
        }

        public int Height
        {
            get { return this.height; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(string.Format(ErrorMessages.ParameterPositive, "height"));
                }
                this.height = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("= {0} {1} =", this.Make, this.Model));
            output.AppendLine(string.Format("Price: ${0:F2}", this.Price));
            output.AppendLine(string.Format("Color: {0}", this.Color));
            output.AppendLine(string.Format("Electronic: {0}", this.IsElectronic == true? "yes" : "no"));
            output.Append(string.Format("Size: {0}cm x {1}cm", this.Width, this.Height));
            return output.ToString();
        }
    }
}
