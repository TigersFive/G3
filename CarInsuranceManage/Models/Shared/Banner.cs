using System;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class Banner
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Title must be less than 255 characters.")]
        public string? Title { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Image URL")]
        public string? image { get; set; }

        [Required]
        [StringLength(500, ErrorMessage = "Description must be less than 500 characters.")]
        public string? Description { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Link URL")]
        public string? link { get; set; }

        [Display(Name = "Sort Order")]
        [Range(0, 1000, ErrorMessage = "Sort order must be between 0 and 1000.")]
        public int sort_order { get; set; }

        [Display(Name = "Status")]
        public bool status { get; set; }

        [Display(Name = "Start Date")]
        public DateTime? StartDate { get; set; } // Thời điểm banner bắt đầu hiển thị

        [Display(Name = "End Date")]
        public DateTime? EndDate { get; set; } // Thời điểm banner kết thúc hiển thị

        [Display(Name = "Created At")]
        public DateTime CreatedAt { get; set; } = DateTime.Now; // Tự động lưu ngày tạo

        [Display(Name = "Updated At")]
        public DateTime? UpdatedAt { get; set; } // Lưu ngày cập nhật
    }
}
