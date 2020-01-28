using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopCaddy.Data;
using ShopCaddy.Models;

namespace ShopCaddy.Controllers
{
    public class PurchaseOrderProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PurchaseOrderProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PurchaseOrderProducts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaseOrderProducts.Include(p => p.Product).Include(p => p.PurchaseOrder);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseOrderProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderProduct = await _context.PurchaseOrderProducts
                .Include(p => p.Product)
                .Include(p => p.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseOrderProduct == null)
            {
                return NotFound();
            }

            return View(purchaseOrderProduct);
        }

        // GET: PurchaseOrderProducts/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "Id", "Id");
            return View();
        }

        // POST: PurchaseOrderProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,PurchaseOrderId,QuantityOrdered")] PurchaseOrderProduct purchaseOrderProduct)
        {
            if (ModelState.IsValid)
            {
                _context.Add(purchaseOrderProduct);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", purchaseOrderProduct.ProductId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "Id", "Id", purchaseOrderProduct.PurchaseOrderId);
            return View(purchaseOrderProduct);
        }

        // GET: PurchaseOrderProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderProduct = await _context.PurchaseOrderProducts.FindAsync(id);
            if (purchaseOrderProduct == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", purchaseOrderProduct.ProductId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "Id", "Id", purchaseOrderProduct.PurchaseOrderId);
            return View(purchaseOrderProduct);
        }

        // POST: PurchaseOrderProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,PurchaseOrderId,QuantityOrdered")] PurchaseOrderProduct purchaseOrderProduct)
        {
            if (id != purchaseOrderProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaseOrderProduct);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderProductExists(purchaseOrderProduct.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", purchaseOrderProduct.ProductId);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders, "Id", "Id", purchaseOrderProduct.PurchaseOrderId);
            return View(purchaseOrderProduct);
        }

        // GET: PurchaseOrderProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrderProduct = await _context.PurchaseOrderProducts
                .Include(p => p.Product)
                .Include(p => p.PurchaseOrder)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseOrderProduct == null)
            {
                return NotFound();
            }

            return View(purchaseOrderProduct);
        }

        // POST: PurchaseOrderProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrderProduct = await _context.PurchaseOrderProducts.FindAsync(id);
            _context.PurchaseOrderProducts.Remove(purchaseOrderProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderProductExists(int id)
        {
            return _context.PurchaseOrderProducts.Any(e => e.Id == id);
        }
    }
}
