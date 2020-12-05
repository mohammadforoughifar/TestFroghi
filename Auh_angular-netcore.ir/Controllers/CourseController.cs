using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auh_angular_netcore.ir.Entities;
using Auh_angular_netcore.ir.Services.CourseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Auh_angular_netcore.ir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private IcourseServices _courseServices;

        public CourseController(IcourseServices courseServices)
        {
            _courseServices = courseServices;
        }
        [AllowAnonymous]
        [HttpGet("GetAllCourses")]
        public IEnumerable<Course> GetAllCourses()
        {
            return _courseServices.GetAllCourse();
        }
        [AllowAnonymous]
        [HttpGet("GetCourseById")]
        public Course GetCourseById(int courseId)
        {
            return _courseServices.GetCourseById(courseId);
        }
    }
}
