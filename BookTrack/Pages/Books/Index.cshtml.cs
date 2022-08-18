using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookTrack.Data;
using BookTrack.Models;

namespace BookTrack.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly BookTrack.Data.BookTrackContext _context;

        public IndexModel(BookTrack.Data.BookTrackContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book.ToListAsync();
            }
        }
    }
}
