namespace TraverseDir
{
    using System;
    using System.IO;

    public class Folder
    {
        private string name;
        private File[] files;
        private Folder[] childFolders;

        public Folder(string name, File[] files, Folder[] subFolders)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = subFolders;
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
                    throw new ArgumentException("Folder name cannot be empty.");
                }

                this.name = value;
            }
        }

        public File[] Files
        {
            get
            {
                return this.files;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Files array should not be null.");
                }

                this.files = value;
            }
        }

        public Folder[] ChildFolders
        {
            get
            {
                return this.childFolders;
            }

            set
            {
                if (value == null)
                {
                    throw new NullReferenceException("Folders array should not be null.");
                }

                this.childFolders = value;
            }
        }
    }
}
