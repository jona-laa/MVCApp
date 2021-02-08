using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;



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
            List<Skill> Skills;
            using(var sr = new StreamReader(@"./Data/skills.json"))
            {
                string json = sr.ReadToEnd();
                Skills = JsonSerializer.Deserialize<List<Skill>>(json);
            }

            if(ModelState.IsValid)
            {
                Skills.Add(model);

                using(var sr = new StreamWriter(@"./Data/skills.json"))
                {
                    string serialized = JsonSerializer.Serialize(Skills);
                    sr.Write(serialized);
                }

                return RedirectToAction("Skills");       
                // ModelState.Clear();
            }

            ViewBag.skills = Skills;
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
            List<Work> Work;
            using(var sr = new StreamReader(@"./Data/work.json"))
            {
                string json = sr.ReadToEnd();
                Work = JsonSerializer.Deserialize<List<Work>>(json);
            }

            if(ModelState.IsValid)
            {
                Work.Add(model);

                using(var sr = new StreamWriter(@"./Data/work.json"))
                {
                    string serialized = JsonSerializer.Serialize(Work);
                    sr.Write(serialized);
                }

                return RedirectToAction("Work");       
            }

            ViewBag.work = Work;
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

            // return View(model);
            return View();
        }

        //
        // POST: /Home/Courses
        //
        [HttpPost]
        public IActionResult Courses(Course model)
        {
            List<Course> Courses;
            using(var sr = new StreamReader(@"./Data/courses.json"))
            {
                string json = sr.ReadToEnd();
                Courses = JsonSerializer.Deserialize<List<Course>>(json);
            }
            
            if(ModelState.IsValid)
            {
                Courses.Add(model);

                using(var sr = new StreamWriter(@"./Data/courses.json"))
                {
                    string serialized = JsonSerializer.Serialize(Courses);
                    sr.Write(serialized);
                }

                return RedirectToAction("Courses");
            }

            ViewData["Courses"] = Courses;
            return View();
        }
    }
}