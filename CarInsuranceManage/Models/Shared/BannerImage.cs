using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class BannerImage
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string? image { get; set; }
        
        [Required]
        [StringLength(255)]
        public string? link { get; set; }

        public int sort_order { get; set; }

        public bool status { get; set; }
    }

}
