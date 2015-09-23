namespace StudentClass
{
    using System;
    
    public delegate void OnPropChangeEventHandler(Student student, PropertyChangedEventArgs args);
    public class Student
    {
        public event OnPropChangeEventHandler PropertyChanged;
        
        public Student(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        
        public string Name 
        {
            get { return this.name; }
            set
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(this.name, value, "Name"));
                }
                this.name = value;
            }
        }

        public int Age 
        {
            get { return this.age; }
            set
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(this.age.ToString(), value.ToString(), "Age"));
                }
                this.age = value;
            }
        }

        private string name;
        private int age;

    }
}
