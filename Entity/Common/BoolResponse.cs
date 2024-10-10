using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Common
{
    public class BoolResponse
    {
        public Guid RecordId { get; set; }
        public int Id { get; set; }
        public bool IsValid { get; set; }
        public string Message { get; set; }
    }
}
