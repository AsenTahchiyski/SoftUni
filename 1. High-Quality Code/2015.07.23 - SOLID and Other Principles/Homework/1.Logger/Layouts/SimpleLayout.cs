namespace Logger.Layouts
{
    using System;
    using Interfaces;

    public class SimpleLayout : ILayout
    {
        public string Format(DateTime time, ReportLevel level, string message)
        {
            return string.Format("{0} - {1} - {2}", time, level, message);
        }
    }
}
