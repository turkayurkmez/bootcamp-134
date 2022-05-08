using System.ComponentModel.DataAnnotations;

namespace Catalog.API.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Kullanıcı adı gereklidir.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Şifre gereklidir.")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
