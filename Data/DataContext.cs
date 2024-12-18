using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    { 
        // tạo kết nối, thao tác đọc ghi với các bảng
        public virtual DbSet<LoaiHang> LoaiHangs { get; set; }
        public virtual DbSet<HangHoa> HangHoas { get; set; }
        public virtual DbSet<tblAccount> TblAccounts { get; set; }

        // Tạo các bảng theo model đã tạo
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblAccount>().ToTable(nameof(tblAccount));
            modelBuilder.Entity<LoaiHang>().ToTable(nameof(LoaiHang));
            modelBuilder.Entity<HangHoa>().ToTable(nameof(HangHoa));
        }
    }

    
}