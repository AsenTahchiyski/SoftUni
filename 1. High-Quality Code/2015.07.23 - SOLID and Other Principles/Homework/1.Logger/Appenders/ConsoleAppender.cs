namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void Append(DateTime time, ReportLevel level, string message)
        {
            if (this.ReportLevel > level)
            {
                return;
            }
            var output = this.Layout.Format(time, level, message);
            Console.WriteLine(output);
        }
    }
}
