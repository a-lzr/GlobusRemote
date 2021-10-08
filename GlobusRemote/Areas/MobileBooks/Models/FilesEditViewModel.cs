using GlobusRemote.Data.Annotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GlobusRemote.Areas.MobileBooks.Models
{
    public class FilesEditViewModel
    {
        public int Fid { get; set; }
        public IFormFile File { get; set; }

        [RequiredLocalized]
        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Type")]
        public byte? FkType { get; set; }

        [RequiredLocalized]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Name")]
        public string Fname { get; set; }

        [RequiredLocalized]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Extention")]
        public string Fextention { get; set; }

        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Size")]
        public int Fsize { get; set; }
        public double FsizeInKb { get; set; }
        public byte[] Fbody { get; set; }

        [NotMapped]
        public List<SelectListItem> Types { get; set; }
    }
}