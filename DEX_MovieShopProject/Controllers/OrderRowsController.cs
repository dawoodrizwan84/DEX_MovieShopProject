using DEX_MovieShopProject.Data;
using DEX_MovieShopProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEX_MovieShopProject.Controllers
{
    public class OrderRowsController : Controller
    {
        private readonly AppDbContext _context;
        public OrderRowsController(AppDbContext context)
        {
            _context = context;
        }
        
        // GET: OrderRows
        public async Task<IActionResult> Index()
        {
            List<OrderRow> orderRows = await _context.OrderRows.ToListAsync();
            return View(orderRows);
        }

        // GET: OrderRows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderRow orderRow = await _context.OrderRows.FirstOrDefaultAsync(o => o.Id == id);

            if (orderRow == null)
            {
                return NotFound();
            }

            return View(orderRow);
        }

        // GET: OrderRows/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderRows/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderRow orderRow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderRow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderRow);
        }

        // GET: OrderRows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderRow orderRow = await _context.OrderRows.FirstOrDefaultAsync(o => o.Id == id);

            if (orderRow == null)
            {
                return NotFound();
            }

            return View(orderRow);
        }

        // POST: OrderRows/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderRow orderRow)
        {
            if (id != orderRow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderRow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderRowExists(orderRow.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(orderRow);
        }

        // GET: OrderRows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            OrderRow orderRow = await _context.OrderRows.FirstOrDefaultAsync(o => o.Id == id);

            if (orderRow == null)
            {
                return NotFound();
            }

            return View(orderRow);
        }

        // POST: OrderRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            OrderRow orderRow = await _context.OrderRows.FirstOrDefaultAsync(o => o.Id == id);
            _context.OrderRows.Remove(orderRow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderRowExists(int id)
        {
            return _context.OrderRows.Any(o => o.Id == id);
        }
    }
}