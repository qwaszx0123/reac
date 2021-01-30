using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Value
    {
        //to be used as the primary key.
         [Key]
        public int Id {get; set;}

        public string Name {get; set;}

    }
}
