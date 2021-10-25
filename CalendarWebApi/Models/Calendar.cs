using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace CalendarWebApi.Models
{
    public partial class Calendar
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public long? Time { get; set; }
        public string EventOrganizer { get; set; }
        public string Members { get; set; }
    }
}
