using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auh_angular_netcore.ir.Entities;

namespace Auh_angular_netcore.ir.Services.CourseService
{
    public interface IcourseServices
    {
        IEnumerable<Course> GetAllCourse();
        Course GetCourseById(int courseId);
    }
}
