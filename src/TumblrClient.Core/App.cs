using System;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Newtonsoft.Json;
using Refit;
using TumblrClient.Core.Infrastructure;
using TumblrClient.Core.ViewModels.Main;

namespace TumblrClient.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            var contentSerializer = new NewtonsoftJsonContentSerializer();
            var refitSettings = new RefitSettings(contentSerializer);
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://api.tumblr.com/v2"),
            };

            Mvx.IoCProvider.RegisterSingleton(() => UserDialogs.Instance);
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IAppDialogs, AppDialogs>();
            Mvx.IoCProvider.RegisterSingleton(() => RestService.For<IBlogAPI>(httpClient, refitSettings));
            Mvx.IoCProvider.LazyConstructAndRegisterSingleton<IBlogService, BlogService>();

            RegisterAppStart<MainViewModel>();
        }

        private class DebugingDelegatingHandler : DelegatingHandler
        {
            public DebugingDelegatingHandler(HttpClientHandler innerHandler)
            {
                InnerHandler = innerHandler;
            }

            protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
            {
                var id = Guid.NewGuid().ToString();
                var msg = $"[{id} -   Request]";

                Debug.WriteLine($"{msg}========Start==========");
                Debug.WriteLine($"{msg} {request.Method} {request.RequestUri.PathAndQuery} {request.RequestUri.Scheme}/{request.Version}");
                Debug.WriteLine($"{msg} Host: {request.RequestUri.Scheme}://{request.RequestUri.Host}");

                foreach (var header in request.Headers)
                {
                    Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
                }

                if (request.Content != null)
                {
                    foreach (var header in request.Content.Headers)
                    {
                        Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
                    }

                    var result = await request.Content.ReadAsStringAsync();

                    Debug.WriteLine($"{msg} Content:");
                    Debug.WriteLine($"{msg} {string.Join("", result.Cast<char>().Take(255))}...");
                }

                var start = DateTime.Now;
                var response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
                var end = DateTime.Now;

                Debug.WriteLine($"{msg} Duration: {end - start}");
                Debug.WriteLine($"{msg}==========End==========");

                msg = $"[{id} - Response]";

                Debug.WriteLine($"{msg}=========Start=========");
                Debug.WriteLine($"{msg} {request.RequestUri.Scheme.ToUpper()}/{response.Version} {(int)response.StatusCode} {response.ReasonPhrase}");

                foreach (var header in response.Headers)
                {
                    Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
                }

                foreach (var header in response.Content.Headers)
                {
                    Debug.WriteLine($"{msg} {header.Key}: {string.Join(", ", header.Value)}");
                }

                if (response.Content is StringContent)
                {
                    start = DateTime.Now;
                    var result = await response.Content.ReadAsStringAsync();
                    end = DateTime.Now;

                    Debug.WriteLine($"{msg} Content:");
                    Debug.WriteLine($"{msg} {string.Join("", result.Cast<char>().Take(255))}...");
                    Debug.WriteLine($"{msg} Duration: {end - start}");
                }

                Debug.WriteLine($"{msg}==========End==========");

                return response;
            }
        }
    }
}
