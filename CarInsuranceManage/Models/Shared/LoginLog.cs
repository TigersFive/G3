using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class LoginLog
    {
        [Key]
        public int log_id { get; set; }

        [ForeignKey("User")]
        public int user_id { get; set; }

        public DateTime login_time { get; set; } = DateTime.Now;
        [Required]
        [StringLength(50)]
        public string? ip_address { get; set; }

        public virtual User? User { get; set; }
    }

}
