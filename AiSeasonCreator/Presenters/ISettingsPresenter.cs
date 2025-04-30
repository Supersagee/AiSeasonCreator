
namespace AiSeasonCreator.Presenters
{
    public interface ISettingsPresenter
    {
        void OnViewLoaded(object sender, EventArgs e);
        void OnSeasonFolderClicked(object sender, EventArgs e);
        void OnRosterFolderClicked(object sender, EventArgs e);
    }
}
