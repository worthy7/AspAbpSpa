using System.ComponentModel.DataAnnotations;

namespace AspAbpSPAMay.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}