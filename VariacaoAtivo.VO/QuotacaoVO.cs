using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VariacaoAtivo.VO
{
    [Table("Quotacao")]
    public class QuotacaoVO
    {
        [Key]
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public double Valor { get; set; }
        public double VariacaoD1 { get; set; }
        public double VariacaoPrimeiraData { get; set; }
    }
}
