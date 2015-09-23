namespace GenericList
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method,
    AllowMultiple = true)]

    public class VersionAttribute : System.Attribute
    {
        private int majorVer;
        private int minorVer;

        public int Major 
        {
            get
            {
                return this.majorVer;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Version number cannot be negative.");
                }
                this.majorVer = value;
            }
        }
        public int Minor 
        {
            get
            {
                return this.minorVer;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Version number cannot be negative.");
                }
                this.minorVer = value;
            }
        }

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
}
