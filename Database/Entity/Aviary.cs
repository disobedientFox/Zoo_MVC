using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Zoo_w57047.Enums;

namespace Zoo_w57047.Entity
{
    public class Aviary
    {
        public long Id { get; set; }
        public AviaryCondition Condition { get; set; }
        [Range(1, 50)]
        [DisplayName("Capacity")]
        public int MaxAnimals { get; set; }
        public AviaryType Type { get; set; }
        public virtual List<Animal> Animals { get; set; }
        public virtual Zoo Zoo { get; set; }
    }
}
