using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SISPUN.Api.BusinessLogic.Models
{
    public class ResponseStatus
    {
        public List<string> validations { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }
        public string code { get; set; }
        public string Message { get; set; }
        //public List<Validaciones> validations { get; set; }
    }

}
