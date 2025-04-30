using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public interface IAboutService
    {
        string GetGeneralAboutSection();
        string GetSeasonAboutSection();
        string GetRosterAboutSection();
        void GoToForum();
    }
}
