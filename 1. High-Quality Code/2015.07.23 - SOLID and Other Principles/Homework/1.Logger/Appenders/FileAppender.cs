namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    public class FileAppender : Appender
    {
        private readonly StreamWriter writer;
        
        public FileAppender(ILayout layout, string fileName) 
            : base(layout)
        {
            this.File = fileName;
            this.writer = new StreamWriter(this.File);
        }
        
        public string File { get; private set; }

        public override void Append(DateTime time, ReportLevel level, string message)
        {
            if (this.ReportLevel > level)
            {
                return;
            }
            
            var output = this.Layout.Format(time, level, message);

            this.writer.WriteLine(output);
            this.writer.Flush();
        }

        public void Close()
        {
            this.writer.Close();
        }
    }
}
