using System;
using System.Collections.Generic;
using System.Text;

namespace VariacaoAtivo.VO
{
    public class ResponseMessageVO
    {
        public ResponseMessageVO()
        {
            Success = true;
        }

        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
