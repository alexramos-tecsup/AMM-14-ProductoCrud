using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace ProductoCrud.Model
{
    public class ProductoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nombre { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
    }
}
