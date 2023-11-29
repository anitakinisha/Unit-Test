using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MAUIUnitTest.Services;
using Location = MAUIUnitTest.Services.Location;

namespace MAUIUnitTest
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
       // WeatherService weatherService = new WeatherService(null);
        public string Title;
        

        private ObservableCollection<Location> favorites;
        

        private readonly IHttpService httpService;
        private readonly IWeatherService weatherService;

        public MainPageViewModel( IHttpService httpService,IWeatherService weatherService)
        {
            Title = "Main Page";
            this.httpService = httpService;
            this.weatherService = weatherService;
        }

        public MainPageViewModel()
        {
            Title = "Main Page";
           
        }

        public ObservableCollection<Location> Favorites
        {
            get
            {
                return favorites;
            }

            set
            {
                favorites = value;
                OnPropertyChanged();
            }
        }

        public async void Fetch()
        {
            var locations = await weatherService.GetLocations(string.Empty);

            UpdateFavorites(locations);

            OnPropertyChanged(nameof(Favorites));

        }

        public ObservableCollection<Location> UpdateFavorites(IEnumerable<Location> locations)
        {
            Favorites = new ObservableCollection<Location>();
            for (int i = locations.Count() - 1; i >= 0; i--)
            {
                Favorites.Add(locations.ElementAt(i));
            }
            return Favorites;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

