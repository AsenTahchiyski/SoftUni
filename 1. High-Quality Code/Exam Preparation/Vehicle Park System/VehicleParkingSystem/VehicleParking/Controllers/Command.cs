﻿namespace VehicleParkingSystem.Controllers
{
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    using Interfaces;

    public class Command : ICommand
    {
        public Command(string str)
        {
            this.Name = str.Substring(0, str.IndexOf(' '));
            this.Parameters = new JavaScriptSerializer().Deserialize<Dictionary<string, string>>(str.Substring(str.IndexOf(' ') + 1));
        }

        public string Name { get; set; }

        public IDictionary<string, string> Parameters { get; set; }
    }
}
