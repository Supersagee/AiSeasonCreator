using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public interface ISettingsService
    {
        string GetFolderPath(string name);
        string GetFolderPath();
    }
}
