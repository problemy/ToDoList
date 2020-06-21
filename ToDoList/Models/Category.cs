using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static CustomValidation;

namespace ToDoList.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Wprowadz nazwę kategorii")]
        [checkCategory(AllowCategory = "Nieprzypisane,Frontend,Backend", ErrorMessage = ("Please choose a valid category (Nieprzypisane, Frontend, Backend"))]
        public string Name { get; set; }
        public virtual ICollection<ToDo> List { get; set; }
    }
}