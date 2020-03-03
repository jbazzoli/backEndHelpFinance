using System.ComponentModel.DataAnnotations;

namespace helpFinanceDotNet.Models
{
    public class Debit
    {
        [Key]
        public int id { get; set; }
        public string description { get; set; }
        public double value { get; set; }
        public int category { get; set; }
    }
}