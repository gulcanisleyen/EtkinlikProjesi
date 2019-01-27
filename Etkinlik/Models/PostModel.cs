using Etkinlik.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Etkinlik
{
    [Table("Posts")]
    public class PostModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string PostName { get; set; }

        [MaxLength(1000)]
        public string PostDesc { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime PostCreateTime { get; set; }


        [DataType(DataType.Date)]
        public DateTime PostDate { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan PostTime { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

    }
}
