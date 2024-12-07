using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class Estimate
    {
        [Key]
        public int estimate_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        [ForeignKey("Vehicle")]
        public int vehicle_id { get; set; }

        [Required]
        [StringLength(50)]
        public string? policy_type { get; set; }
        [Required]
        [StringLength(50)]
        public string? warranty { get; set; }

        public decimal estimate_amount { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;

        public virtual Customer? Customer { get; set; }
        public virtual Vehicle? Vehicle { get; set; }
    }

}
