using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models;

[Table("User")]
public class UserEntity
{
    public Guid Id { get; set; }
    
    [Required]
    public string UserName { get; set; }
    
    [Required]
    public DateTime RegistrationDate { get; set; }
}