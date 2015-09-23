namespace Logger.Layouts
{
    using System;
    using System.Text;
    using Interfaces;

    public class XmlLayout : ILayout
    {
        public string Format(DateTime time, ReportLevel level, string message)
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("<log>");
            string delimiter = "    ";

            output.AppendLine(string.Format("{0}<date>{1}</date>", delimiter, time));
            output.AppendLine(string.Format("{0}<level>{1}</level>", delimiter, level));
            output.AppendLine(string.Format("{0}<message>{1}</message>", delimiter, message));

            output.Append("</log>");

            return output.ToString();
        }
    }
}
