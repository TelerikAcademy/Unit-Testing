using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Listing
{
    internal class ListCoursesInSeasonCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public ListCoursesInSeasonCommand(IAcademyFactory factory, IEngine engine)
        {
            if (factory == null)
            {
                throw new ArgumentNullException("Factory cannot be null.");
            }

            if (engine == null)
            {
                throw new ArgumentNullException("Engine cannot be null.");
            }

            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)
        {
            var seasonId = parameters[0];
            var season = this.engine.Seasons[int.Parse(seasonId)];

            return season.ListCourses();
        }
    }
}
