using GalaSoft.MvvmLight;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace VNM2020.Models
{
    public class Action : ObservableObject
    {
        public int ActionId { get; set; }
        public int HostId { get; set; }       

        public DateTime Date { get; set; }
        
        public string Status { get; set; }

        public long Time { get; set; }

        [NotMapped]
        public long Reply { get; set; }

       
        [NotMapped]
        public int Count { get; set; }

       
        [NotMapped]
        public long PrevReply { get; set; }
       
        [NotMapped]
        public int PrevCount { get; set; }

        [NotMapped]
        public string ToolTip { get; set; }

        public Action(DateTime date, string status, long time,int hostId)
        {
            Date = date;          
            Time = time;
            HostId = hostId;
            Status = status;
            ToolTip = $"{status} {date:dd.MMM HH:mm:ss} ReplyTime: {time} ms";
        }
    }
}
