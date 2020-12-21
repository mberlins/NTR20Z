using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Text;
using NTR20Z.Models;

namespace NTR20Z.Models
{
    public class Reader
    {
        public string chosen { get; set; }
        public string chosenTeacher { get; set; }
        public string chosenGroup { get; set; }
        public string chosenRoom { get; set; }
        public string chosenSubject {get;set;}
        public int selectedButton { get; set; }
        public int slotToCheck { get; set; }

        public SingleActivity editedActivity { get; set; }
        public SingleActivity newActivity { get; set; }
        /*public string[] groups {get; set;}
        public string[] teachers {get; set;}
        public string[] subjects {get; set;}
        public string[] rooms {get; set;}*/

        public List<string> groups { get; set; }
        public List<string> teachers { get; set; }
        public List<string> subjects { get; set; }
        public List<string> rooms { get; set; }

        public List<string> availableGroups { get; set; }
        public List<string> availableTeachers { get; set; }
        public List<string> availableRooms { get; set; }

        public List<SingleActivity> activities { get; set; }

        /*public Reader()
        {
            teachers = new List<string>();
            groups = new List<string>();
            subjects = new List<string>();
            rooms = new List<string>();
            activities = new List<SingleActivity>();

            using (var context = new LibraryContext())
            {
                var teach = context.Teacher;
                var subs = context.Subject;
                var groupss = context.Classgroup;
                var roomss = context.Room;
                var activitiess = context.ActivityBis.Include(p => p.Slot);

                foreach (var t in teach)
                {
                    string tmp = t.name;
                    teachers.Add(tmp);
                }

                foreach (var t in subs)
                {
                    subjects.Add(t.name);
                }

                foreach (var t in groupss)
                {
                    groups.Add(t.name);
                }

                foreach (var t in roomss)
                {
                    rooms.Add(t.name);
                }


                foreach (var t in activitiess)
                {

                    SingleActivity acti = new SingleActivity();
                    acti.slot = Int32.Parse(t.Slot.name);

                    //acti.slot = t.Slot.slotID;
                    acti.subject = t.Subject.name;
                    acti.teacher = t.Teacher.name;
                    acti.room = t.Room.name;
                    acti.group = t.Classgroup.name;
                    //SingleActivity acti = new SingleActivity(t.Slot.name, t.Room.name, t.Classgroup.name, t.Teacher.name, t.Subject.name);
                    activities.Add(acti);
                    //Console.WriteLine(t.Slot.slotID);
                    Console.WriteLine(t.Subject.name);
                    Console.WriteLine(t.Teacher.name);
                    Console.WriteLine(t.Room.name);
                    Console.WriteLine(t.Classgroup.name);
                }
            }
        }*/

        public void ReadTeachers()
        {
            teachers = new List<string>();

            using (var context = new LibraryContext())
            {
                var teach = context.Teacher;

                foreach (var t in teach)
                {
                    string tmp = t.name;
                    teachers.Add(tmp);
                }
            }
        }

        public void ReadRooms()
        {
            rooms = new List<string>();

            using (var context = new LibraryContext())
            {
                var rm = context.Room;

                foreach (var r in rm)
                {
                    string tmp = r.name;
                    rooms.Add(tmp);
                }
            }
        }

        public void ReadGroups()
        {
            groups = new List<string>();

            using (var context = new LibraryContext())
            {
                var gr = context.Classgroup;

                foreach (var g in gr)
                {
                    string tmp = g.name;
                    groups.Add(tmp);
                }
            }
        }

        public void ReadSubjects()
        {
            subjects = new List<string>();

            using (var context = new LibraryContext())
            {
                var sub = context.Subject;

                foreach (var s in sub)
                {
                    string tmp = s.name;
                    subjects.Add(tmp);
                }
            }
        }

        public void ReadActivities()
        {
            activities = new List<SingleActivity>();

            using (var context = new LibraryContext())
            {
                var activitiess = context.ActivityBis.Include(s => s.Slot).Include(r => r.Room).Include(t => t.Teacher)
                                                    .Include(x => x.Subject).Include(c => c.Classgroup);

                foreach (var t in activitiess)
                {
                    SingleActivity acti = new SingleActivity();
                    acti.slot = Int32.Parse(t.Slot.name);

                    acti.subject = t.Subject.name;
                    acti.teacher = t.Teacher.name;
                    acti.room = t.Room.name;
                    acti.group = t.Classgroup.name;
                    
                    activities.Add(acti);
                }
            }
        }

        public void removeActivity(int id)
        {
            string te = activities[id].teacher;
            string sl = activities[id].slot.ToString();

            using(var context = new LibraryContext())
            {
                var activitiesBis = from a in context.ActivityBis where (a.Teacher.name == te && a.Slot.name == sl) select a;
                var activityTer = activitiesBis.Single();
                context.ActivityBis.Remove(activityTer);
                context.SaveChanges();
            }
        }

        public void removeTeacher(string nameToDelete)
        {
            for (int i =0; i < activities.Count; i++)
            {
                if (activities[i].teacher == nameToDelete)
                    return;
            }
            
            using(var context = new LibraryContext())
            {
                var teachers = from t in context.Teacher where t.name == nameToDelete select t;

                var teacher = teachers.Single();
                context.Teacher.Remove(teacher);
                context.SaveChanges();
            }
        }

        public void removeGroup(string nameToDelete)
        {
            for (int i =0; i < activities.Count; i++)
            {
                if (activities[i].group == nameToDelete)
                    return;
            }
            
            using(var context = new LibraryContext())
            {
                var groups = from g in context.Classgroup where g.name == nameToDelete select g;

                var groupBis = groups.Single();
                context.Classgroup.Remove(groupBis);
                context.SaveChanges();
            }
        }

        public void removeSubject(string nameToDelete)
        {
            for (int i =0; i < activities.Count; i++)
            {
                if (activities[i].subject == nameToDelete)
                    return;
            }
            
            using(var context = new LibraryContext())
            {
                var subjects = from g in context.Subject where g.name == nameToDelete select g;

                var subjectBis = subjects.Single();
                context.Subject.Remove(subjectBis);
                context.SaveChanges();
            }
        }

        public void removeRoom(string nameToDelete)
        {
            for (int i =0; i < activities.Count; i++)
            {
                if (activities[i].room == nameToDelete)
                    return;
            }
            
            using(var context = new LibraryContext())
            {
                var rooms = from r in context.Room where r.name == nameToDelete select r;

                var roomBis = rooms.Single();
                context.Room.Remove(roomBis);
                context.SaveChanges();
            }
        }

        public void checkAvailibility(int slotToCheck)
        {
            availableGroups.Clear();
            availableRooms.Clear();
            availableTeachers.Clear();

            for (int i = 0; i < groups.Count; i++)
            {
                availableGroups.Add(groups[i]);
            }
            for (int i = 0; i < rooms.Count; i++)
            {
                availableRooms.Add(rooms[i]);
            }
            for (int i = 0; i < teachers.Count; i++)
            {
                availableTeachers.Add(teachers[i]);
            }

            for (int i = 0; i < activities.Count; i++)
            {
                if (activities[i].slot == slotToCheck)
                {
                    availableGroups.Remove(activities[i].group);
                    availableRooms.Remove(activities[i].room);
                    availableTeachers.Remove(activities[i].teacher);
                }
            }
        }

        public void editActivity(SingleActivity acti, int id)
        {
            string te = activities[id].teacher;
            string sl = activities[id].slot.ToString();

            //string te = "Zbyszek";
            //string sl = "13";

            using (var context = new LibraryContext())
            {
                var teach = context.Teacher;
                var subs = context.Subject;
                var groupss = context.Classgroup;
                var roomss = context.Room;
                var slotss = context.Slot;
                var activitiess = context.ActivityBis.Include(p => p.Slot).Include(t => t.Teacher).Include(r => r.Room)
                                                        .Include(c => c.Classgroup).Include(s => s.Subject);

                var ActivitiesBis = from a in activitiess where (a.Teacher.name == te && a.Slot.name == sl) select a;
                var activityTer = ActivitiesBis.Single();

                foreach (var s in subs)
                {
                    if (s.name == acti.subject)
                        activityTer.Subject = s;
                }

                foreach (var t in teach)
                {
                    if (t.name == acti.teacher)
                        activityTer.Teacher = t;
                }

                foreach (var g in groupss)
                {
                    if (g.name == acti.group)
                        activityTer.Classgroup = g;
                }

                foreach (var r in roomss)
                {
                    if (r.name == acti.room)
                        activityTer.Room = r;
                }

                activityTer.TimeStamp = DateTime.Now;
                context.SaveChanges();
            }
        }

        public async Task InsertActivity(SingleActivity act)
        {
            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                int checkBis = 0;
                var teach = context.Teacher;
                var subs = context.Subject;
                var groupss = context.Classgroup;
                var roomss = context.Room;
                var slotss = context.Slot;
                var activitiess = context.ActivityBis.Include(p => p.Slot);



                ActivityBis newActivityBis = new ActivityBis();

                foreach (var s in subs)
                {
                    if (s.name == act.subject)
                        newActivityBis.Subject = s;
                }

                foreach (var t in teach)
                {
                    if (t.name == act.teacher)
                        newActivityBis.Teacher = t;
                }

                foreach (var g in groupss)
                {
                    if (g.name == act.group)
                        newActivityBis.Classgroup = g;
                }

                foreach (var r in roomss)
                {
                    if (r.name == act.room)
                        newActivityBis.Room = r;
                }

                foreach (var s in slotss)
                {
                    if (s.name == act.slot.ToString())
                    {
                        newActivityBis.Slot = s;
                        checkBis = 1;
                    }
                }

                if (checkBis == 0)
                {
                    Slot slot = new Slot();
                    slot.name = act.slot.ToString();
                    slot.comment = " ";
                    context.Slot.Add(slot);
                    newActivityBis.Slot = slot;
                }

                foreach(var a in activitiess)
                {
                    if ( a.Slot.name == newActivityBis.Slot.name && (a.Teacher.name == newActivityBis.Teacher.name ||
                    a.Room.name == newActivityBis.Room.name || a.Classgroup.name == newActivityBis.Classgroup.name))
                        throw new DbUpdateConcurrencyException();
                }

                newActivityBis.TimeStamp = DateTime.Now;
                await context.ActivityBis.AddAsync(newActivityBis);
                await context.SaveChangesAsync();
            }
        }


        public void InsertTeacher(string te)
        {
            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                Teacher teacherBis = new Teacher();
                teacherBis.comment = " ";
                teacherBis.TimeStamp = DateTime.Now;

                if( te != null)
                {
                    teacherBis.name = te;
                    context.Teacher.Add(teacherBis);
                    context.SaveChanges();
                }
                else 
                {
                    teacherBis.name = " ";
                    context.Teacher.Add(teacherBis);
                    context.SaveChanges();
                }
                
            }
        }

        public void InsertGroup(string gr)
        {
            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                Classgroup classGroupBis = new Classgroup();
                classGroupBis.comment = " ";
                classGroupBis.TimeStamp = DateTime.Now;

                if (gr != null)
                {
                    classGroupBis.name = gr;
                    context.Classgroup.Add(classGroupBis);
                    context.SaveChanges();
                }
                else
                {
                    classGroupBis.name = " ";
                    context.Classgroup.Add(classGroupBis);
                    context.SaveChanges();
                }           
            }
        }

        public void InsertRoom(string cl)
        {
            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                Room roomBis = new Room();
                roomBis.comment = " ";
                roomBis.TimeStamp = DateTime.Now;

                if (cl != null)
                {                   
                    roomBis.name = cl;
                    context.Room.Add(roomBis);
                    context.SaveChanges();
                }
                else
                {
                    roomBis.name = " ";
                    context.Room.Add(roomBis);
                    context.SaveChanges();
                }
                
            }
        }

        public void InsertSubject(string cl)
        {
            using (var context = new LibraryContext())
            {
                // Creates the database if not exists
                context.Database.EnsureCreated();

                Subject subjectBis = new Subject();
                subjectBis.comment = " ";
                subjectBis.TimeStamp = DateTime.Now;

                if ( cl != null)
                {
                    subjectBis.name = cl;
                    context.Subject.Add(subjectBis);
                    context.SaveChanges();
                }
                else 
                {
                    subjectBis.name = " ";
                    context.Subject.Add(subjectBis);
                    context.SaveChanges();
                }
                
            }
        }

        
    }
}