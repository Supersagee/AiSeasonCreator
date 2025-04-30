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
        public string GetGeneralAboutSection()
        {
            var builder = new StringBuilder();

            builder.AppendLine("General:");
            builder.AppendLine("The purpose of this program is to create AI seasons and rosters based on the iRacing multiplayer seasons, " +
                "along with editing existing user rosters with minimal effort. Keep in mind that some cars and tracks are not AI enabled.");

            return builder.ToString();
        }

        public string GetSeasonAboutSection()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Seasons:");
            builder.AppendLine("The AI seasons that are created will contain the proper tracks, cars, time/laps, etc. in order to match the multiplayer series. " +
                "All seasons will also automatically create a roster, except when 'Exclude Roster' or an already existing roster is selected in the Roster drop down box.");

            return builder.ToString();
        }
        public string GetRosterAboutSection()
        {
            var builder = new StringBuilder();

            builder.AppendLine("Rosters:");
            builder.AppendLine("Individual AI rosters can also be created based on a series. " +
                "The attribute sliders in the 'Roster' tab are min and max ranges for a particular attribute. " +
                "For example, if 'Aggression' is set to 25%-75%, all drivers in that roster will have their aggression set randomly between those percentages.");

            builder.AppendLine("");
            builder.AppendLine("When updating a roster, one or more drivers can be selected for updating, as well as the ability to update all drivers in a roster at " +
                "the same time. Only attributes sliders that are checked will be used when randomizing driver skills. When updating a roster, using the '-/+ Randomize' " +
                "will take the skill of a particular driver, and randomly set the skill of that driver within the -/+ range. For example, if a drivers Optimism skill is" +
                "at 60, and the Optimism slider is set from '-10 to 10', then the new Optimism skill will be randomly set anywhere from 50 to 70. Additionally, skills in the " +
                "driver data table can be individually selected and updated manually.");

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
