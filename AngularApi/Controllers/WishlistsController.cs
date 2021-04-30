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
    public class WishlistsController : ControllerBase
    {
        private readonly DataContext _context;

        public WishlistsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Wishlists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Wishlist>>> GetWishLists()
        {
            var username = User.Identity.Name;

            var user = _context.Users.FirstOrDefault(u => u.UserName =="q" /*username*/);
            var userid = user.Id;

            var exitwishlist = _context.WishLists.FirstOrDefault(w => w.UserID == userid);

            var products = exitwishlist.Products.ToList();
            return Ok(products);
        }

        // GET: api/Wishlists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Wishlist>> GetWishlist(string id)
        {
            var wishlist = await _context.WishLists.FindAsync(id);

            if (wishlist == null)
            {
                return NotFound();
            }

            return wishlist;
        }

        // PUT: api/Wishlists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWishlist(string id, Wishlist wishlist)
        {
            if (id != wishlist.UserID)
            {
                return BadRequest();
            }

            _context.Entry(wishlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WishlistExists(id))
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

        // POST: api/Wishlists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Wishlist>> PostWishlist(int id)
        {
            var Product = _context.Products.FirstOrDefault(p => p.ID == id);
            var username = User.Identity.Name;

            var user = _context.Users.FirstOrDefault(u => u.UserName == "q");
            var userid = user.Id;

            Wishlist exitwishlist = _context.WishLists.FirstOrDefault(w => w.UserID == "q");
            bool find = false;
            // bool productAdded = false;
            foreach (var item in exitwishlist.Products)
            {
                if (item.ID == Product.ID)
                { find = true; }
            }
            if (!find)
            {
                exitwishlist.Products.Add(Product);

                //productAdded = true;
            }


            //if(exitwishlist!=null)
            //{
            //    exitwishlist.Products.ToList().Add(Product);

            //    await _context.SaveChangesAsync();
            //    return NoContent();
            //}
            //else
            //{
            //    Wishlist wishlist = new Wishlist();

            //    wishlist.Products.ToList().Add(Product);
            //    wishlist.UserID = userid;
            //    _context.WishLists.Add(wishlist);
            //    try
            //    {
            //        await _context.SaveChangesAsync();
            //    }
            //    catch (DbUpdateException)
            //    {
            //        if (WishlistExists(wishlist.UserID))
            //        {
            //            return Conflict();
            //        }
            //        else
            //        {
            //            throw;
            //        }
            //    }

            return CreatedAtAction("GetWishlist", exitwishlist);

        }



        // DELETE: api/Wishlists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWishlist(int id)
        {
            var Product = _context.Products.FirstOrDefault(p => p.ID == id);
            var username = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(u => u.UserName == username);
            var userid = user.Id;

            var exitwishlist = _context.WishLists.FirstOrDefault(w => w.UserID == userid);

            if (Product == null)
            {
                return NotFound();
            }

            exitwishlist.Products.Remove(Product);
            //var wishlist = await _context.WishLists.FindAsync(id);
            //if (wishlist == null)
            //{
            //    return NotFound();
            //}

            //_context.WishLists.Remove(wishlist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool WishlistExists(string id)
        {
            return _context.WishLists.Any(e => e.UserID == id);
        }
    }
}
