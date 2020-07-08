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
    public class NewAviary
    {
        public long Id { get; set; }
        public AviaryCondition Condition { get; set; }
        [Range(1, 50)]
        [DisplayName("Capacity")]
        public int MaxAnimals { get; set; }
        public AviaryType Type { get; set; }
        public virtual Zoo Zoo { get; set; }
        public long ZooId { get; set; }
        public List<Zoo> Zoos { get; set; }
    }
}
