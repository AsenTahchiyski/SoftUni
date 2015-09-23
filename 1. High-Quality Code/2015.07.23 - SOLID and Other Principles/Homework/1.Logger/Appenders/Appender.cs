namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        protected int threshold;
        
        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout { get; private set; }
        
        public abstract void Append(DateTime times, ReportLevel level, string message);

        public ReportLevel ReportLevel { get; set; }
    }
}
