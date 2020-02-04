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
using ShopCaddy.Models.ViewModels;

namespace ShopCaddy.Controllers
{
    public class PurchaseOrdersController : Controller
    {
        public class POPViewModel
        {
            public int Quantity { get; set; }
            public Product Product { get; set; }
            public PurchaseOrderProduct PurchaseOrderProduct {get;set;}
            public List<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
            public Vendor Vendor { get; set; }
            public PurchaseOrder PurchaseOrder { get; set; }
        }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PurchaseOrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: PurchaseOrders
        public async Task<IActionResult> Index()
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext = _context.PurchaseOrders
                                       .Where(p => p.ApplicationUser.Id == user.Id)
                                       .Include(p => p.PurchaseOrderProduct)
                                       .Include(p => p.Vendor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PurchaseOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            //var Model = _context.PurchaseOrders.Where(po => po.Id == id).FirstOrDefault();
            //if (id == null)
            //{
            //    return NotFound();
            //}

            //DetailsPurchaseOrderViewModel vm = new DetailsPurchaseOrderViewModel()
            //{
            //    PurchaseOrderProduct = Model.PurchaseOrderProduct,
            //    Vendor = Model.Vendor,
            //    PurchaseOrderProducts = _context.PurchaseOrderProducts.Select(pop => new SelectListItem
            //    {
            //        Value = pop.Id.ToString(),
            //        Text = pop.Product.Name
            //    })

            //}


            if (id == null)
            {
                return NotFound();
            }


            var purchaseOrders = await _context.PurchaseOrders
                .Include(p => p.PurchaseOrderProducts)
                .ThenInclude(op => op.Product)
                .ThenInclude(p => p.ProductType)
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);

            var groupedProducts = purchaseOrders.PurchaseOrderProducts.GroupBy(p => p.Product.Name)
            .Select(pop => new POPViewModel        
            {
                 Product = pop.ToList()[0].Product,
                 Quantity = pop.Count()
             });

       
            // var groupPO = purchaseOrders.PurchaseOrderProducts in _context.PurchaseOrders
            //     group purchaseOrders.PurchaseOrderProducts.Product by purchaseOrders.PurchaseOrderProduct.Product.Id
            if (purchaseOrders == null)
            {
                return NotFound();
            }

            return View(groupedProducts);
        
    }

        // GET: PurchaseOrders/Create
        public IActionResult Create()
        {
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id");
            return View();
        }

        // POST: PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,VendorId,Received,DateReceived,ApplicationUserId")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                purchaseOrder.ApplicationUserId = user.Id;
                _context.Add(purchaseOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id", purchaseOrder.VendorId);
            return View(purchaseOrder);
        }

        // GET: PurchaseOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["VendorId"] = new SelectList(_context.Vendors, "Id", "Id", purchaseOrder.VendorId);
            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        
        public async Task<IActionResult> Edit(int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var purchaseOrders = await _context.PurchaseOrders.FirstOrDefaultAsync(m => m.Id == id);
                    purchaseOrders.Received = true;
                    purchaseOrders.DateReceived = DateTime.Now;
                    _context.Update(purchaseOrders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaseOrderExists(id))
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
            return View(id);
        }

        // GET: PurchaseOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaseOrder = await _context.PurchaseOrders
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }

            return View(purchaseOrder);
        }

        // POST: PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            _context.PurchaseOrders.Remove(purchaseOrder);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrders.Any(e => e.Id == id);
        }
    }
}
