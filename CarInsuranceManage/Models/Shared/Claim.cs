using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class Claim
    {
        [Key]
        public int claim_id { get; set; }

        [ForeignKey("InsurancePolicy")]
        public int policy_id { get; set; }

        [Required]
        [StringLength(50)]
        public string? claim_number { get; set; }

        public DateTime accident_date { get; set; }

        [StringLength(255)]
        public string? place_of_accident { get; set; }

        public decimal insured_amount { get; set; }

        public decimal claimable_amount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual InsurancePolicy ?InsurancePolicy { get; set; }
    }

}
