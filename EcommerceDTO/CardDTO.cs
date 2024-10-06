using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
    public class CardDTO
    {
        [Required(ErrorMessage = "Ingrese titular")]
        public string? Holder {  get; set; }
        [Required(ErrorMessage = "Ingrese el numero de tarjeta")]
        public string? Numbrer { get; set; }
        [Required(ErrorMessage = "Ingrese vigencia")]
        public string? Validity { get; set; }
        [Required(ErrorMessage = "Ingrese cvv")]
        public string? cvv { get; set; }
    }
    
}
