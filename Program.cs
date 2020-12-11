using System;
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

namespace NTR20Z
{
  public class Program
  {
    public static void Main(string[] args)
    {
      //InsertData(0);
      InsertData(1);
      CreateHostBuilder(args).Build().Run();
  
    }

    public static IHostBuilder CreateHostBuilder(string[] args)=>
      Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(webBuilder =>
        {
          webBuilder.UseStartup<Startup>();
        });

    private static void InsertData(int i)
    {
      using(var context = new LibraryContext())
      {
        // Creates the database if not exists
        context.Database.EnsureCreated();

        if (i == 0)
        {
              Subject subject = new Subject();
              //subject.subjectID = 1;
              subject.name = "przyrka";
              subject.comment = "no przyrka";
              context.Subject.Add(subject);
              

              var classgroup = new Classgroup();
              //classgroup.classgroupID = 1;
              classgroup.name = "1A";
              classgroup.comment = "przyglupy";
              context.Classgroup.Add(classgroup);
              

              Room room = new Room();
              //room.roomID = 1;
              room.name = "15";
              room.comment = "smierdzi tu";
              context.Room.Add(room);
              

              Slot slot = new Slot();
              //slot.slotID = 1;
              slot.name = "1";
              slot.comment = "komentarz";
              context.Slot.Add(slot);
              

              Teacher teacherBis = new Teacher();
              //teacherBis.teacherID = 1;
              teacherBis.name = "Albert";
              teacherBis.comment = "od przyrki";
              context.Teacher.Add(teacherBis);
              

              ActivityBis activityBis = new ActivityBis();
              //activityBis.activityID = 1;
              activityBis.Teacher = teacherBis;
              activityBis.Subject = subject;
              activityBis.Classgroup = classgroup;
              activityBis.Room = room;
              activityBis.Slot = slot;

              context.ActivityBis.Add(activityBis);
              context.SaveChanges();
        }
        else 
        {

            Teacher teacherTer = new Teacher();
              //teacherTer.teacherID = 1;
              teacherTer.name = "Julian";
              teacherTer.comment = "od majzy";
              context.Teacher.Add(teacherTer);

            Subject subjectBis = new Subject();
              //subject.subjectID = 1;
              subjectBis.name = "majza";
              subjectBis.comment = "no majza";
              context.Subject.Add(subjectBis);

            Classgroup classgroupBis = new Classgroup();
              //classgroup.classgroupID = 1;
              classgroupBis.name = "2A";
              classgroupBis.comment = "tez przyglupy";
              context.Classgroup.Add(classgroupBis);

              Room roomBis = new Room();
              //room.roomID = 1;
              roomBis.name = "20";
              roomBis.comment = "tu pachnie";
              context.Room.Add(roomBis);

              Slot slotBis = new Slot();
              //slot.slotID = 1;
              slotBis.name = "2";
              slotBis.comment = "bez komentarza";
              context.Slot.Add(slotBis);


            ActivityBis activityTer = new ActivityBis();
            //activityBis.activityID = 1;
            activityTer.Teacher = teacherTer;
            activityTer.Subject = subjectBis;
            activityTer.Classgroup = classgroupBis;
            activityTer.Room = roomBis;
            activityTer.Slot = slotBis;

            context.ActivityBis.Add(activityTer);
            context.SaveChanges();
        }
        

        

        // Adds a publisher
        /*var publisher = new Publisher
        {
          Name = "Mariner Books"
        };
        //context.Publisher.Add(publisher);

        // Adds some books
        context.Book.Add(new Book
        {
          ISBN = "978-0544003415",
          Title = "The Lord of the Rings",
          Author = "J.R.R. Tolkien",
          Language = "English",
          Pages = 1216,
          Publisher = publisher
        });
        context.Book.Add(new Book
        {
          ISBN = "978-0547247762",
          Title = "The Sealed Letter",
          Author = "Emma Donoghue",
          Language = "English",
          Pages = 416,
          Publisher = publisher
        });
       context.Book.Add(new Book
        {
          ISBN = "978-05472477126",
          Title = "La peste",
          Author = "Albert Camus",
          Language = "Francais",
          Pages = 416,
          Publisher = publisher
        });
        // Saves changes
        context.SaveChanges();*/
      }
    }

    /*private static void PrintData()
    {
      // Gets and prints all books in database
      using (var context = new LibraryContext())
      {
        var books = context.Book
          .Include(p => p.Publisher);
        foreach(var book in books)
        {
          var data = new StringBuilder();
          data.AppendLine($"ISBN: {book.ISBN}");
          data.AppendLine($"Title: {book.Title}");
          data.AppendLine($"Publisher: {book.Publisher.Name}");
          Console.WriteLine(data.ToString());
        }
      }
    }*/
  }
}