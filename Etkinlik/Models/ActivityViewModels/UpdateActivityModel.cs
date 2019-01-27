using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Etkinlik.Models.ActivityViewModels
{
    public class UpdateActivityModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string PostName { get; set; }

        [Required]
        [MaxLength(1000)]
        public string PostDesc { get; set; }

        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan PostTime { get; set; }

    }
}
