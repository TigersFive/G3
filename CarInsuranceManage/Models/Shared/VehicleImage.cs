using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CarInsuranceManage.Models
{
    public class VehicleImage
    {
        [Key]
        public int image_id { get; set; }

        [ForeignKey("Vehicle")]
        public int vehicle_id { get; set; }

        [Required]
        public string? image_type { get; set; }  // 'Vehicle', 'Insurance Document', 'Claim Document'

        [Required]
        [StringLength(255)]
        public string? image_path { get; set; }
        [Required]
        public string? description { get; set; }

        public DateTime uploaded_at { get; set; } = DateTime.Now;

        public virtual Vehicle? Vehicle { get; set; }
    }

}
