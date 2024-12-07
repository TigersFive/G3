using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class InsurancePolicy
    {
        [Key]
        public int policy_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        [ForeignKey("Vehicle")]
        public int vehicle_id { get; set; }

        [Required]
        [StringLength(50)]
        public string? policy_number { get; set; }

        public DateTime policy_start_date { get; set; }

        public DateTime policy_end_date { get; set; }

        [Required]
        [StringLength(50)]
        public string? policy_type { get; set; }

        public decimal policy_amount { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
    }

}
