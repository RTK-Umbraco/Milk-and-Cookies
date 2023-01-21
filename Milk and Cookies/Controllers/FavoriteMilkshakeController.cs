using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Milk_and_Cookies.Controllers
{
    public class FavoriteMilkshakeController : Controller
    {

        private const string CookieName = "favoriteMilkshake";
        public IActionResult Index(string favoriteMilkshake)    
        {
            Response.Cookies.Append("favoriteMilkshake", favoriteMilkshake);

            return View();
        }

        [HttpGet("api/favoriteMilkshake")]
        public void SetCookie(string favoriteMilkshake)
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTime.Now.AddMinutes(5);

            Response.Cookies.Append(CookieName, favoriteMilkshake, cookieOptions);
        }

        [Route("api/GetCookie")]
        public string GetCookie()
        {
            var cookie = Request.Cookies[CookieName];
            if (cookie is null)
            {
                return "Unknown";
            }
            return cookie;
        }


        [HttpGet("api/favoriteMilkshake/getCookieV2")]
        public string GetCookieV2()
        {
            var cookie = Request.Cookies[CookieName];
            if (cookie is null)
            {
                return "Unknown";
            }
            return cookie;
        }

        [HttpGet("api/favoriteMilkshake/removeCookie")]
        public void RemoveCookie()
        {
            if (Request.Cookies[CookieName] != null)
            {
                Response.Cookies.Delete(CookieName);
            }
        }
    }
}
        