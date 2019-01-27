using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etkinlik.Models
{
    public class SurveyChoiceModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ChoiceName { get; set; }

        [Required]
        public int Vote { get; set; }

        public int SurveyModelId { get; set; }
        public SurveyModel SurveyModel { get; set; }
    }
}
