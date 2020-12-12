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
        public string chosen {get; set;}
        public string chosenTeacher{get;set;}
        public string chosenGroup{get;set;}
        public string chosenRoom{get;set;}
        public int selectedButton {get;set;}
        public int slotToCheck{get;set;}

        public SingleActivity editedActivity{get;set;}
        public SingleActivity newActivity{get;set;}
        /*public string[] groups {get; set;}
        public string[] teachers {get; set;}
        public string[] subjects {get; set;}
        public string[] rooms {get; set;}*/

        public List<string> groups {get; set;}
        public List<string> teachers {get; set;}
        public List<string> subjects {get; set;}
        public List<string> rooms {get; set;}

        public List<string> availableGroups{get;set;}
        public List<string> availableTeachers{get;set;}
        public List<string> availableRooms{get;set;}

        public List<SingleActivity> activities {get; set;}

        public Reader()
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
                var slots = context.Slot;
                var activitiess = context.ActivityBis;

                foreach(var t in teach)
                {
                    string tmp = t.name;
                    teachers.Add(tmp);
                }

                foreach(var t in subs)
                {
                    subjects.Add(t.name);
                }

                foreach(var t in groupss)
                {
                    groups.Add(t.name);
                }

                foreach(var t in roomss)
                {
                    rooms.Add(t.name);
                }

                int i = 0;
                foreach(var t in activitiess)
                {
                    
                    SingleActivity acti = new SingleActivity();
                    //acti.slot = Int32.Parse(t.Slot.name);
                    acti.slot = i++;
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
        }
        
        public void removeActivity(int index)
        {
            activities.RemoveAt(index);
        }

        public void removeTeacher(string name)
        {
            int index = 1 ;

            for (int i=0; i<teachers.Count; i++)
            {
                if(teachers[i]==name)
                {
                    index = i;
                    break;
                }
            }

            
           
            teachers.RemoveAt(index);

            for(int i =0; i < activities.Count; i++)
            {
               
                if (activities[i].teacher == name)
                    activities[i].teacher = "Brak";
            }

        }

        public void removeGroup(string name)
        {
            int index = 1 ;

            for (int i=0; i<groups.Count; i++)
            {
                if(groups[i]==name)
                {
                    index = i;
                    break;
                }
            }

            groups.RemoveAt(index);

            for(int i =0; i < activities.Count; i++)
            {
               
                if (activities[i].group == name)
                    activities[i].group = "Brak";
            }

        }

        public void removeRoom(string name)
        {
            int index = 1 ;

            for (int i=0; i<rooms.Count; i++)
            {
                if(rooms[i]==name)
                {
                    index = i;
                    break;
                }
            }

            rooms.RemoveAt(index);

            for(int i =0; i < activities.Count; i++)
            {
               
                if (activities[i].room == name)
                    activities[i].room = "Brak";
            }

        }

        public void checkAvailibility(int slotToCheck)
        {
            availableGroups.Clear();
            availableRooms.Clear();
            availableTeachers.Clear();

            for(int i = 0; i < groups.Count; i++)
            {
                availableGroups.Add(groups[i]);
            }
            for(int i = 0; i < rooms.Count; i++)
            {
                availableRooms.Add(rooms[i]);
            }
            for(int i = 0; i < teachers.Count; i++)
            {
                availableTeachers.Add(teachers[i]);
            }

            for (int i =0; i <activities.Count; i++)
            {
                if(activities[i].slot == slotToCheck)
                {
                    availableGroups.Remove(activities[i].group);
                    availableRooms.Remove(activities[i].room);
                    availableTeachers.Remove(activities[i].teacher);
                }
            }
        }


        public void InsertActivity(SingleActivity act)
        {
            using(var context = new LibraryContext())
            { 
                // Creates the database if not exists
                context.Database.EnsureCreated();

              Subject subject = new Subject();
              subject.name = act.subject;
              subject.comment = " ";
              context.Subject.Add(subject);
              

              var classgroup = new Classgroup();
              classgroup.name = act.group;
              classgroup.comment = " ";
              context.Classgroup.Add(classgroup);
              

              Room room = new Room();
              room.name = act.room;
              room.comment = " ";
              context.Room.Add(room);
              

              Slot slot = new Slot();
              slot.name = act.slot.ToString();
              slot.comment = "komentarz";
              context.Slot.Add(slot);
              

              Teacher teacherBis = new Teacher();
              teacherBis.name = act.teacher;
              teacherBis.comment = " ";
              context.Teacher.Add(teacherBis);
              

              ActivityBis activityBis = new ActivityBis();
              activityBis.Teacher = teacherBis;
              activityBis.Subject = subject;
              activityBis.Classgroup = classgroup;
              activityBis.Room = room;
              activityBis.Slot = slot;

              context.ActivityBis.Add(activityBis);
              context.SaveChanges();
            }
        }


        public void InsertTeacher(string te)
        {
            using(var context = new LibraryContext())
            { 
                // Creates the database if not exists
                context.Database.EnsureCreated();

                Teacher teacherBis = new Teacher();
                teacherBis.name = te;
                teacherBis.comment = " ";
                context.Teacher.Add(teacherBis);
                context.SaveChanges();
            }
        }

        public void InsertGroup(string gr)
        {
            using(var context = new LibraryContext())
            { 
                // Creates the database if not exists
                context.Database.EnsureCreated();

                Classgroup classGroupBis = new Classgroup();
                classGroupBis.name = gr;
                classGroupBis.comment = " ";
                context.Classgroup.Add(classGroupBis);
                context.SaveChanges();
            }
        }

        public void InsertRoom(string cl)
        {
            using(var context = new LibraryContext())
            { 
                // Creates the database if not exists
                context.Database.EnsureCreated();

                Room roomBis = new Room();
                roomBis.name = cl;
                roomBis.comment = " ";
                context.Room.Add(roomBis);
                context.SaveChanges();
            }
        }
    }
}