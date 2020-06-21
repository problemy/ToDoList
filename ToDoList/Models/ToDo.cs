using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    public class ToDo
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "Wprowadz opis zadania")]
        [StringLength(100)]
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public int CategoryId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Category Category { get; set; }
        


    }
}