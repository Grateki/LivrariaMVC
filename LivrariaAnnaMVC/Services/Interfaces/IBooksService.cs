using LivrariaAnnaMVC.Models;

namespace LivrariaAnnaMVC.Repository.Interfaces
{
    public interface IBooksService
    {
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBookByIdAsync(int id);
        Task<BookModel> AddBook(BookModel book);
        Task<BookModel> RefreshBooks(BookModel book, int id);
        Task <bool> DeleteBook(int id);
       
    }
}
