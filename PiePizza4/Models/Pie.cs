using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PiePizza3.Models
{
    public class Pie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Pie Name")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        //public string ImageUrl { get; set; }
        //public string ImageThumbnailUrl { get; set; }
        public bool IsPieOfTheWeek { get; set; }

        #region Image

        public byte[] Image { get; set; }

        public string ImageContentType { get; set; }

        public string GetInlineImageSrc()
        {
            if (Image == null || ImageContentType == null)
                return null;

            var base64Image = System.Convert.ToBase64String(Image);
            return $"data:{ImageContentType};base64,{base64Image}";
        }

        public void SetImage(Microsoft.AspNetCore.Http.IFormFile file)
        {
            if (file == null)
                return;

            ImageContentType = file.ContentType;

            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                Image = stream.ToArray();
            }
        }

        #endregion
    


}
}
