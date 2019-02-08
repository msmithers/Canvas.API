using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CanvasApp.API.Models;

namespace CanvasApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CanvasController
    {
        [HttpGet]
        public async Task<List<Course>> GetCourses()
        {
            var courses = CanvasApp.API.Data.Methods.GetCourses();
            return await Task.FromResult(courses.ToList());
        } 
    }
}