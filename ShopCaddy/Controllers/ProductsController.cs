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
    public class ProductsController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: Products
        public async Task<IActionResult> Index([FromRoute] int Id)
        {
            var user = await GetCurrentUserAsync();

            var applicationDbContext =  _context.Products

                                       .Where(p => p.ApplicationUser.Id == user.Id)
                                       .Where(p => p.ProductTypeId == Id)
                                       .Include(p => p.ProductType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await GetCurrentUserAsync();
            var product = await _context.Products
                .Where(p=> p.ApplicationUser.Id == user.Id)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public async Task<IActionResult> Create()
        {
            ApplicationUser user = await GetCurrentUserAsync();
           // Product product = await _context.Products.Include(p => p.ProductType)
                //.FirstOrDefaultAsync(p => p.ProductTypeId = product.ProductType.Id);
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.Where(p => p.ApplicationUserId == user.Id), "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductTypeId,Name,Price,Image,Season,Quantity,SerialNumber,ApplicationUserId")] Product product)
        {
            ModelState.Remove("Id");
            if (ModelState.IsValid)
            {
                var user = await GetCurrentUserAsync();
                product.ApplicationUserId = user.Id;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return Redirect("/ProductTypes");
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes, "Id", "Id", product.ProductTypeId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ApplicationUser user = await GetCurrentUserAsync();
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ProductTypeId"] = new SelectList(_context.ProductTypes.Where(p => p.ApplicationUserId == user.Id), "Id", "Name");
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductTypeId,Name,Price,Image,Season,Quantity,SerialNumber")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser user = await GetCurrentUserAsync();
                    product.ApplicationUserId = user.Id;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect("/ProductTypes");
            }
            return View(product);
        }

        // Method for changing the Quantity of multiple Products
        public async Task<IActionResult> IncreaseProductQuantity(int id)
        {
            if (ModelState.IsValid)
            {
                //try
               // {
                    PurchaseOrder purchaseOrder = new PurchaseOrder();
                purchaseOrder = await _context.PurchaseOrders
                    .Include(po => po.PurchaseOrderProducts)
                    .ThenInclude(pop => pop.Product)
                    .FirstOrDefaultAsync(m => m.Id == id);


                    PurchaseOrderProduct purchaseOrderProduct = new PurchaseOrderProduct();
                //Conditional to select a product where purchaseOrderId == id
                    List<Product> products = new List<Product>();
                   // if (purchaseOrder.PurchaseOrderProduct.PurchaseOrderId == id)
                   // {
                        //Define the List of Products from the beginning

                        products = purchaseOrder.PurchaseOrderProducts.Select(p => p.Product).ToList();
                if (purchaseOrder.Received == true)
                {
                    ApplicationUser user = await GetCurrentUserAsync();
                    //var countProductsGrouped = purchaseOrder.PurchaseOrderProducts.GroupBy(pop => pop.Product.Name).Count();
                    //Very Close. This is were I need to Update the products with the count of the certain POP
                    //var product = purchaseOrder.PurchaseOrderProducts.Select(pop => pop.Product);
                    //if (countProductsGrouped <= 1) { }
                    // Maybe try foreach groupedproduct in POPViewModel?
                    // This i wrong.. Maybe foreach product in groupedProducts
                    //var productsGrouped = purchaseOrder.PurchaseOrderProducts.GroupBy(pop => pop.Product.Name);
                    //purchaseOrder.PurchaseOrderProduct.QuantityOrdered = countProductsGrouped;
                    foreach (Product product in purchaseOrder.PurchaseOrderProducts.Select(pop => pop.Product))
                        {
                        if (purchaseOrder.PurchaseOrderProducts.GroupBy(pop => pop.Product.Name).Any(pop => pop.Count() < 2)){
                            var numberOfProductsGrouped = purchaseOrder.PurchaseOrderProducts.Count();
                            //purchaseOrder.PurchaseOrderProduct.QuantityOrdered = numberOfProductsGrouped;
                            product.Quantity = product.Quantity + numberOfProductsGrouped;
                            ;
                            products.Select(p => p.ApplicationUserId = user.Id);
                            _context.Update(product);
                            await _context.SaveChangesAsync();
                        }
                        else if(purchaseOrder.PurchaseOrderProducts.GroupBy(pop => pop.Product.Name).Any(pop => pop.Count() > 1))
                        {
                            var numberOfProductsGrouped = purchaseOrder.PurchaseOrderProducts.GroupBy(pop => pop.Product.Id).Count();
                            //purchaseOrder.PurchaseOrderProduct.QuantityOrdered = numberOfProductsGrouped;
                            product.Quantity = product.Quantity + numberOfProductsGrouped;
                            ;
                            products.Select(p => p.ApplicationUserId = user.Id);
                            _context.Update(product);
                            await _context.SaveChangesAsync();

                        }
                     };
                    //product = product.Quantity + purchaseOrder.PurchaseOrderProducts.Select(pop => pop.Product).Count();
                    //products.Select(p => p.Quantity = p.Quantity + purchaseOrder.PurchaseOrderProducts.Count());
                  //  ApplicationUser user = await GetCurrentUserAsync();
                  //  products.Select(p => p.ApplicationUserId = user.Id);
                   // _context.Update(product);
                   // await _context.SaveChangesAsync();
                }
                else { }
                //catch (DbUpdateConcurrencyException)
                //{
                //    if (!ProductExists(id))
                //    {
                //        return NotFound();
                //    }
                //    else
                //    {
                //        throw;
                //    }
                //}
                return View(products);
            }
            return View(id);
        }
        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Redirect("/ProductTypes");
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
