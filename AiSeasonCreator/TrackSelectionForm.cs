using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiSeasonCreator
{
    public partial class TrackSelectionForm : Form
    {
        public TrackSelectionForm()
        {
            InitializeComponent();
        }

        private void TrackSelectionForm_Load(object sender, EventArgs e)
        {
            PopulateTrackSelection();
        }

        private void PopulateTrackSelection()
        {
            var ss = MainForm.FullSchedule;
            var si = MainForm.SeasonSeriesIndex;

            for (int i = 0; i < ss[si].Schedules.Count; i++)
            {
                for (int j = 0; j < MainForm.TrackDetails.Length; j++)
                {
                    if (ss[si].Schedules[i].Track.TrackId == MainForm.TrackDetails[j].TrackId)
                    {
                        var track = ss[si].Schedules[i].Track.TrackName;
                        var item = MainForm.TrackDetails[j].AiEnabled ? track : $"*Ai UNAVAILABLE* {track}";
                        var isChecked = MainForm.TrackDetails[j].AiEnabled;

                        tracksCheckedListBox.Items.Add(item, isChecked);
                        if (!MainForm.TrackDetails[j].AiEnabled)
                        {
                            var lastIndex = tracksCheckedListBox.Items.Count - 1;
                            tracksCheckedListBox.ItemCheck += (sender, e) =>
                            {
                                if (e.Index == lastIndex)
                                {
                                    e.NewValue = e.CurrentValue;
                                }
                            };
                        }
                    }
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            MainForm.UnselectedTracks = new List<int> { };

            for (int i = 0; i < tracksCheckedListBox.Items.Count; i++)
            {
                if (!tracksCheckedListBox.GetItemChecked(i))
                {
                    MainForm.UnselectedTracks.Add(i);
                }
            }

            if (MainForm.FullSchedule[MainForm.SeasonSeriesIndex].Schedules.Count == MainForm.UnselectedTracks.Count)
            {
                return;
            }

            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
