using System.Threading.Tasks;

namespace TumblrClient.Core.Infrastructure
{
    public interface IAppDialogs
    {
        Task ShowAlert(string message);
        void ShowToast(string message);
        void ShowLoading(string text = "");
        void HideLoading();
    }
}
