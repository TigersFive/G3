using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class Payment
    {
        [Key]
        public int payment_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        [ForeignKey("InsurancePolicy")]
        public int policy_id { get; set; }

        [Required]
        [StringLength(50)]
        public string? bill_number { get; set; }

        public DateTime payment_date { get; set; }

        public decimal payment_amount { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual InsurancePolicy? InsurancePolicy { get; set; }
    }

}
