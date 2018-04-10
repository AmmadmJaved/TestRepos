using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Model
{
  public  class Fruit
    {
        [Key]
        public int Id { get; set; }
        public string FruitName { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
