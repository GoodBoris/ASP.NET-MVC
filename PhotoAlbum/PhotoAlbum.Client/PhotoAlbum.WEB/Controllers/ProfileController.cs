using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using PhotoAlbum.WEB.MembershipService;
using PhotoAlbum.WEB.Models;

namespace PhotoAlbum.WEB.Controllers
{
    //Controller to manage account
    [Authorize]
    public class ProfileController : BaseController
    {
        private readonly IMembershipService _membershipService;

        public ProfileController(IMembershipService membershipService)
        {
            _membershipService = membershipService;
        }

        [HttpGet]
        public async Task<ActionResult> Index(string currentUser)
        {
            var response = await _membershipService.GetProfileAsync(currentUser);
            var indexViewModel = Mapper.Map<UserProfileResponse, IndexViewModel>(response);
            return View(indexViewModel);
        }

        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangePassword(ChangePasswordViewModel model, string currentUser)
        {
            if (ModelState.IsValid)
            {
                var request = Mapper.Map<ChangePasswordViewModel, ChangeUserPasswordRequest>(model);
                var result = await _membershipService.ChangeUserPasswordAsync(request);
                if (result.Success)
                {
                    Success("The password has been changed", true);
                    return RedirectToAction("Index");
                }
                AddErrors(result.Errors);
            }
            return View();
        }

        public ActionResult ChangeUserInfo()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ChangeUserInfo(ChangeUserInfoViewModel model, string currentUser)
        {
            if (ModelState.IsValid)
            {
                var request = Mapper.Map<ChangeUserInfoViewModel, ChangeUserInfoRequest>(model);
                var result = await _membershipService.ChangeUserInfoAsync(request);
                if (result.Success)
                {
                    Success("The profile has been modified", true);
                    return RedirectToAction("Index");
                }
                AddErrors(result.Errors);
            }
            return View();
        }
    }
}