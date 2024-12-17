using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarInsuranceManage.Models
{
    public class Services
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("InsurancePolicy")]
        public int policy_id { get; set; }

        [Required]
        [StringLength(255)]
        public string? title { get; set; }

        [Required]
        [StringLength(255)]
        public string? image { get; set; }

        [Required]
        [StringLength(500)]
        public string? description { get; set; }

        [Required]
        [Range(0, 1000)]
        [StringLength(255)]
        public int sort_order { get; set; }

        public bool status { get; set; }

        public DateTime? startdate { get; set; } // Thời điểm dịch vụ bắt đầu hiển thị

        public DateTime? enddate { get; set; } // Thời điểm dịch vụ kết thúc hiển thị

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Tự động lưu ngày tạo

        public DateTime? UpdatedAt { get; set; } // Lưu ngày cập nhật

        public virtual InsurancePolicy? InsurancePolicy { get; set; }
    }
}
