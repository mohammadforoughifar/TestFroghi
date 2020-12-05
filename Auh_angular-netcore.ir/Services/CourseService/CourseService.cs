using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auh_angular_netcore.DataLayer.Context;
using Auh_angular_netcore.ir.Entities;

namespace Auh_angular_netcore.ir.Services.CourseService
{
    public class CourseService:IcourseServices
    {
        private OghabContext _context;

        public CourseService(OghabContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Course> GetAllCourse()
        {
            return _context.Course.ToList();
        }

        public Course GetCourseById(int courseId)
        {
            return _context.Course.Find(courseId);
        }
    }
}
