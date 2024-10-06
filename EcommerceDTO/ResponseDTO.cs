using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceDTO
{
    public class ResponseDTO<T>
    {
        public T? Result {  get; set; }
        public bool ItsRight { get; set; }
        public string? Message { get; set; }
    }
}
