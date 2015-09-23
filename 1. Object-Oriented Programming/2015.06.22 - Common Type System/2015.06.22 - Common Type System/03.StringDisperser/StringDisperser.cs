namespace StringDisperser
{
    using System;
    using System.Collections;
    using System.Text;

    public class StringDisperser :ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        public StringDisperser(params string[] parameters)
        {
            this.contents = new StringBuilder();
            foreach (string item in parameters)
            {
                this.contents.Append(item);
            }
        }

        private StringBuilder contents;

        public override bool Equals(object obj)
        {
            StringDisperser a = obj as StringDisperser;
            if (a == null)
            {
                throw new NullReferenceException("Invalid string disperser.");
            }
            return this == a;
        }

        public static bool operator == (StringDisperser a, StringDisperser b)
        {
            return StringDisperser.Equals(a, b);
        }

        public static bool operator !=(StringDisperser a, StringDisperser b)
        {
            return !(StringDisperser.Equals(a, b));
        }

        public override string ToString()
        {
            return contents.ToString();
        }

        public override int GetHashCode()
        {
            return contents.GetHashCode();
        }

        public object Clone()
        {
            return new StringDisperser(contents.ToString());
        }

        public int CompareTo(StringDisperser other)
        {
            int a = 0, b = 0;
            foreach (char ch in this.contents.ToString())
            {
                a += (int)ch;
            }
            foreach (char ch in other.ToString())
            {
                b += (int)ch;
            }
            return a - b;
        }

        public IEnumerator GetEnumerator()
        {
            foreach (char ch in this.contents.ToString())
            {
                yield return ch;
            }
        }
    }
}
