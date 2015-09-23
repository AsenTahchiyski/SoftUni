namespace Composite.Components
{
    using System.Collections.Generic;
    using System.Text;

    public class Element
    {
        private readonly IList<Element> children;
        
        public Element(string name, params Element[] children)
        {
            this.Name = name;
            this.children = new List<Element>();
            //if (children == null)
            //{
            //    throw new ArgumentNullException("children");
            //}

            foreach (var child in children)
            {
                this.children.Add(child);
            }
        }

        public string Name { get; set; }

        public void Add(Element child)
        {
            this.children.Add(child);
        }

        public void Remove(Element child)
        {
            this.children.Remove(child);
        }

        public string Display(int depth = 0)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat(new string(' ', depth) + '<' + this.Name + '>').AppendLine();

            // Recursively display child nodes
            foreach (var component in this.children)
            {
                sb.AppendLine(component.Display(depth + 2));
            }

            sb.AppendFormat(new string(' ', depth) + "</" + this.Name + '>');
            return sb.ToString();
        }
    }
}
