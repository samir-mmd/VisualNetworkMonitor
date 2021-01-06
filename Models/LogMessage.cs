using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VNM2020.Models
{
    public class LogMessage : ObservableObject
    {
        public DateTime date;      
        public DateTime Date { get => date; set => Set(ref date, value); }

        public string status;
        public string Status { get => status; set => Set(ref status, value); }

        public string source;
        public string Source { get => source; set => Set(ref source, value); }

        public string subject;
        public string Subject { get => subject; set => Set(ref subject, value); }

        public LogMessage(DateTime date, string status, string source, string subject)
        {
            Date = date;
            Status = status;
            Source = source;
            Subject = subject;
        }
    }
}
