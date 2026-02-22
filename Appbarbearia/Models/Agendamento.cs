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
        public string Id {  get; set; }

        public string ClienteID { get; set; }
        public DateTime Data { get; set; }

        public string Serviço { get; set; }
     }
}
