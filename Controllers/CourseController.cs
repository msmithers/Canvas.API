using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CanvasApp.API.Models;
using CanvasApp.API.Data;
using CanvasApp.API.Helpers;

namespace CanvasApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        [HttpGet]
        public async Task<List<Course>> GetCourses()
        {
            var courses = CanvasApp.API.Data.Methods.GetCourses();
            return await Task.FromResult(courses.ToList());
        } 
        
        
        // public async Task<List<Course>> GetCourses(UserParams userParams)
        // {
        //     return await CanvasRepository.GetCourses(userParams);
        // }
    }
}