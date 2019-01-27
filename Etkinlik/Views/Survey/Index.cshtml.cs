using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etkinlik.Data;
using Etkinlik.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Etkinlik.Views.Survey
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public IndexModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet("/testi")]
        public IEnumerable<SurveyChoiceModel> OnGet()
        {
            return _applicationDbContext.SurveyChoices.Where(l => true).ToList();
        }
    }
}