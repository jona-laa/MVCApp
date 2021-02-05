using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;
using static System.Console;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;



namespace MVCapp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Course> Courses;
            using(var sr = new StreamReader(@"./Data/courses.json"))
            {
                string json = sr.ReadToEnd();
                Courses = JsonSerializer.Deserialize<List<Course>>(json);
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



        [HttpGet]
        public IActionResult Skills()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Skills(Skill model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    List<Skill> JsonObj;
                    using(var sr = new StreamReader(@"./Data/skills.json"))
                    {
                        string json = sr.ReadToEnd();
                        JsonObj = JsonSerializer.Deserialize<List<Skill>>(json);
                        JsonObj.Add(model);
                    }

                    using(var sr = new StreamWriter(@"./Data/skills.json"))
                    {
                        string serialized = JsonSerializer.Serialize(JsonObj);
                        sr.Write(serialized);
                    }
                }
                catch
                {
                    WriteLine("Could not write skills...");
                }

                ModelState.Clear();
            }
            else
            {
                // Other tings
            }

            return View();
        }



        [HttpGet]
        public IActionResult Work()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Work(Work model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    List<Work> JsonObj;
                    using(var sr = new StreamReader(@"./Data/work.json"))
                    {
                        string json = sr.ReadToEnd();
                        JsonObj = JsonSerializer.Deserialize<List<Work>>(json);
                        JsonObj.Add(model);
                    }

                    using(var sr = new StreamWriter(@"./Data/work.json"))
                    {
                        string serialized = JsonSerializer.Serialize(JsonObj);
                        sr.Write(serialized);
                    }
                }
                catch
                {
                    WriteLine("Could not write work...");
                }

                ModelState.Clear();
            }
            else
            {
                // Other tings
            }
          
            return View();
        }

        

        [HttpGet]
        public IActionResult Courses()
        {
            // Get Courses
            // List<Course> Courses;
            // using(var sr = new StreamReader(@"./Data/courses.json"))
            // {
            //     string json = sr.ReadToEnd();
            //     Courses = JsonSerializer.Deserialize<List<Course>>(json);
            // }

            // ViewData["Message"] = "Message from ViewData";
            // ViewBag.message = "Message from ViewBag";

            // ViewData["Courses"] = Courses;

            // ViewModel vm = new ViewModel
            // {
            //     CoursesList = Courses
            // };

            // return View(vm);
            return View();
        }

        [HttpPost]  // Använd om formulär skickas
        public IActionResult Courses(Course model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    List<Course> JsonObj;
                    using(var sr = new StreamReader(@"./Data/courses.json"))
                    {
                        string json = sr.ReadToEnd();
                        JsonObj = JsonSerializer.Deserialize<List<Course>>(json);
                        JsonObj.Add(model);
                    }

                    using(var sr = new StreamWriter(@"./Data/courses.json"))
                    {
                        string serialized = JsonSerializer.Serialize(JsonObj);
                        sr.Write(serialized);
                    }
                }
                catch
                {
                    WriteLine("Could not write courses...");
                }

                ModelState.Clear();
            }
            else
            {
                // Other tings
            }
            return View();
        }
    }
}