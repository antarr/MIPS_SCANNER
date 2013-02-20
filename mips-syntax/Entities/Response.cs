using System.Collections.Generic;

namespace mips_syntax.Entities
{
    public class Response
    {
        public List<string> Reasons;
        public bool Success = true;

        public Response()
        {
            Reasons = new List<string>();
            Success = true;
        }
    }
}