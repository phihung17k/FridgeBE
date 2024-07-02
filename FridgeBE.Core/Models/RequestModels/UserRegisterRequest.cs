using System.ComponentModel.DataAnnotations;

namespace FridgeBE.Core.Models.RequestModels
{
    public class UserRegisterRequest
    {
        [StringLength(150)]
        public string Email { get; set; }
        
        public string Password { get; set; }
    }
}