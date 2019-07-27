﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLearning.Shared.Models
{
    [Table("Subject")] 
    public class Subject
    {
        public Subject()
        {
            DateSheet = new List<TimeTable>();
        }
       public int Id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        [MaxLength(20,ErrorMessage ="Enter valid name.Max '20'")]
        [MinLength(3,ErrorMessage ="Enter valid name.Min '3'")]
       public string Name { get; set; }

       public ICollection<TimeTable> DateSheet { get; set; }
    }
}
