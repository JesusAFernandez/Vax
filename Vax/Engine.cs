using Firebase.Database;
using GMap.NET.MapProviders;
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
        public Engine()
        {
            InitializeComponent();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            map.MapProvider = GMapProviders.GoogleMap;
            map.Zoom = 10;
            map.MaxZoom = 100;
            map.MinZoom = 1;

            getPopulationAsync(); 
            getAccessAsync();
            //call huristic 
            //getAccess();
            //sendKAsync();
            //plot points on map and start graph 
            //user will see points then hit start


        }
        private async Task getPopulationAsync()
        {
            var client = new FirebaseClient("https://cpts323battle.firebaseio.com/");
           // HttpClient httpclient = new HttpClient();
            //string selectedkey = null, responseString, companyId;
           // FormUrlEncodedContent content;
           // HttpResponseMessage response;
            //******************** Get initial list of Prospect ***********************//
        
            var Population1 = await client
               .Child("population")//Prospect list
               .OnceSingleAsync<Vax>();
            Console.WriteLine(Population1.K); // we need to save this K

            var PopulationSet = await client
               .Child("population/individuals")//Prospect list
               .OnceAsync<Individual>();

            foreach (var person in PopulationSet)
            {
                Console.WriteLine($"OA1:{person.Key}:->{person.Object.lat}");
                foreach (var ne in person.Object.neighbor)
                {
                    Console.WriteLine($"  neig:{ne.id}"); // we need to save these 
                }
            }
        }
        async Task getAccessAsync()
        {
             HttpClient httpclient = new HttpClient();
             string selectedkey = null, responseString, companyId;
             FormUrlEncodedContent content;
             HttpResponseMessage response;
            var company = new Company
            {
                companyName = "WSU VANS",
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
        }
        async Task sendKAsync()
        {

            HttpClient httpclient = new HttpClient();
            string selectedkey = null, responseString, companyId;
            FormUrlEncodedContent content;
            HttpResponseMessage response;
            var dictionary = new Dictionary<string, string>
            {
               { "K","array"  },
               { "companyId", "20"} // we do need to change this 
            };
            content = new FormUrlEncodedContent(dictionary);
            response = await httpclient.PostAsync("https://us-central1-cpts323battle.cloudfunctions.net/sendK",
content);
            responseString = await response.Content.ReadAsStringAsync();
            Response data = Newtonsoft.Json.JsonConvert.DeserializeObject<Response>(responseString);
            Console.WriteLine(data.message);

            var stop = Console.ReadLine();
        }
    }
}
