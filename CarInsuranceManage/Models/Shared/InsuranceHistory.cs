using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class InsuranceHistory
    {
        [Key]
        public int history_id { get; set; }

        [ForeignKey("InsurancePolicy")]
        public int policy_id { get; set; }

        public DateTime change_date { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string? change_type { get; set; }
        [Required]
        public string? old_value { get; set; }
        [Required]
        public string? new_value { get; set; }

        [ForeignKey("User")]
        public int changed_by { get; set; }

        public virtual InsurancePolicy? InsurancePolicy { get; set; }
        public virtual User? User { get; set; }
    }

}
