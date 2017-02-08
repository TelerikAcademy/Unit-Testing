using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    internal class CreateLectureResourceCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;

        public CreateLectureResourceCommand(IAcademyFactory factory, IEngine engine)
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
            var courseId = parameters[1];
            var lectureId = parameters[2];
            var type = parameters[3];
            var name = parameters[4];
            var url = parameters[5];

            var course = this.engine
                .Seasons[int.Parse(seasonId)]
                .Courses[int.Parse(courseId)];

            var lecture = course
                .Lectures[int.Parse(lectureId)];

            var lectureResource = this.factory.CreateLectureResource(type, name, url);
            lecture.Resources.Add(lectureResource);

            return $"Lecture resource with ID {lecture.Resources.Count - 1} was created in Lecture {seasonId}.{course.Name}.{lecture.Name}.";
        }
    }
}
