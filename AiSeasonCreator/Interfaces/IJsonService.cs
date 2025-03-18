using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Interfaces
{
    public interface IJsonService
    {
        T Load<T>(string filePath);
        void Save<T>(string filePath, T data);
    }
}
