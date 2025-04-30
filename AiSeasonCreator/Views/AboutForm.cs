using AiSeasonCreator.Presenters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AiSeasonCreator.Views
{
    public partial class AboutForm : Form, IAboutView
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            ViewLoaded?.Invoke(this, e);
        }

        private void forumLinkLabel_Click(object sender, EventArgs e)
        {
            ForumLinkClicked.Invoke(this, e);
        }

        public event EventHandler ViewLoaded;
        public event EventHandler ForumLinkClicked;

        public IAboutPresenter Presenter { get; set; }
        public string GeneralAboutSection
        {
            get { return generalAboutLabel.Text; }
            set { generalAboutLabel.Text = value; }
        }
        public string SeasonAboutSection
        {
            get { return seasonAboutLabel.Text; }
            set { seasonAboutLabel.Text = value; }
        }
        public string RosterAboutSection
        {
            get { return rosterAboutLabel.Text; }
            set { rosterAboutLabel.Text = value; }
        }
    }
}
