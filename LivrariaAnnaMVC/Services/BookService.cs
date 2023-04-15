using LivrariaAnnaMVC.Data;
using LivrariaAnnaMVC.Models;
using LivrariaAnnaMVC.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace LivrariaAnnaMVC.Repository
{
    public class BookService : IBooksService
    {
        private readonly RelacaoLivrosDBContext _dbContext;
        public BookService(RelacaoLivrosDBContext relacaoLivrosDBContext)
        {

            _dbContext = relacaoLivrosDBContext;
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books
                
                .Include(x => x.Author)
                .FirstOrDefaultAsync(x => x.BookId == id);
        }

        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _dbContext.Books

                .Include(x => x.Author)
                .ToListAsync();
        }

        public async Task<BookModel> AddBook(BookModel book)
        {
            await _dbContext.Books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return book;
        }

        public async Task<BookModel> RefreshBooks(BookModel book, int id)
        {
            BookModel getBookById = await GetBookByIdAsync(id);
            if (getBookById == null)
            {
                throw new Exception($"livro de código:{id} Não encontrado no banco de dados.");
            }

            getBookById.Title = book.Title;
            getBookById.Isbn = book.Isbn;
            getBookById.Year = book.Year;
            getBookById.AuthorId = book.AuthorId;

            _dbContext.Books.Update(getBookById);
            await _dbContext.SaveChangesAsync();

            return getBookById;
        }

        public async Task<bool> DeleteBook(int id)
        {
           BookModel getBookById = await GetBookByIdAsync(id);
            if (getBookById == null)
            {
                throw new Exception($"Livro de código:{id} Não encontrado no banco de dados.");

            }
            _dbContext.Books.Remove(getBookById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
