using LivrariaAnnaMVC.Models;

namespace LivrariaAnnaMVC.Repository.Interfaces
{
    public interface IAuthorService
    {
        Task<List<AuthorModel>> GetAuthorAsync();
        Task<AuthorModel> GetAuthorByIdAsync(int id);
        Task<AuthorModel> AddAuthor(AuthorModel author);
        Task<AuthorModel> RefreshAuthor(AuthorModel author, int id);
        Task <bool> DeleteAuthorAsync(int id);
       
    }
}
