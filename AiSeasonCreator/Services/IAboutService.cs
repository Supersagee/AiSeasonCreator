using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public interface IAboutService
    {
        string GetAboutSection();
        void GoToForum();
    }
}
