using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Services
{
    public class AboutService : IAboutService
    {
        public string GetAboutSection()
        {
            var builder = new StringBuilder();

            builder.AppendLine("The purpose of this program is to create AI seasons and rosters based on the iRacing multiplayer seasons, " +
                "along with editing existing user rosters with minimal effort.");

            builder.AppendLine("");
            builder.AppendLine("The AI seasons that are created will contain the proper tracks, cars, time/laps, etc. in order to match the multiplayer series. " +
                "All seasons will also automatically create a roster, except when the 'Exclude Roster' checkbox is checked.");

            builder.AppendLine("");
            builder.AppendLine("Individual AI rosters can also be created based on a series, and existing rosters can also be updated with different attributes. " +
                "The attribute sliders in the 'Roster' tab are min and max ranges for a particular attribute. " +
                "For example, if 'Aggression' is set to 25%-75%, all drivers in that roster will have their aggression set randomly between those percentages. " +
                "When updating a roster, unchecking an attribute will leave that particular attribute as is for all drivers.");

            builder.AppendLine("");
            builder.AppendLine("Keep in mind that some cars and tracks are not AI enabled.");

            return builder.ToString();
        }

        public void GoToForum()
        {
            var url = "https://forums.iracing.com/discussion/40203/aiseasoncreator-make-ai-seasons-based-on-the-the-series-schedules-on-the-fly/p1";

            var psi = new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            };

            try
            {
                Process.Start(psi);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while opening the link: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
