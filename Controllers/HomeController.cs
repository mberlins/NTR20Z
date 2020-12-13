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
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teacher()
        {
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
        public IActionResult AddActivityBis(Reader check)
        {
            //myJsonObject.activities.Add(check.newActivity);
            myJsonObject.InsertActivity(check.newActivity);

            return RedirectToAction("Index");
        }
        

        public IActionResult AddTeacher()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult AddTeacher(Reader check, string id)
        {
            myJsonObject.chosenTeacher = check.chosenTeacher;
            myJsonObject.InsertTeacher(check.chosenTeacher);
            return RedirectToAction("Index");
        }

        public IActionResult AddGroup()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult AddGroup(Reader check, string id)
        {
            myJsonObject.chosenGroup = check.chosenGroup;
            myJsonObject.InsertGroup(check.chosenGroup);
            return RedirectToAction("Index");
        }

        public IActionResult AddRoom()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult AddRoom(Reader check, string id)
        {
            myJsonObject.chosenRoom = check.chosenRoom;
            myJsonObject.InsertRoom(myJsonObject.chosenRoom);
            return RedirectToAction("Index");
        }

        public IActionResult EditWindow( int id)
        {
            ViewData["lessonToEditIndex"] = id; 
            myJsonObject.checkAvailibility(myJsonObject.activities[id].slot);
            //int check = id;
            myJsonObject.selectedButton = id;

            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult EditWindowBis(Reader check,  int id)
        {
            myJsonObject.editActivity(check.editedActivity, id);

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult DeleteActivity(int id)
        {
            myJsonObject.selectedButton = id;
            myJsonObject.removeActivity(id);
            
            return RedirectToAction("Teacher");
        }

        
        public IActionResult RemoveTeacher()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult RemoveTeacher(Reader check, string id)
        {
            myJsonObject.removeTeacher(check.chosenTeacher);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveGroup()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult RemoveGroup(Reader check, string id)
        {
            myJsonObject.removeGroup(check.chosenGroup);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveRoom()
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult RemoveRoom(Reader check, string id)
        {
            myJsonObject.removeRoom(check.chosenRoom);
            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public IActionResult Classroom(Reader myJsonObject)
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult Group(Reader myJsonObject)
        {
            return View(myJsonObject);
        }

        [HttpPost]
        public IActionResult Teacher(Reader myJsonObject)
        {
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
