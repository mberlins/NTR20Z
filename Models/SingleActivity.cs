using System;
using System.Text.Json;

namespace NTR20Z.Models 
{
    public class SingleActivity
    {
        public int slot{get;set;}
        public string room{get; set;}
        public string group{get; set;}
        public string teacher{get;set;}
        public string subject{get;set;}

        /*public SingleActivity(string sl, string ro, string gr, string te, string sub)
        {
            slot = Int32.Parse(sl);
            room = ro;
            group = gr;
            teacher = te;
            subject = sub;
        }
*/
    }
}