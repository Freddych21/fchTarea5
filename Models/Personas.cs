using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fchTarea5.Models
{

    [Table("personas")]
    public class Personas
    {

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(25), Unique]
        public string Nombre { get; set; }


    }
}
