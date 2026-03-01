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
            _db.CreateTableAsync<Agendamento>().Wait();

        }
            public Task<int> SalvarClienteAsync(Cliente cliente)
            {
                return _db.InsertAsync(cliente);
            }
            public Task<List<Cliente>> ListarClientesAsync()
            {
                return _db.Table<Cliente>().ToListAsync();
            }
            public Task<Cliente> LoginAsync(string Email, string Senha)
            {
                return _db.Table<Cliente>()
                    .Where(x => x.Email == Email && x.Senha == Senha)
                    .FirstOrDefaultAsync();
        }
        public Task<int> DeleteUsuarioAsync(int id)
        {
            return _db.DeleteAsync<Cliente>(id);
        }
        
        public Task<int> SalvarAgendamento(Agendamento agendamento)
        {
            return _db.InsertAsync(agendamento);
        }

        public Task<List<Agendamento>> ListarAgendamento(int clienteId)
        {
            return _db.Table<Agendamento>()
                .Where(a => a.ClienteID == clienteId)
                .ToListAsync();

        }

        public Task <List<Agendamento>> ListarAgendamentoPorCLiente(int clienteId)
        {
            return _db.Table<Agendamento>()
                .Where(a => a.ClienteID == clienteId)
                .OrderByDescending(a => a.DataCompleta)
                .ToListAsync();
                
        }
      
    }
}
