using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Etkinlik.Data;
using Etkinlik.Models;
using Etkinlik.Models.ActivityViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Etkinlik.Controllers
{
    [Route("Post")]
    [Authorize]
    public class PostController : Controller
    {
        #region private-readonly
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        #endregion
        //constructor
        public PostController(ApplicationDbContext context,
                              UserManager<ApplicationUser> userManager,
                              SignInManager<ApplicationUser> signInManager)
        {
            _applicationDbContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        /// Post Controller (add update and delete activity)
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            var postList = _applicationDbContext.Posts.Where(p=> p.ApplicationUserId == _userManager.GetUserId(HttpContext.User)).ToList();
            return View("Index", postList);
        }

        [HttpGet("add")]
        public IActionResult AddActivity()
        {
            return View("AddActivity", new UpdateActivityModel());
        }

        [HttpGet("update/{id}")]
        public IActionResult UpdateActivity(int id)
        {
            /*if (!_signInManager.IsSignedIn(HttpContext.User))
            {
                return Redirect("/Account/Login");
            }*/

            PostModel pModel;
            try
            {
                pModel = _applicationDbContext.Posts.First(p => p.Id == id);
            }
            catch (Exception)
            {
                return Redirect("/");
            }

            if (!pModel.ApplicationUserId.Equals(_userManager.GetUserId(HttpContext.User)))
                return Redirect("/");

            UpdateActivityModel updateActivityModel = new UpdateActivityModel
            {
                Id = pModel.Id,
                PostName = pModel.PostName,
                PostDesc = pModel.PostDesc,
                PostDate = pModel.PostDate,
                PostTime = pModel.PostTime
            };

            return View("UpdateActivity", updateActivityModel);
        }

        [HttpPost("add")]
        public IActionResult AddActivity(UpdateActivityModel post)
        {
            if (post == null)
            {
                //Mesaj gönder
                return View();
            }
            
            var user = _applicationDbContext.Users.FirstOrDefault(e => e.Id == _userManager.GetUserId(HttpContext.User));

            if (post.PostName == null || post.PostDesc == null || post.PostDate == new DateTime())
            {
                return Redirect("/Post");
            }

            var newPost = new PostModel
            {
                PostName = post.PostName,
                PostDesc = post.PostDesc,
                PostDate = post.PostDate,
                PostTime = post.PostTime,
                PostCreateTime = DateTime.Now,
                ApplicationUser = user,
                ApplicationUserId = user.Id
            };

            _applicationDbContext.Posts.AddAsync(newPost);
            _applicationDbContext.SaveChanges();
            //AddUser
            AddUser(newPost.Id);
            return Redirect("/Post");
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateActivity(int id, UpdateActivityModel post)
        {
            if (post != null && post.PostName != null && post.PostDate != null && post.PostTime != null)
            {

            }
            else
            {

                return Redirect("/Post");
            }

            PostModel updPost = _applicationDbContext.Posts.First(p => p.Id == id);
            if (updPost == null)
                return Redirect("/Post");

            if (!_userManager.GetUserId(User).Equals(updPost.ApplicationUserId))
                return Redirect("/Post");

            if (!post.PostName.Equals("") && !post.PostName.Equals(updPost.PostName))
                updPost.PostName = post.PostName;
            if (!post.PostDesc.Equals(updPost.PostName))
                updPost.PostDesc = post.PostDesc;
            if (post.PostDate != null && post.PostDate != new DateTime() && !post.PostDate.Equals(updPost.PostDate))
                updPost.PostDate = post.PostDate;
            if (!(post.PostTime == null) && !post.PostTime.Equals(updPost.PostTime))
                updPost.PostTime = post.PostTime;

            _applicationDbContext.Posts.Update(updPost);
            _applicationDbContext.SaveChanges();
            return Redirect("/Post");
        }

        [HttpGet("delete/{id}")]
        public IActionResult DeleteActivity(int id)
        {
            ApplicationUser user = _applicationDbContext.Users.First(u => u.Id == _userManager.GetUserId(HttpContext.User));
            PostModel delPost;
            try
            {
                delPost = _applicationDbContext.Posts.First(p => p.Id == id);
            }
            catch (Exception)
            {
                return Redirect("/");
            }

            try
            {
                if (delPost.ApplicationUserId != user.Id)
                    return Redirect("/");
            }
            catch (Exception)
            {
                return Redirect("/");
            }
            _applicationDbContext.Remove(delPost);
            _applicationDbContext.SaveChanges();
            return Redirect("/Post/add");
        }

        /// PostUser methods (join or quit activity)
        /// </summary>
        /// <param name="User"></param>
        [HttpPost("join/{id}")]
        public void AddUser(int id)
        {
            var user = _applicationDbContext.Users.First(u => u.Id == _userManager.GetUserId(HttpContext.User));
            PostModel post;
            try
            {
                post = _applicationDbContext.Posts.First(p => p.Id == id);
               
            }
            catch (Exception)
            {
                Redirect("/Post");
                return;
            }

            try
            {
                UserPostModel userPost = _applicationDbContext.UserPosts.First(d =>
                         d.ApplicationUserId == user.Id && d.PostModelId == id);
            }
            catch (Exception)
            {

                _applicationDbContext.UserPosts.Add(new UserPostModel
                {
                    ApplicationUserId = user.Id,
                    PostModelId = id
                });
                _applicationDbContext.SaveChanges();
                Redirect("/Post");
                return;
            }

            return;
        }

        [HttpPost("quit/{id}")]
        public void DeleteUser(int id)
        {
            var user = _applicationDbContext.Users.First(u => u.Id == _userManager.GetUserId(HttpContext.User));
            PostModel post;
            try {
                post = _applicationDbContext.Posts.First(p => p.Id == id);
            }
            catch(Exception)
            {
                Redirect("/Post");
                return;
            }

            UserPostModel userPost;
            try
            {
                userPost = _applicationDbContext.UserPosts.First(d =>
                             d.ApplicationUserId == user.Id && d.PostModelId == id);
            }
            catch (Exception)
            {
                Redirect("/Post");
                return;
            }

            _applicationDbContext.UserPosts.Remove(userPost);
            _applicationDbContext.SaveChanges();
            return;
        }

    }
}
