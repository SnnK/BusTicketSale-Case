using System;
using System.ComponentModel.DataAnnotations;

namespace OBiletCase.Web.Models
{
    //fluent validation kullanılabilirdi. single responsibility principle açısından daha doğru. Case olduğundan küçük bir proje olduğu için Data Annotations kullanmak da uygun.

    public class Search
    {
        [Required(ErrorMessage = "\"Nereden\" alanı boş geçilemez.")]
        public string From { get; set; }
        [Required(ErrorMessage = "\"Nereye\" alanı boş geçilemez.")]
        public string To { get; set; }
        [Required(ErrorMessage = "\"Tarih\" alanı boş geçilemez.")]
        [DataType(DataType.Date, ErrorMessage = "\"Tarih\" alanı geçerli değil.")]
        public DateTime? Date { get; set; }
    }
}
