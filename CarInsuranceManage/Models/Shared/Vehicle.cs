using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class Vehicle
    {
        [Key]
        public int vehicle_id { get; set; }

        [ForeignKey("Customer")]
        public int customer_id { get; set; }

        [Required]
        [StringLength(100)]
        public string? vehicle_name { get; set; }

        [Required]
        [StringLength(100)]
        public string? vehicle_model { get; set; }
        [Required]
        [StringLength(100)]
        public string? vehicle_version { get; set; }
        [Required]
        [StringLength(50)]
        public string? body_number { get; set; }
        [Required]
        [StringLength(50)]
        public string? engine_number { get; set; }

        public decimal vehicle_rate { get; set; }

        public virtual Customer? Customer { get; set; }
    }

}
