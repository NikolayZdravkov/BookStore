using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookStore.Models;
using Bookstore.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Bookstore.Data
{
    public class BookstoreContext : IdentityDbContext<DefaultUser>
    {
        public BookstoreContext (DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
    }
}
