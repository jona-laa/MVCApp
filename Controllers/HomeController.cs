using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;



namespace MVCapp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        //
        [HttpGet]
        public IActionResult Index()
        {
            List<Course> Courses;
            using(var sr = new StreamReader(@"./Data/courses.json"))
            {
                string json = sr.ReadToEnd();
                Courses = JsonSerializer.Deserialize<List<Course>>(json);
                HttpContext.Session.SetString("Credits", (Courses.Count * 7.5).ToString());
            }



            List<Work> Work;
            using(var sr = new StreamReader(@"./Data/work.json"))
            {
                string json = sr.ReadToEnd();
                Work = JsonSerializer.Deserialize<List<Work>>(json);
            }
            ViewData["Work"] = Work;



            List<Skill> Skills;
            using(var sr = new StreamReader(@"./Data/skills.json"))
            {
                string json = sr.ReadToEnd();
                Skills = JsonSerializer.Deserialize<List<Skill>>(json);
            }
            ViewBag.skills = Skills;



            ViewModel vm = new ViewModel
            {
                CoursesList = Courses
            };

            return View(vm);
        }
    }
}