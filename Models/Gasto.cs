
using System;

namespace GastosAPI.Models
{
    public class Gasto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime Data { get; set; }
        public int CategoriaGastoId { get; set; }  
        public CategoriaGasto CategoriaGasto { get; set; }  
    }
}
