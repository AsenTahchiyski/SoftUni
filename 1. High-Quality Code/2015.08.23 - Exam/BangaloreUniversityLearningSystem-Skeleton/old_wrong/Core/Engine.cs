namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Data;
    using Interfaces;

    public class Engine : IEngine
    {
        public void Run()
        {
            var database = new Data();
            IUser user = null;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }

                var route = new Route(input);
                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);

                if (controllerType == null)
                {
                    continue;
                }

                var controller = Activator.CreateInstance(controllerType, database, user) as Controller;
                var action = controllerType.GetMethod(route.ActionName);
                object[] @params = MapParameters(route, action);
                try
                {
                    var view = action.Invoke(controller, @params) as IView;
                    if (view != null)
                    {
                        Console.WriteLine(view.Display());
                    }

                    if (controller != null)
                    {
                        user = controller.User;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(IRoute route, MethodInfo action)
        {
            var result = action
                .GetParameters()
                .Select(parameterInfo => 
                    CheckParameter(route, parameterInfo)).ToArray();

            return result;
        }

        private static object CheckParameter(IRoute route, ParameterInfo parameterInfo)
        {
            if (parameterInfo.ParameterType == typeof(int))
            {
                return int.Parse(route.Parameters[parameterInfo.Name]);
            }
            
            return route.Parameters[parameterInfo.Name];
        }
    }
}
