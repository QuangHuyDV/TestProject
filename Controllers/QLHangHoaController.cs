using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestProject.Models;


namespace TestProject.Controllers

{
    public class QLHangHoaController : Controller
    {
        private readonly DataContext db;

        private readonly ILogger<QLHangHoaController> _logger;

        public QLHangHoaController(DataContext context, ILogger<QLHangHoaController> logger)
        {
            db = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var hanghoas = db.HangHoas
                    .AsNoTracking()
                    .Include(m => m.LoaiHang)
                    .Where(l => l.LoaiHang != null && l.Gia > 100)
                    .ToList();

                var loaihangs = db.LoaiHangs.ToList();
                ViewBag.LoaiHangs = loaihangs;

                if (!hanghoas.Any())
                {
                    ViewBag.Message = "Không có hàng hóa nào.";
                    return View(new List<HangHoa>());
                }
                return View(hanghoas);
            }
            catch (Exception ex)
            {
                // Ghi log lỗi
                Console.WriteLine(ex);
                ViewBag.Error = ex.Message ?? "Lỗi không xác định";
                return View("Error");
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            var loaihangs = db.LoaiHangs.ToList();
            var selectItems = loaihangs.Select(h => new SelectListItem
            {
                Value = h.MaLoai.ToString(),
                Text = h.TenLoai.ToString()
            });
            ViewBag.LoaiHang = selectItems;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MaLoai,TenHang,Gia,Anh")] HangHoa hanghoa)
        {
            if (ModelState.IsValid)
            {
                db.HangHoas.Add(hanghoa);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            var loaihangs = db.LoaiHangs.ToList();
            var selectItems = loaihangs.Select(h => new SelectListItem
            {
                Value = h.MaLoai.ToString(),
                Text = h.TenLoai.ToString()
            });
            ViewBag.LoaiHang = selectItems;
            return View();
        }

        public IActionResult LoaiHang(int? mid)
        {
            if (mid == null)
            {
                var hanghoas = db.HangHoas
                    .AsNoTracking()
                    .Include(m => m.LoaiHang)
                    .ToList();
                var loaihangs = db.LoaiHangs.ToList();
                ViewBag.LoaiHangs = loaihangs;
                return PartialView("DanhSachSanPham", hanghoas);
            }
            else
            {
                var hanghoas = db.HangHoas
                    .AsNoTracking()
                    .Where(m => m.MaLoai == mid)
                    .Include(m => m.LoaiHang)
                    .ToList();
                var loaihangs = db.LoaiHangs.ToList();
                ViewBag.LoaiHangs = loaihangs;
                return View(hanghoas);
            }
        }
    }

}