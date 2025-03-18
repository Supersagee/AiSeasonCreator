using AiSeasonCreator.FormOptions;
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
        private readonly UserSelectedOptions _userSelectedOptions;
        public TrackSelectionForm(UserSelectedOptions userSelectedOptions)
        {
            InitializeComponent();
            _userSelectedOptions = userSelectedOptions;
        }

        private void TrackSelectionForm_Load(object sender, EventArgs e)
        {
            PopulateTrackSelection();
        }

        private void PopulateTrackSelection()
        {
            var ss = _userSelectedOptions.FullSchedule;
            var si = _userSelectedOptions.SeasonSeriesIndex;

            for (int i = 0; i < ss[si].Schedules.Count; i++)
            {
                for (int j = 0; j < _userSelectedOptions.TrackDetails.Length; j++)
                {
                    if (ss[si].Schedules[i].Track.TrackId == _userSelectedOptions.TrackDetails[j].TrackId)
                    {
                        var track = ss[si].Schedules[i].Track.TrackName;
                        var item = _userSelectedOptions.TrackDetails[j].AiEnabled ? track : $"*Ai UNAVAILABLE* {track}";
                        var isChecked = _userSelectedOptions.TrackDetails[j].AiEnabled;

                        tracksCheckedListBox.Items.Add(item, isChecked);
                        if (!_userSelectedOptions.TrackDetails[j].AiEnabled)
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
            _userSelectedOptions.UnselectedTracks = new List<int> { };

            for (int i = 0; i < tracksCheckedListBox.Items.Count; i++)
            {
                if (!tracksCheckedListBox.GetItemChecked(i))
                {
                    _userSelectedOptions.UnselectedTracks.Add(i);
                }
            }

            if (_userSelectedOptions.FullSchedule[_userSelectedOptions.SeasonSeriesIndex].Schedules.Count == _userSelectedOptions.UnselectedTracks.Count)
            {
                return;
            }

            tracksCheckedListBox.Items.Clear();
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            tracksCheckedListBox.Items.Clear();
            Close();
        }
    }
}
