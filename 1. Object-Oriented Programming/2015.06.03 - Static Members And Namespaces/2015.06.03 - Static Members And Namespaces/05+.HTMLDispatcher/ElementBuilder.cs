using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_.HTMLDispatcher
{
    class ElementBuilder
    {
        private string element;
        private StringBuilder tag = new StringBuilder();
        private StringBuilder content = new StringBuilder();
        private string start;
        private string end;

        public string Element 
        {
            get
            {
                return this.element;
            }
            private set
            {
                this.Element = value;
            } 
        }

        public ElementBuilder(string elem)
        {
            this.element = elem;
        }

        public void AddAttribute(string attribute, string value)
        {
            this.tag.Append(string.Format(" {0}=\"{1}\"", attribute, value));
        }

        public void AddContent(string content)
        {
            this.content.Append(content);
        }

        public string GetResult()
        {
            this.start = string.Format("<{0}", this.Element);
            this.end = string.Format("</{0}>", this.Element);
            return this.start + this.tag.ToString() + ">" + this.content.ToString() + this.end;
        }

        public static string operator *(ElementBuilder elem, int n)
        {
            StringBuilder output = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                output.Append(elem.GetResult());    
            }
            return output.ToString();
        }
    }
}
