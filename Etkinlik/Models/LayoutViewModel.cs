using Etkinlik.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Etkinlik.Models
{
    public class LayoutViewModel
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LayoutViewModel(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public string GetFullName(string id)
        {
            var user = _applicationDbContext.Users.FirstOrDefault(e => e.Id == id);
            if(user.FullName == null)
            {
                return "-";
            }
            return user.FullName;
        }
    }
}
