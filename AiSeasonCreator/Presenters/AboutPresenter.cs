using AiSeasonCreator.Services;
using AiSeasonCreator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiSeasonCreator.Presenters
{
    public class AboutPresenter : IAboutPresenter
    {
        private IAboutView _view;
        private IAboutService _aboutService;
        public AboutPresenter(IAboutView view, IAboutService aboutService)
        {
            _view = view;
            _aboutService = aboutService;

            _view.ViewLoaded += OnViewLoaded;
            _view.ForumLinkClicked += OnForumLinkClicked;
        }
        
        public void OnViewLoaded(object sender, EventArgs e)
        {
            _view.AboutSection = _aboutService.GetAboutSection();
        }

        public void OnForumLinkClicked(object sender, EventArgs e)
        {
            _aboutService.GoToForum();
        }
    }
}
