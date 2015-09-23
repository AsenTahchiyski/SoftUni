namespace Logger.Interfaces
{
    using System;

    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(DateTime times, ReportLevel level, string message);

        ReportLevel ReportLevel { get; }
    }
}
