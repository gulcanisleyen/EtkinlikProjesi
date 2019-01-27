using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etkinlik.Models
{
    public class UserSurveyModel
    {
        public int Id { get; set; }

        public int SurveyChoiceModelId {get; set;}
        public SurveyChoiceModel SurveyChoiceModel { get; set; }

        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}
