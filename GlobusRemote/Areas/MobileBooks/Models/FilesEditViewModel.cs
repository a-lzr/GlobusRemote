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

        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Type")]
        [RequiredLocalized]
        public byte? FkType { get; set; }

        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Name")]
        [MaxLengthLocalized(64)]
        [RequiredLocalized]
        public string Fname { get; set; }

        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Extention")]
        [MaxLengthLocalized(16)]
        [RequiredLocalized]
        public string Fextention { get; set; }

        [Display(ResourceType = typeof(Localize.Index), Name = "Field_Base_Size")]
        [RangeLocalized(1, 10485760)]
        public int Fsize { get; set; }
        public double FsizeInKb { get; set; }
        public byte[] Fbody { get; set; }

        [NotMapped]
        public List<SelectListItem> Types { get; set; }
    }
}