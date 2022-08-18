using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookTrack.Models;

namespace BookTrack.Data
{
    public class BookTrackContext : DbContext
    {
        public BookTrackContext (DbContextOptions<BookTrackContext> options)
            : base(options)
        {
        }

        public DbSet<BookTrack.Models.Book> Book { get; set; } = default!;
    }
}
