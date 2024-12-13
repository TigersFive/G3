using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class CompanyExpense
    {
        [Key]
        public int expense_id { get; set; }

        [Required]
        [StringLength(50)]
        public string? expense_type { get; set; }

        public DateTime expense_date { get; set; }

        public decimal expense_amount { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;
    }

}
