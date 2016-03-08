using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Owin.Security;
using PhotoAlbum.WEB.MembershipService;
using PhotoAlbum.WEB.Models;
using ClaimsIdentity = System.Security.Claims.ClaimsIdentity;

namespace PhotoAlbum.WEB.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var response = await _membershipService.LoginAsync(new LoginRequest()
                {
                    UserName = model.UserName,
                    Password = model.Password
                });

                if (response.Success)
                {
                    var claims = response.ClaimIdentityView.ClaimViewList.Select(Mapper.Map<ClaimView, Claim>).ToList();
                    var identity = new ClaimsIdentity(claims, response.ClaimIdentityView.AuthenticationType.ToString());
                    SignInAsync(identity, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                AddErrors(response.Errors);
            }

            return View(model);
        }
        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _membershipService.CreateAsync(Mapper.Map<RegisterViewModel, CreateRequest>(model));
                if (response.Success)
                {
                    var claims = response.ClaimIdentityView.ClaimViewList.Select(Mapper.Map<ClaimView, Claim>).ToList();
                    var identity = new ClaimsIdentity(claims, response.ClaimIdentityView.AuthenticationType.ToString());
                    SignInAsync(identity, isPersistent: false);
                    Success("Profile has been created successfully", true);
                    return RedirectToAction("List", "Photo");
                }
                AddErrors(response.Errors);
            }
            return View(model);
        }


        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("List", "Photo");
        }

        private void SignInAsync(ClaimsIdentity identity, bool isPersistent)
        {
            AuthenticationManager.SignOut();
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        #region Helpers
        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("List", "Photo");
        }

        #endregion
    }

}