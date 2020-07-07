using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Zoo_w57047.Enums;

namespace Zoo_w57047.Entity
{
    public class Animal
    {
        public long Id { get; set; }
        public AnimalType Type { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DisplayName("Arrival Date")]
        public DateTime ArrivalDate { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public virtual long AviaryId { get; set; }
        public virtual Aviary Aviary { get; set; }
    }
}
