using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eg.Core.DTOs
{
    [Serializable]
    public class GenericDTO<TDTOId>
    {
        public virtual TDTOId Id { get; set; }
    }
}
