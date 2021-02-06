using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;
using static System.Console;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
// using Newtonsoft.Json;



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

            HttpContext.Session.SetString("skillsJson", skillsJson);

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
                        HttpContext.Session.SetString("skillsJson", serialized);
                    }
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
                HttpContext.Session.SetString("Credits", (Courses.Count * 7.5).ToString());
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

            return View();
        }
    }
}