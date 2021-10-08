using GlobusRemote.Data.Annotations;
using GlobusRemote.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace GlobusRemote.Areas.MobileBooks.Models
{
    public class FilesItemViewModel : BaseItemViewModel
    {
        public int Fid { get; set; }
        public string FtypeName { get; set; }
        public string Fname { get; set; }
        public string Fextention { get; set; }
        public double FsizeInKb { get; set; }
        public DateTime FdateCreated { get; set; }
        public DateTime FdateChanged { get; set; }
    }
}