using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessengerApi.Interface
{
    public interface ISoftDeletes
    {
        DateTime? DeletedAt { get; set; }
    }
}