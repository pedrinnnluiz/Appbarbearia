using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Appbarbearia.Models;


namespace Appbarbearia.Models
{
    public class DataBaseService
    {

        private readonly SQLiteAsyncConnection _db;

        public DataBaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Cliente>().Wait();

        }
        public Task<int> SalvarClienteAsync(Cliente cliente)
        {
            return _db.InsertAsync(cliente);
        }
        public Task<List<Cliente>> ListarClientesAsync()
        {
            return _db.Table<Cliente>().ToListAsync();
        }
    }
}
