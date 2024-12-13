using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class Report
    {
        [Key]
        public int report_id { get; set; }

        [Required]
        [StringLength(50)]
        public string? report_type { get; set; }

        public DateTime generated_at { get; set; } = DateTime.Now;

        public string? description { get; set; }
    }

}
