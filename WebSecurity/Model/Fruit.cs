using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebSecurity.Model
{
  public  class Fruit
    {
        [Key]
        public int Id { get; set; }
        public string FruitName { get; set; }
        public string Description { get; set; }
        public bool Price { get; set; }
    }
}
