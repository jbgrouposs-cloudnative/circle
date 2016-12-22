using Circle.Repositories.User;
using Circle.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using User.Interfaces;

namespace Circle.WebAPI.Controllers
{

    [ServiceRequestActionFilter]
    public class UsersController : ApiController
    {

        public async Task<ResponseData<bool>> Post(UserProperties properties)
        {
            var repo = new UserRepository();
            var user = await repo.CreateAsync(properties);

            if( user != null)
            {
                return ResponseData<bool>.BuildOK(true);
            }

            return ResponseData<bool>.Build("600", "Failure");
        }
    }
}
