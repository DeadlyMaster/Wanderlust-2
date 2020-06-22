using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wanderlust.Services.API.Models
{
    public class LandmarkRepository : ILandmarkRepository
    {
        private readonly ApiDbContext _apiDbContext;
        //private List<Landmark> _landmarks;
        public LandmarkRepository(ApiDbContext apiDbContext)
        {
            //InitializeLandmarks();
            _apiDbContext = apiDbContext;
        }

        //private void InitializeLandmarks()
        //{
        //    if (_landmarks == null)
        //    {
        //        _landmarks = new List<Landmark>
        //        {
        //            new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E601}"), LandmarkName = "Sydney Opera House", LandmarkDescription = "The Sydney Opera House is one of Australia's top tourist attractions and one of the world's most recognizable buildings. It's also known as one of the busiest performing arts venues in the world. To get to know the famous Opera House, take The Sydney Opera House Tour, a guided, hourlong journey that costs $40 (about $29 USD). Several additional guided options are also available, including a comprehensive backstage tour of the venue. Afterward, stay for drinks or dinner harborside at one of the venue's outdoor restaurants.", ImageUrl="https://www.usnews.com/dims4/USNEWS/3aa5ddb/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2Fc2%2Fb4%2Fe67fc0a24e499fe7b7f11bba0fb9%2F3-sydney-opera-house-submitted-masaru-kitano-snak-productions-tourism-australia-4.jpg" },
        //            new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E602}"), LandmarkName = "The Eiffel Tower", LandmarkDescription = "The Eiffel Tower is one of the most visited monuments in the world (especially in June, July and August), so you'll want to plan a visit during the shoulder seasons (spring or fall) to avoid crowds. Splurge on a ticket to the top of this iconic structure for unparalleled views of Paris. Afterward, dine at 58 Tour Eiffel or famed Le Jules Verne. After sunset, you'll see why this must-visit destination in France is known as the City of Light: The Eiffel Tower puts on its own dazzling light show every hour on the hour after dark.", ImageUrl="https://www.usnews.com/dims4/USNEWS/26485ec/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F42%2F18%2Ffea6243e41c7bbe827610a48028c%2F4-eiffel-tower-getty.jpg"},
        //            new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E603}"), LandmarkName = "Taj Mahal", LandmarkDescription = "The Taj Mahal is a tribute to Mughal Emperor Shah Jahan's favorite wife. This opulent structure, completed in 1648, has been recognized as the best example of Indo-Islamic architecture by UNESCO. Located in the city of Agra, the Taj Mahal is accessible via an hour plane ride or a three-hour train ride from the capital city of New Delhi. Considering the large crowds this world-renowned site draws, it's best to plan a visit in the morning. Plus, an early morning visit means you can catch the sunrise, which will no doubt cast an enchanting glow upon the white marble structure.", ImageUrl="https://www.usnews.com/dims4/USNEWS/126b6c9/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F64%2F19%2Fd8122751475db89d12259ae2876a%2F5-taj-mahal-getty.jpg"},
        //            new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E604}"), LandmarkName = "Burj Khalifa", LandmarkDescription = "Burj Khalifa is the tallest building and tallest free-standing structure in the world, measuring more than 2,716 feet high. This impressive architectural feat has more than 160 stories to its name, affording unforgettable views of Dubai below. Visitors will want to reserve tickets ahead of time for privileged access to the world's highest observation deck, At The Top, Burj Khalifa SKY. Then, head to the world's highest lounge, The Lounge, Burj Khalifa, for afternoon tea or Champagne at sunset.", ImageUrl="https://www.usnews.com/dims4/USNEWS/12e9f5c/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F05%2F1e%2F64ddf58e4c1abb699bfcc2dfa741%2F6-burj-khalifa-getty.jpg"},
        //            new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E605}"), LandmarkName = "Machu Picchu", LandmarkDescription = "The ancient Incan city of Machu Picchu sits perched on a mountaintop in the Andes Mountains at 8,047 feet above sea level. Before you visit this incredible site, it's best to spend the evening in nearby Aguas Calientes to adjust to the region's altitude. Then, take an early morning bus or hike to the citadel. It's important to know that there is an entrance fee to visit, so you'll need to book tickets well in advance of your trip. There are also additional fees to climb to Huayna Picchu and Machu Picchu peaks, where you'll find more spectacular views.", ImageUrl="https://www.usnews.com/dims4/USNEWS/591e02e/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F06%2F6a%2F135e99124193a602156a3a5094a6%2F7-machu-picchu-getty.jpg"},
        //            //new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E606}"), LandmarkName = "The Great Wall of China", LandmarkDescription = "Built more than 2,300 years ago, The Great Wall of China is the longest wall in the world, measuring 13,170 miles in length. The most visited area near Beijing is the Mutianyu section, the longest and one of the more restored parts of the wall. If you're looking for more of an adventure, travel to Jiankou, the most treacherous section. The unrestored Jiankou offers a challenging hike with steep inclines throughout. May and June are the best months to visit for ideal weather and stunning scenery.", ImageUrl="https://www.usnews.com/dims4/USNEWS/5ff86e9/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F5d%2Fab%2F52700225463ba0da0ada7fb24f1a%2F8-great-wall-getty.jpg"},
        //            //new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E607}"), LandmarkName = "Mount Rushmore National Memorial", LandmarkDescription = "This iconic American landmark overlooks the picturesque Black Hills of South Dakota. For the best photo opportunity, arrive at sunrise when the golden light illuminates the faces of the four U.S. presidents. And if you're planning on traveling here during the warmer months, don't miss the nightly lighting ceremony, which occurs from May to September. This outdoor event features a video about the history and the making of the monument; it also pays tribute to veterans as the sculpture is illuminated.", ImageUrl="https://www.usnews.com/dims4/USNEWS/269e567/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F40%2F0f%2F8a0161cd4d4bad5943204c182549%2F9-mount-rushmore-getty.jpg"},
        //            //new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E608}"), LandmarkName = "Mont Saint-Michel", LandmarkDescription = "This medieval Benedictine monastery is one of the most spectacular sights in Europe. Dating back to the eighth century, Mont Saint-Michel sits atop an island in the Bay of Saint-Michel at the convergence of Brittany and Normandy. Visitors can reach the abbey on foot, by bus or maringote (horse-drawn carriage). For a treat, stay on the island and enjoy a world-renowned omelet at La Mère Poulard or Normandy specialties, such as crepes and galettes", ImageUrl="https://www.usnews.com/dims4/USNEWS/a883f71/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2Fb0%2F84%2F575e32d74bf69772ff08c3a988e3%2F10-mont-saint-michel-getty.jpg"},
        //            //new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E609}"), LandmarkName = "St. Basil's Cathedral", LandmarkDescription = "St. Basil's Cathedral is prominently located in the center of Moscow's Red Square. The cathedral was built between 1555 and 1561 under Ivan IV, or Ivan the Terrible, and is a symbol of the Russian Orthodox Church. Take a tour inside the cathedral, then visit the top attractions at the Kremlin and Lenin's Mausoleum, also on Red Square. Summers are short and incredibly busy, so you may want to consider planning your tour of Moscow for the fall or, if you can handle the cold, the winter when snow blankets the city.", ImageUrl="https://www.usnews.com/dims4/USNEWS/d828722/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F82%2Fb0%2Fe46946254f9d9da0b4dc318aa014%2F11-moscow-getty.jpg"},
        //            //new Landmark { LandmarkId = Guid.Parse("{70822596-265D-49E3-8CCC-CD996093E610}"), LandmarkName = "The Acropolis", LandmarkDescription = "Climb to the top of this rocky hill in Athens to visit one of the most impressive remains of the ancient Greek civilization, The Acropolis. Then, wander the ruins to see the world-famous Parthenon temple. Afterward, visit the Acropolis Museum, which is filled with priceless antiquities and statues unearthed from what is known as the Sacred Rock. Plan your visit in the shoulder seasons of spring or fall for cooler weather and fewer tourists.", ImageUrl="https://www.usnews.com/dims4/USNEWS/a238721/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F15%2F85%2F2c4473ac46229e5ae1b127e9d0c9%2F12-acropolis-getty.jpg"},
        //        };
        //    }
        //}

        public async Task<IEnumerable<Landmark>> GetLandmarks()
        {
            return await Task.Factory.StartNew(() => { return _apiDbContext.Landmarks; });
            //return null;
        }

        public async Task<IEnumerable<Landmark>> getMustSeeLandmarks()
        {
            return await Task.Factory.StartNew(() => { return _apiDbContext.Landmarks.Where(l => l.MustSee).OrderBy(l => l.LandmarkName); });
        }

        public async Task<Landmark> GetLandmark(int id)
        {
            return await Task.Factory.StartNew(() => { return _apiDbContext.Landmarks.Where(l => l.LandmarkId == id).FirstOrDefault(); });
        }

        public async Task<Landmark> AddLandmark(Landmark landmark)
        {
            return await Task.Factory.StartNew(() =>
            {
                //landmark.LandmarkId = Guid.NewGuid(); // not neeeded, id is int and primary key
                // random code image ;) untill adding an image is possible 
                // this should be auto-generated
                landmark.LandmarkId = 0;
                    if (landmark.ImageUrl == "")
                        landmark.ImageUrl = "https://www.usnews.com/dims4/USNEWS/26485ec/2147483647/resize/1200x%3E/quality/85/?url=http%3A%2F%2Fmedia.beam.usnews.com%2F42%2F18%2Ffea6243e41c7bbe827610a48028c%2F4-eiffel-tower-getty.jpg";

                _apiDbContext.Landmarks.Add(landmark);
                _apiDbContext.SaveChanges(); // maybe it works
                return landmark;
            });
        }

        public async Task UpdateLandmark(Landmark landmark)
        {
            await Task.Factory.StartNew(() =>
            {
                var landmarkToUpdate = _apiDbContext.Landmarks.Where(l => l.LandmarkId == landmark.LandmarkId).FirstOrDefault();
                landmarkToUpdate.LandmarkName = landmark.LandmarkName;
                landmarkToUpdate.LandmarkDescription = landmark.LandmarkDescription;

                _apiDbContext.Landmarks.Update(landmark);
                _apiDbContext.SaveChanges();
            });
        }

        public async Task DeleteLandmark(int id)
        {
            await Task.Factory.StartNew(() =>
            {
                var landmarkToDelete = _apiDbContext.Landmarks.Where(l => l.LandmarkId == id).FirstOrDefault();
                _apiDbContext.Landmarks.Remove(landmarkToDelete);
                _apiDbContext.SaveChanges();
            });
        }
    }
}
