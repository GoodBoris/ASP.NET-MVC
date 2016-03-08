using System.Collections.Generic;

namespace PhotoAlbum.WEB.Models
{
    public class PhotoListViewModel
    {
        public IEnumerable<PhotoViewModel> Photos { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentUser { get; set; }
    }
}