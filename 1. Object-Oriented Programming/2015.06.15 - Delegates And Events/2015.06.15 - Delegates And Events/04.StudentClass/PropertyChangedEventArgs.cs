namespace StudentClass
{
    using System;

    public class PropertyChangedEventArgs : EventArgs
    {
        public PropertyChangedEventArgs(string oldVal, string newVal, string propName)
        {
            this.OldValue = oldVal;
            this.NewValue = newVal;
            this.Name = propName;
        }

        public string OldValue { get; set; }

        public string NewValue { get; set; }

        public string Name { get; set; }
    }
}
