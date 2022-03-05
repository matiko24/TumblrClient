using System.Threading.Tasks;
using Acr.UserDialogs;

namespace TumblrClient.Core.Infrastructure
{
    public class AppDialogs : IAppDialogs
    {
        public async Task ShowAlert(string message)
        {
            await UserDialogs.Instance.AlertAsync(message);
        }

        public void ShowToast(string message)
        {
            var toastConfig = new ToastConfig(message);

            UserDialogs.Instance.Toast(toastConfig);
        }

        public void ShowLoading(string text = "")
        {
            UserDialogs.Instance.ShowLoading(text, MaskType.Clear);
        }

        public void HideLoading()
        {
            UserDialogs.Instance.HideLoading();
        }
    }
}
