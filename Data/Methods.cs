using System.Collections.Generic;
using CanvasApp.API.Models;
using RestSharp;

namespace CanvasApp.API.Data
{
    public class Methods
    {
        const string token = "9595~hpVWVTBD3bwHmWmwYFFPbO6AMngoLEoHsSx3DySHys4wedeciMKuARvd79YHWmUx";
        const string apiAddress = "https://rmit.instructure.com:443/api/v1/";

        public static List<Course> GetCourses()
        {
            //Gets a list of the courses which the user is enrolled in for which they are a teacher
            string url = $"{apiAddress}courses?enrollment_type=teacher&per_page=10&access_token={token}";
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = restClient.Execute<List<Course>>(request);
            return response.Data;
        }

        public static List<CanvasUser> GetStudentsInCourseBySisId(string sis_course_id)
        {

            //Gets a list of students for a SIS course Id
            string url = $"https://rmit.instructure.com/api/v1/courses/sis_course_id:{sis_course_id}/users?enrollment_type[]=student&include[]=enrollments&per_page=1000&access_token={token}";
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = restClient.Execute<List<CanvasUser>>(request);
            return response.Data;
        }


        public static List<CanvasUser> GetStudentsInCourseById(int id)
        {
            var courseId = id.ToString();

            //Gets a list of students for a SIS course Id
            string url = $"https://rmit.instructure.com:443/api/v1/courses/{courseId}/students?per_page=1000&access_token={token}";
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.GET);
            var response = restClient.Execute<List<CanvasUser>>(request);
            return response.Data;
        }

        //sis_user_id:E78213
        public static string EnrollTeacherInCourse(int course_id, string sis_user_id)
        {
            string s = string.Empty;
            string url = $"https://rmit.instructure.com:443/api/v1/courses/{course_id}/enrollments?&access_token={token}";
            var restClient = new RestClient(url);
            var request = new RestRequest(Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddParameter("enrollment[user_id]","sis_user_id:" + sis_user_id);
            request.AddParameter("enrollment[type]", "TeacherEnrollment");
            request.AddParameter("enrollment[enrollment_state]", "active");
            request.AddParameter("enrollment[notify]", "false");

            IRestResponse response = restClient.Execute(request);

            s = response.StatusDescription.ToString();
            s = s + "<br />" + response.Content;
            s = s + "<br />" + response.ErrorMessage;
            //enrollment[user_id]=sis_user_id%3AE78213&enrollment[type]=TeacherEnrollment&enrollment[enrollment_state]=active&enrollment[notify]=false
            return s;
        }
    }
}