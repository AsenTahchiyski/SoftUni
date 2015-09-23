namespace Logger.Interfaces
{
    using System;

    public interface ILayout
    {
        string Format(DateTime times, ReportLevel level, string message);
    }
}
