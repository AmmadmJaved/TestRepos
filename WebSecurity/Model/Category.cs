using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebSecurity.Model
{
   public class Category
    {
        [Key]
        public int Id { get; set; }
        public int CategoryName { get; set; }
        public int Description { get; set; }
        public virtual ICollection<Fruit> Fruits { get; set; }
        public virtual ICollection<Vegetable> Vegetables { get; set; }

        //public int MyProperty { get; set; }
    }
}
