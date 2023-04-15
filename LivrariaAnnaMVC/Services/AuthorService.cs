using LivrariaAnnaMVC.Repository.Interfaces;
using LivrariaAnnaMVC.Data;
using LivrariaAnnaMVC.Models;

using Microsoft.EntityFrameworkCore;

namespace LivrariaAnnaMVC.Repository
{
    public class AuthorService : IAuthorService
    {
        private readonly RelacaoLivrosDBContext _dbContext;
        public AuthorService(RelacaoLivrosDBContext relacaoLivrosDBContext)
        {

            _dbContext = relacaoLivrosDBContext;
        }

        public async Task<AuthorModel> GetAuthorByIdAsync(int id)
        {
            return await _dbContext.Authors

                .FirstOrDefaultAsync(x => x.AuthorId == id);
        }

        public async Task<List<AuthorModel>> GetAuthorAsync()
        {
            return await _dbContext.Authors.ToListAsync();
        }

        public async Task<AuthorModel> AddAuthor(AuthorModel author)
        {
            await _dbContext.Authors.AddAsync(author);
            await _dbContext.SaveChangesAsync();

            return author;
        }

        public async Task<AuthorModel> RefreshAuthor(AuthorModel author, int id)
        {
            AuthorModel getAuthorById = await GetAuthorByIdAsync(id);
            if (getAuthorById == null)
            {
                throw new Exception($"Author de código:{id} Não encontrado no banco de dados.");
            }

            getAuthorById.AuthorName = author.AuthorName;
            getAuthorById.AuthorLastName = author.AuthorLastName;
            getAuthorById.Email = author.Email;
            getAuthorById.Birth = author.Birth;

            _dbContext.Authors.Update(getAuthorById);
            await _dbContext.SaveChangesAsync();

            return getAuthorById;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            AuthorModel getAuthorById = await GetAuthorByIdAsync(id);
            if (getAuthorById == null)
            {
                throw new Exception($"Author de código:{id} Não encontrado no banco de dados.");

            }
            _dbContext.Authors.Remove(getAuthorById);
            await _dbContext.SaveChangesAsync();
            return true;
        }


    }
}
