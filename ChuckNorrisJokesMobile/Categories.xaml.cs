using ChuckNorrisJokesLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisJokesMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Categories : ContentPage
    {

        public List<CategoriesClass> Category { get; set; }
        public Categories()
        {
            InitializeComponent();


        }

        protected override async void OnAppearing()
        {
            JokeGenerator jokeCategory = new JokeGenerator();

            var categoryJoke = await jokeCategory.GetCategories();



            Category = new List<CategoriesClass>();

            for (int index = 0; index < categoryJoke.Length; index++)
            {
                Category.Add(new CategoriesClass
                {
                    Name = categoryJoke[0],


                });
                Category.Add(new CategoriesClass
                {
                    Name = categoryJoke[1],


                });
                Category.Add(new CategoriesClass
                {
                    Name = categoryJoke[2],


                });
                Category.Add(new CategoriesClass
                {
                    Name = categoryJoke[3],


                });
                Category.Add(new CategoriesClass
                {
                    Name = categoryJoke[4],


                });

                BindingContext = this;
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            HttpClient client = new HttpClient();
            JokeGenerator j = new JokeGenerator();
            string[] categoryArray = await j.GetCategories();

                
                string x = await client.GetStringAsync($"https://api.chucknorris.io/jokes/random?category={categoryArray[e.SelectedItemIndex]}");

                var category = JsonConvert.DeserializeObject<Joke>(x);

                await DisplayAlert(categoryArray[e.SelectedItemIndex], category.value, "cancel");
           
        }

        
    }
}
