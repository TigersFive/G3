using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class Comment
    {
        [Key]
        public int comment_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }
        [Required]
        public string? comment_text { get; set; }
        [Required]
        public int? rating { get; set; }

        public DateTime created_at { get; set; } = DateTime.Now;
        [Required]
        public string? status { get; set; }  // 'Active' or 'Archived'

        public virtual Customer? Customer { get; set; }
    }

}
