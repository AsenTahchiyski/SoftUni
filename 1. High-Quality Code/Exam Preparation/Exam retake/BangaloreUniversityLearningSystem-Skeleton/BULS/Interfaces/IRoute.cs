namespace BangaloreUniversityLearningSystem.Interfaces
{
    using System.Collections.Generic;
 
    /// <summary>
    /// Defines the actions a route should be able to perform.
    /// </summary>
    public interface IRoute
    {
        /// <summary>
        /// Provides the route controller name as string.
        /// </summary>
        string ControllerName { get; }

        /// <summary>
        /// Provides the route action name as string.
        /// </summary>
        string ActionName { get; }
        
        /// <summary>
        /// Stores the command parameters passed in the route.
        /// </summary>
        IDictionary<string, string> Parameters { get; }
    }
}
