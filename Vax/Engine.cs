using Firebase.Database;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vax
{
    public partial class Engine : Form
    {
        List<PointLatLng> _points;
        public Engine()
        {
            InitializeComponent();
            map.MapProvider = GMapProviders.GoogleMap;
            map.Zoom = 10;
            map.MaxZoom = 100;
            map.MinZoom = 1;
            _points = new List<PointLatLng>();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
          /*  map.MapProvider = GMapProviders.GoogleMap;
            map.Zoom = 10;
            map.MaxZoom = 100;
            map.MinZoom = 1;*/

            getPopulationAsync();
            //getAccessAsync();
            //call huristic 
            //getAccess();
            //sendKAsync();
            //plot points on map and start graph 
            //user will see points then hit start


        }
        private async void getPopulationAsync()
        {
            var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
            //******************** Get initial list of Prospect ***********************//

            var PopulationSet = await client
               .Child("population")//Prospect list
               .OnceSingleAsync<Vax>();
            Console.WriteLine(PopulationSet.K); // we need to save this K
            
        

            foreach (var population in PopulationSet.individuals)
            {
                Console.WriteLine($"{ population.lat } {population.lng}" );
               plotPoints(population.lat, population.lng*-1);
                _points.Add(new PointLatLng(population.lat, population.lng*-1));
                /* foreach(var individual in population.neighbor)
                 {
                     Console.WriteLine($"{individual.id}");
                 }*/
           
            }
            //map.Refresh();
        }
       
        private void plotPoints(double lat, double lng)
        {
           
            PointLatLng point = new PointLatLng(lat, lng);
            map.Position = new PointLatLng(lat, lng);
            map.Zoom = 4;

            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.lightblue);
            GMapOverlay markers = new GMapOverlay();
            markers.Markers.Add(marker);
            map.Overlays.Add(markers);
            var poly = new GMapPolygon(_points, "MyArea")
            {
                Stroke = new Pen(Color.Black, 2)
            };
            GMapOverlay polygons = new GMapOverlay("polygons");
            polygons.Polygons.Add(poly);
            map.Overlays.Add(polygons);
            map.Refresh();
            
        }
        async Task getAccessAsync()
        {
            HttpClient httpclient = new HttpClient();
            string selectedkey = null, responseString, companyId;
            FormUrlEncodedContent content;
            HttpResponseMessage response;
            var company = new Company
            {
                companyName = "Vaxxers",
                status = "active"
            };
            var dictionary = new Dictionary<string, string>
            {
                { "companyName",company.companyName  },
                { "status",company.status}
            };

            content = new FormUrlEncodedContent(dictionary);
            response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/reportCompany", content);
            responseString = await response.Content.ReadAsStringAsync();
            Response data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
            //Response message
            Console.WriteLine(data.message);
            Console.WriteLine(data.companyId);
            companyId = data.companyId;


            dictionary = new Dictionary<string, string>
            {
                { "K","array"  },
                { "companyId", companyId} // we do need to change this 
            };
            content = new FormUrlEncodedContent(dictionary);
            response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/sendK", content);
            responseString = await response.Content.ReadAsStringAsync();
            data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
            Console.WriteLine(data.message);

            var stop = Console.ReadLine();
        }
    }
}
