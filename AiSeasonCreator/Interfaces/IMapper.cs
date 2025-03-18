using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Interfaces
{
    public interface IMapper<T>
    {
        T Map(int eventIndex, string eventGuid);
    }
}
