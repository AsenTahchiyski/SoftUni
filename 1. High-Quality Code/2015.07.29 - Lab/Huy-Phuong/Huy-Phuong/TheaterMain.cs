namespace Theatre
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using DataModels;
    using Interfaces;

    internal class TheaterMain
    {
        private static readonly IPerformanceDatabase PerformanceDatabase = new PerformanceDatabase();

        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            while (true)
            {
                string commandLine = Console.ReadLine(); 
                if (commandLine == null)
                {
                    return;
                }

                if (commandLine != string.Empty)
                {
                    string[] commandParameters = commandLine.Split('(');
                    string command = commandParameters[0];
                    string commandResult;
                    try
                    {
                        string[] commandParameters1 = commandLine.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);
                        string[] commandParameters2 = commandParameters1.Skip(1).Select(p => p.Trim()).ToArray(); 

                        switch (command)
                        {
                            case "AddTheatre": 
                                commandResult = ExecuteAddTheatreCommand(commandParameters2);
                                break;

                            case "PrintAllTheatres":
                                commandResult = ExecutePrintAllTheatresCommand(); 
                                break;

                            case "AddPerformance":
                                string theatreName = commandParameters2[0];
                                string performanceTitle = commandParameters2[1];
                                DateTime start = DateTime.ParseExact(commandParameters2[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                                TimeSpan duration = TimeSpan.Parse(commandParameters2[3]);
                                decimal price = decimal.Parse(commandParameters2[4], NumberStyles.Float);
                                PerformanceDatabase.AddPerformance(theatreName, performanceTitle, start, duration, price);
                                commandResult = "Performance added"; 
                                break;

                            case "PrintAllPerformances":
                                commandResult = ExecutePrintAllPerformancesCommand();
                                break;

                            case "PrintPerformances":
                                string theatre = commandParameters2[0];
                                var performances = PerformanceDatabase.ListPerformances(theatre).Select(p =>
                                {
                                    string startTime = p.Start.ToString("dd.MM.yyyy HH:mm");
                                    return string.Format("({0}, {1})", p.Name, startTime);
                                });

                                if (performances.Any())
                                {
                                    commandResult = string.Join(", ", performances);
                                }
                                else
                                {
                                    commandResult = "No performances";
                                } 

                                break;

                            default: 
                                commandResult = "Invalid command!";
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        commandResult = "Error: " + ex.Message;
                    }

                    Console.WriteLine(commandResult);
                }
            }
        }

        public static string ExecutePrintAllTheatresCommand()
        {
            var theatres = PerformanceDatabase.ListTheatres();

            if (theatres.Any())
            {
                return string.Join(", ", theatres);
            }

            return "No theatres";
        }

        public static string ExecutePrintAllPerformancesCommand()
        {
            var performances = PerformanceDatabase.ListAllPerformances().ToList();
            var result = string.Empty;
            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    var sb = new StringBuilder();
                    sb.Append(result);
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    string time = performances[i].Start.ToString("dd.MM.yyyy HH:mm");
                    sb.AppendFormat("({0}, {1}, {2})", performances[i].Name, performances[i].Theatre, time);
                    result = sb + string.Empty;
                }

                return result;
            }

            return "No performances";
        }

        internal static string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[0];
            PerformanceDatabase.AddTheatre(theatreName);
            return "Theatre added";
        }
    }
}