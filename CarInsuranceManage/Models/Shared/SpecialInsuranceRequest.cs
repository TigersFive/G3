using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class SpecialInsuranceRequest
    {
        [Key]
        public int request_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        [ForeignKey("Vehicle")]
        public int vehicle_id { get; set; }

        [Required]
        [StringLength(100)]
        public string? request_type { get; set; }
        [Required]
        public string? request_description { get; set; }

        public DateTime request_date { get; set; } = DateTime.Now;

        [Required]
        public string? status { get; set; }  // 'Pending', 'Approved', 'Denied'

        public virtual Customer? Customer { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
    }

}
