using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;
using static System.Console;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;



namespace MVCapp.Controllers
{
    public class AddController : Controller
    {
        //
        // GET: /Home/Skills
        //
        [HttpGet]
        public IActionResult Skills()
        {
            string skillsJson;
            List<Skill> Skills;
            using(var sr = new StreamReader(@"./Data/skills.json"))
            {
                skillsJson = sr.ReadToEnd();
                Skills = JsonSerializer.Deserialize<List<Skill>>(skillsJson);
            }
            ViewBag.skills = Skills;

            return View();
        }

        //
        // POST: /Home/Skills
        //
        [HttpPost]
        public IActionResult Skills(Skill model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    List<Skill> Skills;
                    using(var sr = new StreamReader(@"./Data/skills.json"))
                    {
                        string json = sr.ReadToEnd();
                        Skills = JsonSerializer.Deserialize<List<Skill>>(json);
                        Skills.Add(model);
                    }

                    using(var sr = new StreamWriter(@"./Data/skills.json"))
                    {
                        string serialized = JsonSerializer.Serialize(Skills);
                        sr.Write(serialized);
                    }
                    
                    ViewBag.skills = Skills;
                }
                catch
                {
                    WriteLine("Could not write skills...");
                }

                ModelState.Clear();
            }
            return View();
        }



        //
        // GET: /Home/Work
        //
        [HttpGet]
        public IActionResult Work()
        {
            List<Work> Work;
            using(var sr = new StreamReader(@"./Data/work.json"))
            {
                string json = sr.ReadToEnd();
                Work = JsonSerializer.Deserialize<List<Work>>(json);
            }

            ViewBag.work = Work;

            return View();
        }

        //
        // POST: /Home/Work
        //
        [HttpPost]
        public IActionResult Work(Work model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    List<Work> Work;
                    using(var sr = new StreamReader(@"./Data/work.json"))
                    {
                        string json = sr.ReadToEnd();
                        Work = JsonSerializer.Deserialize<List<Work>>(json);
                        Work.Add(model);
                    }

                    using(var sr = new StreamWriter(@"./Data/work.json"))
                    {
                        string serialized = JsonSerializer.Serialize(Work);
                        sr.Write(serialized);
                    }

                    ViewBag.work = Work;
                }
                catch
                {
                    WriteLine("Could not write work...");
                }

                ModelState.Clear();
            }
          
            return View();
        }

        

        //
        // GET: /Home/Courses
        //
        [HttpGet]
        public IActionResult Courses()
        {
            List<Course> Courses;
            using(var sr = new StreamReader(@"./Data/courses.json"))
            {
                string json = sr.ReadToEnd();
                Courses = JsonSerializer.Deserialize<List<Course>>(json);
            }

            ViewData["Courses"] = Courses;

            return View();
        }

        //
        // POST: /Home/Courses
        //
        [HttpPost]
        public IActionResult Courses(Course model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    List<Course> Courses;
                    using(var sr = new StreamReader(@"./Data/courses.json"))
                    {
                        string json = sr.ReadToEnd();
                        Courses = JsonSerializer.Deserialize<List<Course>>(json);
                        Courses.Add(model);
                    }

                    using(var sr = new StreamWriter(@"./Data/courses.json"))
                    {
                        string serialized = JsonSerializer.Serialize(Courses);
                        sr.Write(serialized);
                    }

                    ViewData["Courses"] = Courses;
                }
                catch
                {
                    WriteLine("Could not write courses...");
                }

                ModelState.Clear();
            }

            return View();
        }
    }
}