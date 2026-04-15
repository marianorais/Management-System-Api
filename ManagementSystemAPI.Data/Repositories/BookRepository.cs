using Microsoft.EntityFrameworkCore;
using ManagementSystemAPI.Core.Models;
using ManagementSystemAPI.Core.Models.Domain;
using ManagementSystemAPI.Data.Interfaces.ManagementSystemAPI.Data.Repositories;
using System;

namespace ManagementSystemAPI.Data.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAll()
            => await _context.Books.ToListAsync();

        public async Task<Book?> GetById(int id)
            => await _context.Books.FindAsync(id);

        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book?> Update(Book book)
        {
            var existing = await _context.Books.FindAsync(book.Id);
            if (existing == null) return null;

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.Isbn = book.Isbn;
            existing.PublishedYear = book.PublishedYear;

            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book == null) return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}