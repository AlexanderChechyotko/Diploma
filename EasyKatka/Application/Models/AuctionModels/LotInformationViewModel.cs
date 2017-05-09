using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Application.Models.AuctionModels
{
    public class LotInformationViewModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImagePath { get; set; }
        [Required]
        public double StartPrice { get; set; }

        [Required]
        public HttpPostedFileBase UploadedImage { get; set; }
    }
}