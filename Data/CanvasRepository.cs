using System.Collections.Generic;
using System.Threading.Tasks;
using CanvasApp.API.Helpers;
using CanvasApp.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestSharp;

    //<https://rmit.instructure.com/api/v1/courses?page=2&per_page=10>; rel="current",
    //<https://rmit.instructure.com/api/v1/courses?page=3&per_page=10>; rel="next",
    //<https://rmit.instructure.com/api/v1/courses?page=1&per_page=10>; rel="prev",
    //<https://rmit.instructure.com/api/v1/courses?page=1&per_page=10>; rel="first",
    //<https://rmit.instructure.com/api/v1/courses?page=27&per_page=10>; rel="last"

namespace CanvasApp.API.Data
{
    public class CanvasRepository
    {
        private static string token = string.Empty;
        private static string apiAddress = string.Empty;
        private readonly IConfiguration _config;
        public CanvasRepository(IConfiguration config)
        {
            _config = config;

            token = _config.GetSection("AppSettings: CanvasToken").Value;
            apiAddress = _config.GetSection("AppSettings: APIUrl").Value;

        }
        public static async Task<List<Course>> GetCourses(UserParams userParams)
        {
            string url = apiAddress + "courses?enrollment_type=teacher&page=" + userParams.PageNumber.ToString() + "&per_page=" + userParams.PageSize.ToString();
            var restClient = new RestClient(url);
            restClient.AddDefaultHeader("Authorization", "Bearer " + token);
            var request = new RestRequest(Method.GET);
            var response = await restClient.ExecuteTaskAsync<List<Course>>(request);
            return  response.Data;
        }
    }
}