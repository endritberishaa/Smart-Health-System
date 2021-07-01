using System;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class WaterIntake
    {
        [Key]
        public Guid waterId { get; set; }

        public int literPerHour { get; set; }

        public Patient patient { get; set; }

         public DateTime date { get; set;}
    }
}