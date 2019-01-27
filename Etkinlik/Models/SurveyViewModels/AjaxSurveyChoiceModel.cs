using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etkinlik.Models.SurveyViewModels
{
    public class AjaxSurveyChoiceModel
    {

        public int Id { get; set; }
        
        public string ChoiceName { get; set; }
        
        public int Vote { get; set; }

        public int SurveyModelId { get; set; }
    }
}
