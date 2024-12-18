
using System.ComponentModel.DataAnnotations;
using TestProject.Models;

public class LoaiHang
{
    [Key]
    public int MaLoai { get; set; }

    [Required]
    [StringLength(50)]
    public string TenLoai { get; set; }

    // Navigation property (nếu cần)
    public virtual ICollection<HangHoa>? HangHoas { get; set; }
}