namespace TraverseDir
{
    using System;
    using System.IO;

    public class File
    {
        private string name;
        private long size;

        public File(string name, long size)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("File name cannot be empty.");
                }

                this.name = value;
            }
        }

        public long Size
        {
            get
            {
                return this.size;
            }

            set
            {
                if (value < 0)
                {
                    throw new InvalidDataException("File size cannot be negative.");
                }

                this.size = value;
            }
        }
    }
}
