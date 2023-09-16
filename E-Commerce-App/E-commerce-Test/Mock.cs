using E_Commerce_App.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using E_Commerce_App.Models;

namespace E_commerce_Test
{
    public class Mock : IDisposable
    {
        private readonly SqliteConnection _connection;
        public readonly E_CommerceDBContext  _db;



        public Mock()
        {
            _connection = new SqliteConnection("Filename=:memory:");
            _connection.Open();

            _db = new E_CommerceDBContext(
            new DbContextOptionsBuilder<E_CommerceDBContext>()
            .UseSqlite(_connection).Options);
            _db.Database.EnsureCreated();

        }
         public async Task createCategiry()
        {
            var category1 = new Category()
            {
                Name = "A",
               
            };

            var category2 = new Category()
            {
                Name = "B",
                
            };

            await _db.Category.AddAsync(category1);
            await _db.SaveChangesAsync();
        }




        public void Dispose()
        {
            _db?.Dispose();
            _connection?.Dispose();
        }
    }
}
