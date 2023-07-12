using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankMvc.Models;

public class TransactionModel
{
    [Key]
    public int TransactionId { get; set; }
    
    [MaxLength(20)]
    public string AccountNumber { get; set; }
    
    [MaxLength(100)]
    public string BeneficiaryName { get; set; }
    
    [MaxLength(50)]
    public string BankName { get; set; }
    
    [MaxLength(11)]
    public string SWIFTCode { get; set; }
    
    public int Amount { get; set; }
}