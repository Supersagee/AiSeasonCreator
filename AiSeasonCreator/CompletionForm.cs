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
    public partial class CompletionForm : Form
    {
        public CompletionForm()
        {
            InitializeComponent();
        }

        private string Completion;
        private List<string> NotAvailableTracks;
        public CompletionForm(string completion, List<string> notAvailableTracks)
        {
            InitializeComponent();

            Completion = completion;
            NotAvailableTracks = notAvailableTracks;
        }

        private void CompletionForm_Load(object sender, EventArgs e)
        {
            var builder = new StringBuilder();

            if (Completion == "season")
            {

                builder.AppendLine("Season created successfully!");
                builder.AppendLine("");

                if (NotAvailableTracks.Any())
                {
                    builder.AppendLine("----------------------------------------------------------------------------");
                    builder.AppendLine("");
                    builder.AppendLine("The following tracks were not included in the season as they are not available for AI racing:");
                    builder.AppendLine("");

                    foreach (var track in NotAvailableTracks)
                    {
                        builder.AppendLine($"-{track.ToString()}");
                    }

                    builder.AppendLine("");
                    builder.AppendLine("");
                    NotAvailableTracks.Clear();
                }
            }
            else
            {
                builder.AppendLine("Roster created successfully!");
                builder.AppendLine("");
            }

            creationLabel.Text = builder.ToString();

            var w = this.Width - okButton.Width - 10;
            var h = this.Height - okButton.Height - 10;
            okButton.Location = new Point(w, h);

            CenterToParent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void CompletionForm_MoustDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void creationLabel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
