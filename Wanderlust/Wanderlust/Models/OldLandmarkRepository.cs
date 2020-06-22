using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Wanderlust.Services;
using Wanderlust.Utility;
using Xamarin.Forms;
//using System.Text.Json.Serialization; not working...

namespace Wanderlust.Models
{
    public class OldLandmarkRepository : ILandmarkRepository
    {

        private readonly HttpClient _httpClient;

        //local
        //private string baseUrl = Device.RuntimePlatform == Device.Android ? "https://10.0.2.2:5001/api/landmarkrepository" : "https://localhost:5001/api/piestock";
        // Android preconfigured IP address to allow us to connect to a local API
        private const string baseUrl = "https://10.0.2.2:5001/api/landmarks";


        public OldLandmarkRepository()
        {
            _httpClient = new HttpClient(DependencyService.Get<IHttpClientHandlerService>().GetInsecureHandler());
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task AddLandmarkAsync(Landmark landmark)
        {
            var url = new Uri(ApiConstants.BaseApiUrl);

            var json = JsonConvert.SerializeObject(landmark);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PostAsync(url, content);
        }

        public async Task DeleteLandmarkAsync(int id)
        {
            var url = new Uri($"{ApiConstants.BaseApiUrl}/{id}");

            await _httpClient.DeleteAsync(url);
        }

        public async Task<Landmark> GetLandmarkAsync(int id)
        {
            var url = new Uri($"{ApiConstants.BaseApiUrl}/{id}");

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Landmark>(content);
            }
            return null;
        }

        public async Task<List<Landmark>> GetLandmarksAsync()
        {
            var url = new Uri(ApiConstants.LandmarkApiUrl);

            HttpResponseMessage response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                List<Landmark> c = JsonConvert.DeserializeObject<List<Landmark>>(content); ;
                return JsonConvert.DeserializeObject<List<Landmark>>(content);
            }
            return null;
        }

        public async Task UpdateLandmarkAsync(Landmark landmark)
        {
            var url = new Uri(ApiConstants.BaseApiUrl);

            var json = JsonConvert.SerializeObject(landmark);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            await _httpClient.PutAsync(url, content);
        }

        public Task<List<Landmark>> GetMustSeeLandmarksAsync()
        {
            throw new NotImplementedException();
        }








        //static LandmarkRepository()
        //{
        //    if (Landmarks == null)
        //    {
        //        Landmarks = new List<Landmark>
        //        {
        //            new Landmark
        //            {
        //                LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E601}"),
        //                LandmarkName = "Strawberry Pie",
        //                LandmarkDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
        //                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/strawberrypiesmall.jpg"
        //            },
        //            new Landmark
        //            {
        //                LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E602}"),
        //                LandmarkName = "Cheese cake",
        //                LandmarkDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
        //                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cheesecakesmall.jpg"
        //            },
        //            new Landmark
        //            {
        //                LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E603}"),
        //                LandmarkName = "Rhubarb Pie",
        //                LandmarkDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
        //                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/rhubarbpiesmall.jpg"
        //            },
        //            new Landmark
        //            {
        //                LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E604}"),
        //                LandmarkName = "Pumpkin Pie",
        //                LandmarkDescription = "Icing carrot cake jelly-o cheesecake. Sweet roll marzipan marshmallow toffee brownie brownie candy tootsie roll. Chocolate cake gingerbread tootsie roll oat cake pie chocolate bar cookie dragée brownie. Lollipop cotton candy cake bear claw oat cake. Dragée candy canes dessert tart. Marzipan dragée gummies lollipop jujubes chocolate bar candy canes. Icing gingerbread chupa chups cotton candy cookie sweet icing bonbon gummies. Gummies lollipop brownie biscuit danish chocolate cake. Danish powder cookie macaroon chocolate donut tart. Carrot cake dragée croissant lemon drops liquorice lemon drops cookie lollipop toffee. Carrot cake carrot cake liquorice sugar plum topping bonbon pie muffin jujubes. Jelly pastry wafer tart caramels bear claw. Tiramisu tart pie cake danish lemon drops. Brownie cupcake dragée gummies.",
        //                ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/pumpkinpiesmall.jpg"
        //            }
        //        };
        //    }
        //}

        //public static List<Landmark> Landmarks { get; set; }

        //public static void AddLandmark(Landmark landmark)
        //{
        //    landmark.LandmarkId = Guid.NewGuid();
        //    landmark.ImageUrl = "https://gillcleerenpluralsight.blob.core.windows.net/files/cherrypiesmall.jpg";
        //    Landmarks.Add(landmark);
        //}

        //public static void UpdateLandmark(Landmark landmark)
        //{
        //    var oldLandmark = Landmarks.Where(p => p.LandmarkId == landmark.LandmarkId).FirstOrDefault();
        //    oldLandmark.LandmarkName = landmark.LandmarkName;
        //    oldLandmark.LandmarkDescription = landmark.LandmarkDescription;
        //}
    }
}
