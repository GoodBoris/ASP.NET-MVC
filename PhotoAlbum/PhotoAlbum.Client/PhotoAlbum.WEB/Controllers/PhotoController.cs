using System;
using System.Collections.Generic;
using System.Configuration;
using System.ServiceModel;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using PhotoAlbum.WEB.FileTransferService;
using PhotoAlbum.WEB.Models;
using PhotoAlbum.WEB.PhotoService;

namespace PhotoAlbum.WEB.Controllers
{
    //Almost exceptions catching in Base controller globally.
    [Authorize]
    public class PhotoController : BaseController
    {
        private int _pageSize = 5;
        public PhotoController(IPhotoAlbumService photoAlbumService, IFileTransferService fileTransferService)
        {
            _photoAlbumService = photoAlbumService;
            _fileTransferService = fileTransferService;
        }
        [AllowAnonymous]
        public ActionResult List(string userPhotos = null, int page = 1)
            => View(BuildViewModel(userPhotos, page));

        public ActionResult Manage(string currentUser, int page = 1)
            => View(BuildViewModel(currentUser, page));

        [HttpGet]
        public ActionResult Create()
        {
            var model = new PhotoViewModel
            {
                UserId = User.Identity.GetUserId(),
                UserName = User.Identity.GetUserName()
            };
            return PartialView("_Create", model);

        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateConfirmed(PhotoViewModel photo, HttpPostedFileBase image = null)
        {
            if (!ModelState.IsValid)
                return PartialView("_Create", photo);

            var photoDto = Mapper.Map<PhotoViewModel, PhotoDescriptionDto>(photo);
            var photoId = _photoAlbumService.CreatePhoto(photoDto);
            photo.PhotoId = photoId;
            AddImage(photo, image);
            Success($"The photo '{photo.Name}' was added successfully.", true);
            return Json(new { success = true });
        }


        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var model = _photoAlbumService.FindPhotoById(id);
            var photo = Mapper.Map<PhotoDescriptionDto, PhotoViewModel>(model);
            return PartialView("_Edit", photo);
        }


        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditConfirmed(PhotoViewModel photo, HttpPostedFileBase image = null)
        {

            if (!ModelState.IsValid)
                return PartialView("_Edit", photo);
            AddImage(photo, image);
            var photoDto = Mapper.Map<PhotoViewModel, PhotoDescriptionDto>(photo);
            _photoAlbumService.UpdatePhoto(photoDto);
            Success($"The photo '{photo.Name}' was updated successfully.", true);
            return Json(new { success = true });

        }

        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            var photo = _photoAlbumService.FindPhotoById(id);
            return PartialView("_Delete", Mapper.Map<PhotoDescriptionDto, PhotoViewModel>(photo));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _photoAlbumService.DeletePhoto(id);
            //Clear vote cookies
            if (Request.Cookies[id.ToString()] != null)
            {
                var c = new HttpCookie(id.ToString()) { Expires = DateTime.Now.AddDays(-1d) };
                Response.Cookies.Add(c);
            }
            Success("The photo was deleted successfully.", true);
            return Json(new { success = true });
        }

        //Send vote by user and get new average rating
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendRating(string id, string value)
        {
            var newRating = _photoAlbumService.AddVote(new Guid(id),
                float.Parse(value, System.Globalization.CultureInfo.InvariantCulture));
            return Json(new { success = true, averageRating = newRating });
        }

        [AllowAnonymous]
        public FileResult GetImage(Guid photoId)
        {
            try
            {
                var image = _fileTransferService.DownloadFile(new ImageDownloadRequest(photoId));
                return File(image.ImageByteStream, image.DownloadedImageMetadata.ImageMimeType);
            }
            catch (FaultException)
            {
                return File(Server.MapPath(ConfigurationManager.AppSettings["defaultImagePath"]),
                    ConfigurationManager.AppSettings["defaultImageType"]);
            }
        }

        //It is better to get photos by user id. But I did so because of 2.3 point of tehnical specifications.
        //By this point we can overrite default action of some controller. By the way everything is working now.
        //Application doesn't contain any default actions.
        private PhotoListViewModel BuildViewModel(string userName, int currentPage)
        {
            var sortBy = OrderBy.TimeOfCreation;

            var sortByCookie = Request.Cookies["sortby"];
            if (sortByCookie != null && !sortByCookie.Value.IsNullOrWhiteSpace())
                sortBy = (OrderBy)Enum.Parse(typeof(OrderBy), sortByCookie.Value, true);

            var pageSizeCookie = Request.Cookies["pagesize"];
            if (pageSizeCookie != null && !pageSizeCookie.Value.IsNullOrWhiteSpace())
                _pageSize = int.Parse(pageSizeCookie.Value);

            var photosResponse = _photoAlbumService.GetPhotosByOrder(currentPage, _pageSize, userName, sortBy);
            return new PhotoListViewModel
            {
                Photos = Mapper.Map<IEnumerable<PhotoDescriptionDto>, IEnumerable<PhotoViewModel>>(photosResponse),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = currentPage,
                    ItemsPerPage = _pageSize,
                    TotalItems = _photoAlbumService.CountPhotosByUserName(userName)
                },
                CurrentUser = User.Identity.Name
            };
        }

        //Upload picture to the server
        private void AddImage(PhotoViewModel photo, HttpPostedFileBase image)
        {
            if (image == null) return;
            try
            {
                photo.ImageMimeType = image.ContentType;
                photo.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(photo.ImageData, 0, image.ContentLength);
                image.InputStream.Position = 0;
                var response = new ImageUploadRequest(new ImageMetaData(), image.InputStream)
                {
                    Metadata =
                    {
                        ImageMimeType = image.ContentType,
                        ImageId = photo.PhotoId
                    }
                };
                _fileTransferService.UploadFile(response);
            }
            catch (FaultException)
            {
                Danger("Error during uploading/saving picture to the server.");
            }

        }

        private readonly IPhotoAlbumService _photoAlbumService;
        private readonly IFileTransferService _fileTransferService;
    }
}