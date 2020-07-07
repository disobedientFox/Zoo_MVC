using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Zoo_w57047.Entity;

namespace Zoo_w57047.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Zoo> Zoos { get; set; }
        public IEnumerable<Animal> Animals { get; set; }
        public IEnumerable<Aviary> Aviaries { get; set; }

        public PageViewModel PageViewModel { get; set; }
    }
}
