using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NTR20Z.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using NTR20Z.Exceptions;

namespace NTR20Z.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public Reader myJsonObject{get; set;}
        int checkBis = 0;
        public HomeController(ILogger<HomeController> logger)
        {
            myJsonObject = new Reader();

            myJsonObject.availableGroups = new List<string>();
            myJsonObject.availableRooms = new List<string>();
            myJsonObject.availableTeachers = new List<string>();

        }

        public IActionResult Index()
        {
            ViewBag.Warning1 = TempData["message"];
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teacher()
        {
            ViewBag.Warning1 = TempData["message"];
            myJsonObject.ReadActivities();
            myJsonObject.ReadTeachers();
            return View(myJsonObject);
        }

        public IActionResult Group()
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadGroups();
            return View(myJsonObject);
        }

        public IActionResult Classroom()
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadRooms();
            return View(myJsonObject);
        }

        public IActionResult AddActivity()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult AddActivity(Reader check)
        {
            //myJsonObject.slotToCheck = check.newActivity.slot;
            checkBis = check.newActivity.slot;
            return RedirectToAction("AddActivityBis");
        }

        public IActionResult AddActivityBis()
        {   
            myJsonObject.ReadActivities();
            myJsonObject.ReadGroups();
            myJsonObject.ReadRooms();
            myJsonObject.ReadSubjects();
            myJsonObject.ReadTeachers();

            myJsonObject.checkAvailibility(checkBis);

            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> AddActivityBis(Reader check)
        {
            //myJsonObject.activities.Add(check.newActivity);
            try {
            await myJsonObject.InsertActivity(check.newActivity);
            }
            catch(DbUpdateConcurrencyException)
            {
                TempData["message"] = 1;        // już istnieje takie activity
            }
            catch(ElementNotFoundException)
            {
                TempData["message"] = 2;
            }
            return RedirectToAction("Teacher");
        }
        

        public IActionResult AddTeacher()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> AddTeacher(Reader check, string id)
        {
            myJsonObject.chosenTeacher = check.chosenTeacher;
            if (await myJsonObject.InsertTeacher(check.chosenTeacher) == -1)
                TempData["message"] = 1;
            else
                TempData["message"] = 4;

            return RedirectToAction("Index");
        }

        public IActionResult AddGroup()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> AddGroup(Reader check, string id)
        {
            myJsonObject.chosenGroup = check.chosenGroup;
            if (await myJsonObject.InsertGroup(check.chosenGroup) == -1)
                TempData["message"] = 1;
            else
                TempData["message"] = 4;

            return RedirectToAction("Index");
        }

        public IActionResult AddRoom()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> AddRoom(Reader check, string id)
        {
            myJsonObject.chosenRoom = check.chosenRoom;
            if (await myJsonObject.InsertRoom(check.chosenRoom) == -1)
                TempData["message"] = 1;
            else
                TempData["message"] = 4;

            return RedirectToAction("Index");
        }

        public IActionResult AddSubject()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> AddSubject(Reader check, string id)
        {
            myJsonObject.chosenSubject = check.chosenSubject;
            if (await myJsonObject.InsertSubject(check.chosenSubject) == -1)
                TempData["message"] = 1;
            else
                TempData["message"] = 4;

            return RedirectToAction("Index");
        }

        public IActionResult EditWindow( int id)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadGroups();
            myJsonObject.ReadRooms();
            myJsonObject.ReadTeachers();
            myJsonObject.ReadSubjects();
            ViewData["lessonToEditIndex"] = id; 
            myJsonObject.checkAvailibility(myJsonObject.activities[id].slot);
            //int check = id;
            myJsonObject.selectedButton = id;

            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> EditWindowBis(Reader check,  int id)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadGroups();
            myJsonObject.ReadRooms();
            myJsonObject.ReadTeachers();
            myJsonObject.ReadSubjects();

            try
            {
                await myJsonObject.editActivity(check.editedActivity, id);
            }
            catch
            {
                TempData["message"] = 2;
            }
            
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult> DeleteActivity(int id)
        {
            myJsonObject.ReadActivities();
            myJsonObject.selectedButton = id;

            try
            {
                await myJsonObject.removeActivity(id);
            }
            catch
            {
                TempData["Message"] = 2;
            }
            
            return RedirectToAction("Teacher");
        }

        
        public IActionResult RemoveTeacher()
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadTeachers();
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveTeacher(Reader check, string id)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadTeachers();
            try
            {
                int inf = await myJsonObject.removeTeacher(check.chosenTeacher);
                if (inf == -1)
                    TempData["message"] = -1;
            }
            catch (ElementNotFoundException)
            {
                TempData["message"] = 2;
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult RemoveGroup()
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadGroups();
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveGroup(Reader check, string id)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadGroups();
            try
            {
                int inf = await myJsonObject.removeGroup(check.chosenGroup);
                if (inf == -1)
                    TempData["message"] = -1;
            }
            catch (ElementNotFoundException)
            {
                TempData["message"] = 2;
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult RemoveRoom()
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadRooms();
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRoom(Reader check, string id)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadRooms();
            try
            {
                int inf = await myJsonObject.removeRoom(check.chosenRoom);
                if (inf == -1)
                    TempData["message"] = -1;
            }
            catch (ElementNotFoundException)
            {
                TempData["message"] = 2;
            }
            
            return RedirectToAction("Index");
        }

        public IActionResult RemoveSubject()
        {
            myJsonObject.ReadSubjects();
            myJsonObject.ReadActivities();
            return View(myJsonObject);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveSubject(Reader check, string id)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadSubjects();
            try
            {
                int inf = await myJsonObject.removeSubject(check.chosenSubject);
                if (inf == -1)
                    TempData["message"] = -1;
            }
            catch (ElementNotFoundException)
            {
                TempData["message"] = 2;
            }
            
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Classroom(Reader myJsonObject)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadRooms();
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult Group(Reader myJsonObject)
        {
            myJsonObject.ReadActivities();
            myJsonObject.ReadGroups();
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult Teacher(Reader myJsonObject)
        {
            ViewBag.Warning1 = TempData["message"];
            myJsonObject.ReadActivities();
            myJsonObject.ReadTeachers();
            return View(myJsonObject);
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
