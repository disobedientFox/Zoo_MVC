using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Zoo_w57047.Entity;
using Zoo_w57047.Enums;

namespace Zoo_w57047.Models
{
    public class NewAnimal
    {
        public long Id { get; set; }
        public AnimalType Type { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(30)]
        public string Country { get; set; }
        [DisplayName("Arrival Date")]
        public DateTime ArrivalDate { get; set; }
        [MaxLength(250)]
        public string Description { get; set; }
        public long AviaryId { get; set; }
        public Aviary Aviary { get; set; }

        public List<Aviary> Aviaries { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
