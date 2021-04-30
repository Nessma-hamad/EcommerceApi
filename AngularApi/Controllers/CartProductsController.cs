using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApi.Models;

namespace AngularApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartProductsController : ControllerBase
    {
        private readonly DataContext _context;

        public CartProductsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/CartProducts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CartProduct>>> GetCartProducts()
        {
            return await _context.CartProducts.ToListAsync();
        }

        // GET: api/CartProducts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CartProduct>> GetCartProduct(int id)
        {
            var cartProduct = await _context.CartProducts.FindAsync(id);

            if (cartProduct == null)
            {
                return NotFound();
            }

            return cartProduct;
        }

        // PUT: api/CartProducts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCartProduct(int id, CartProduct cartProduct)
        {
            if (id != cartProduct.ID)
            {
                return BadRequest();
            }

            _context.Entry(cartProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CartProducts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CartProduct>> PostCartProduct(int id)
        {
            var username = User.Identity.Name;

            var user = _context.Users.FirstOrDefault(u => u.UserName == "q");
            var userid = user.Id;
            CartProduct cartProduct = new CartProduct()
            {
                CartID = user.Id,
                ProductID = id,
                Quantity = 1
            };

            Cart cart = _context.Carts.FirstOrDefault(c=>c.ID==user.Id);
            bool find = false;
            bool productAdded = false;

            foreach (var item in cart.CartProducts)
            {
                if (item.ProductID == cartProduct.ProductID)
                {
                    find = true;
                    item.Quantity += 1;
                }
            }
            if (!find)
            {
                cart.CartProducts.Add(cartProduct);
                _context.SaveChanges();
                productAdded = true;

            }
           // return productAdded;

            //    _context.CartProducts.Add(cartProduct);
            //    await _context.SaveChangesAsync();

               return CreatedAtAction("GetCartProduct", cartProduct);
        }

        // DELETE: api/CartProducts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartProduct(int id)
        {
            var cartProduct = await _context.CartProducts.FindAsync(id);
            if (cartProduct == null)
            {
                return NotFound();
            }

            _context.CartProducts.Remove(cartProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CartProductExists(int id)
        {
            return _context.CartProducts.Any(e => e.ID == id);
        }
    }
}
