using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestProject.Attributes;

namespace TestProject.Models
{
    public class HangHoa
    {
        [Key] //khoá tạo khoá chính nếu không tên là id
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // tự động thêm id
        public int MaHang { get; set; }

        [Required] // bắt buộc phải có
        public int MaLoai { get; set; }

        [Required]
        [StringLength(50)] // giói hạn 50 chữ
        public string TenHang { get; set; }

        [Column(TypeName = "decimal(18,0)")]
        public decimal? Gia { get; set; }

        [FileExtensionValidation([".jpg", ".png", ".gif", ".tiff"])]
        [StringLength(100)]
        public string? Anh { get; set; }

        // Navigation property
        [ForeignKey(nameof(MaLoai))]
        public virtual LoaiHang? LoaiHang { get; set; }
    }
}