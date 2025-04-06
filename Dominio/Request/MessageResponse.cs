using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Request
{
    public class MessageResponse<T>
    {
        public int StatuCode {  get; set; }
        public T Payload { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
