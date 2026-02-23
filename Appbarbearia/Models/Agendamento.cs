using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Appbarbearia.Models
{
    public class Agendamento
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }

        public int ClienteID { get; set; }
        public DateTime DataCompleta { get; set; }

        public string ServicoSelecionado { get; set; }

        public string Barbeiro  { get; set; }   
     }
}
