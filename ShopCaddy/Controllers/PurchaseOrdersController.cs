using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
            public int PurchaseOrderProductId { get; set; }
            public PurchaseOrderProduct PurchaseOrderProduct {get;set;}
            public List<PurchaseOrderProduct> PurchaseOrderProducts { get; set; }
            public Vendor Vendor { get; set; }
            public PurchaseOrder PurchaseOrder { get; set; }
            public double Price { get; set; }
          public List<POPViewModel> groupedProducts { get; set; }
        }

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public PurchaseOrdersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize]
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
            if (id == null)
            {
                return NotFound();
            }
            //Creating a new Instance of the Purchase Order Product View Model and pulling all the information needed
            POPViewModel vm = new POPViewModel();
             vm.PurchaseOrder = await _context.PurchaseOrders
                .Include(p => p.PurchaseOrderProducts)
                .ThenInclude(op => op.Product)
                .ThenInclude(p => p.ProductType)
                .Include(p => p.Vendor)
                .FirstOrDefaultAsync(m => m.Id == id);

            //Grouping all the Purchase Order Products on the Products Details Page by name so they stack
            //Increases quantity as well as totals the price of the grouped products
             vm.groupedProducts = vm.PurchaseOrder.PurchaseOrderProducts.GroupBy(p => p.Product.Name)
            .Select(pop => new POPViewModel
            {
                Product = pop.ToList()[0].Product,
                Quantity = pop.Count(),
                Price = pop.Sum(po => po.Product.Price),
                Vendor = pop.ToList()[0].PurchaseOrder.Vendor,
                PurchaseOrderProductId = pop.ToList()[0].Id
             }).ToList();

      
            if (vm.PurchaseOrder == null)
            {
                return NotFound();
            }

            return View(vm);
        
    }

        // GET: PurchaseOrders/Create
        public async Task<IActionResult> Create()
        {
           
            ApplicationUser user = await GetCurrentUserAsync();
            ViewData["VendorId"] = new SelectList(_context.Vendors.Where(p => p.ApplicationUserId == user.Id), "Id", "Contact");
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
            ApplicationUser user = await GetCurrentUserAsync();
            var purchaseOrder = await _context.PurchaseOrders.FindAsync(id);
            if (purchaseOrder == null)
            {
                return NotFound();
            }
            ViewData["VendorId"] = new SelectList(_context.Vendors.Where(p => p.ApplicationUserId == user.Id), "Id", "Contact");
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
                    //To Edit the bool in purchase orders for the Received button per purchase order
                    //Also assigns a DateTime to the received purchase order
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
