using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Etkinlik.Models;
using Etkinlik.Data;
using Microsoft.AspNetCore.Identity;
using Etkinlik.Models.SurveyViewModels;

namespace Etkinlik.Controllers
{
    public class HomeController : Controller
    {
        #region private-readonly
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        #endregion
        //constructor
        public HomeController(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            _applicationDbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var allPosts = _applicationDbContext.Posts.ToList();

            return View("EtkinlikAnaSayfa", allPosts);
        }

        public IActionResult AddActivity()
        {
            return Redirect("/Post/add");
        }

        public IActionResult AddSurvey()
        {
            return Redirect("/Survey/add");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet("/test")]
        public IActionResult test()
        {
            var surveyList = _applicationDbContext.Surveys.Where(s => true).ToList();
            foreach (var survey in surveyList)
            {
                survey.SurveyChoiceModel = _applicationDbContext.SurveyChoices.Where(sc => sc.SurveyModelId == survey.Id).ToList();

            }

            return View("PostDetail", surveyList);
        }

        [HttpGet("getLastSurvey")]
        public SurveyModel getLastSurvey()
        {
            var item = _applicationDbContext.Surveys.Last(e => true);
            item.SurveyChoiceModel = _applicationDbContext.SurveyChoices.Where(sc => sc.SurveyModelId == item.Id).ToList();
            return item;
        }

        public bool HasIn(PostModel post, string userId)
        {
            try
            {
                var user = _applicationDbContext.Users.First(u => u.Id.Equals(userId));

                UserPostModel userPost = _applicationDbContext.UserPosts.First(d =>
                         d.ApplicationUserId == user.Id && d.PostModelId == post.Id);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public List<string> getUsers(PostModel post)
        {
            List<UserPostModel> users = _applicationDbContext.UserPosts.Where(up => up.PostModelId == post.Id).ToList();
            List<string> userName = new List<string>();
            foreach (var model in users)
            {
                userName.Add(_applicationDbContext.Users.First(u => u.Id == model.ApplicationUserId).FullName);
            }
            return userName;
        }

        [HttpGet("surveyVote/{id}")]
        public IActionResult SurveyVote(int id)
        {
            var list = _applicationDbContext.SurveyChoices.Where(c => c.SurveyModelId == id).ToList();
            var newList = new List<AjaxSurveyChoiceModel>();
            foreach(var item in list)
            {
                newList.Add(new AjaxSurveyChoiceModel{
                    Id = item.Id,
                    SurveyModelId = item.SurveyModelId,
                    ChoiceName = item.ChoiceName,
                    Vote = item.Vote
                });
            }
            return Json(newList);
        }

        [HttpGet("getLastSurveyVote")]
        public IActionResult GetLastSurveyVote()
        {
            var lastSurveyId = _applicationDbContext.Surveys.Last(e=> true).Id;
            return SurveyVote(lastSurveyId);
        }
    }
}

/*
@{
    ViewData["Title"] = "Contact";
}
<h2>@ViewData["Title"]</h2>
<h3>@ViewData["Message"]</h3>


ViewData["Message"] = "Your application description page."; 
return View();
*/
