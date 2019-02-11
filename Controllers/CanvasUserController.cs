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
    public class CanvasUserController : ControllerBase
    {
        // [HttpGet]
        // public async Task<List<Course>> GetCourses()
        // {
        //     var courses = CanvasApp.API.Data.Methods.GetCourses(10,1);
        //     return await Task.FromResult(courses.ToList());
        // } 
    }
}