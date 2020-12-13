using System.Collections.Generic;
using System.Windows;
using System;

namespace NTR20Z.Models
{
  public class Teacher
  {
    public int teacherID{get;set;}
    //[Column(TypeName = "varchar(MAX)")]
    //[MaxLength(30)]
    public string name {get;set;}
    public string comment {get;set;}
    public DateTime TimeStamp {get;set;}
    public ICollection<ActivityBis> Activities{get;set;}
    
  }

  public class Subject
  {
    public int subjectID {get;set;}
    public string name {get;set;}
    public string comment{get;set;}
    public DateTime TimeStamp {get;set;}
    public ICollection<ActivityBis> Activities{get;set;}
  }

  public class Classgroup
  {
    public int classgroupID{get;set;}
    public string name{get;set;}
    public string comment{get;set;}
    public DateTime TimeStamp {get;set;}
    public ICollection<ActivityBis> Activities{get;set;}
  }

  public class Room
  {
    public int roomID{get;set;}
    public string name {get;set;}
    public string comment{get;set;}
    public DateTime TimeStamp {get;set;}
    public ICollection<ActivityBis> Activities{get;set;}
  }

  public class Slot
  {
    public int slotID{get;set;}
    public string name {get;set;}
    public string comment {get;set;}
    public DateTime TimeStamp {get;set;}
    public ICollection<ActivityBis> Activities{get;set;}
  }

  public class ActivityBis
  {
    public int activityID{get;set;}
    public virtual Teacher Teacher {get;set;}
    public virtual Subject Subject {get;set;}
    public virtual Classgroup Classgroup {get;set;}
    public virtual Room Room {get;set;}
    public virtual Slot Slot {get;set;}
    public DateTime TimeStamp {get;set;}
  }
}