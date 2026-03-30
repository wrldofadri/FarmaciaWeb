using FarmaciaWeb.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FarmaciaWeb.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var hoy = DateTime.Today;

            ViewBag.TotalMedicamentos = await _context.Medicamentos.CountAsync();
            ViewBag.TotalCategorias = await _context.Categorias.CountAsync();
            ViewBag.TotalEstantes = await _context.Estantes.CountAsync();

            ViewBag.Vencidos = await _context.Medicamentos
                .CountAsync(m => m.FechaVencimiento < hoy);

            ViewBag.PorVencer30 = await _context.Medicamentos
                .CountAsync(m => m.FechaVencimiento >= hoy && m.FechaVencimiento <= hoy.AddDays(30));

            ViewBag.PorVencer60 = await _context.Medicamentos
                .CountAsync(m => m.FechaVencimiento >= hoy && m.FechaVencimiento <= hoy.AddDays(60));

            ViewBag.PorVencer90 = await _context.Medicamentos
                .CountAsync(m => m.FechaVencimiento >= hoy && m.FechaVencimiento <= hoy.AddDays(90));

            ViewBag.BajoStock = await _context.Medicamentos
                .CountAsync(m => m.Stock < 10);

            return View();
        }
    }
}