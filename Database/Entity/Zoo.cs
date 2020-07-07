using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Zoo_w57047.Entity
{
    public class Zoo
    {
        public long Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Adress { get; set; }
        [DisplayName("Ticket price")]
        public decimal TicketPrice { get; set; }
        public virtual List<Animal> Animals { get; set; }
        public virtual List<Aviary> Aviaries { get; set; }
    }
}
