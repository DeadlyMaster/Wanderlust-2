using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Wanderlust.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TextToSpeechPage : ContentPage
    {
        public TextToSpeechPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await TextToSpeech.SpeakAsync(Entry_Text.Text, new SpeechOptions
            {
                Volume = (float)slidervolume.Value
            });

            await SpeakNow();

            await SpeakNowDefaultSettings();
        }

        public async Task SpeakNow()
        {
            var locales = await TextToSpeech.GetLocalesAsync();

            // Grab the first locale
            var locale = locales.FirstOrDefault();

            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f,
                Locale = locale
            };

            await TextToSpeech.SpeakAsync("Hello World", settings);
        }
        CancellationTokenSource cts;
        public async Task SpeakNowDefaultSettings()
        {
            cts = new CancellationTokenSource();
            await TextToSpeech.SpeakAsync("Hello World", cancelToken: cts.Token);

            // This method will block until utterance finishes.
            CancelSpeech(); // not working as expected?
        }

        // Cancel speech if a cancellation token exists & hasn't been already requested.
        public void CancelSpeech()
        {
            if (cts?.IsCancellationRequested ?? true)
                return;

            cts.Cancel();
        }

    }
}