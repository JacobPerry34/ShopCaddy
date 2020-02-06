using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopCaddy.Data;
using ShopCaddy.Models;

namespace ShopCaddy.Controllers
{
    public class PurchaseOrderProductsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PurchaseOrderProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: PurchaseOrderProducts
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.PurchaseOrderProducts
                                       .Where(p => p.ApplicationUser.Id == user.Id);
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
        public async Task<IActionResult> CreateAsync(int id)
        {
            PurchaseOrderProduct purchaseOrderProduct = await _context.PurchaseOrderProducts.Include(pop=> pop.Product)
                .FirstOrDefaultAsync(pop => pop.ProductId == id);
            ViewData["PurchaseOrderId"] = new SelectList(_context.PurchaseOrders.Where(pop => pop.Received == false), "Id", "Name");
            return View(purchaseOrderProduct);
        }

        // POST: PurchaseOrderProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,PurchaseOrderId,QuantityOrdered,ApplicationUserId")] PurchaseOrderProduct purchaseOrderProduct)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                purchaseOrderProduct.ApplicationUserId = user.Id;
                purchaseOrderProduct.ProductId = purchaseOrderProduct.Id;
                purchaseOrderProduct.Id = 0;
                
                _context.Add(purchaseOrderProduct);
                await _context.SaveChangesAsync();
                return Redirect("/PurchaseOrders");
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
