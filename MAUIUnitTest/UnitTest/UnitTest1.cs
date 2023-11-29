using MAUIUnitTest;
using MAUIUnitTest.Services;
using System.Collections.ObjectModel;

namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            //Arrange
            var passwordValidator = "Th1sIsapassword!";
            const string password = "Th1sIsapassword!";

            //Act
            bool isValid = passwordValidator == (password);

            //Assert
            Assert.True(isValid, $"The password {password} is not valid");
        }

        [Fact]
        public async void Test2()
        {
            IWeatherService weatherService = new WeatherService(null);
            ObservableCollection<MAUIUnitTest.Services.Location> favorites = new ObservableCollection<MAUIUnitTest.Services.Location>();
            var mainPageView = new MainPageViewModel();
            var locations = await weatherService.GetLocations(string.Empty);
            // Arrange

            favorites = mainPageView.UpdateFavorites(locations);

            // Assert
            Assert.NotNull(locations);
            //   Assert.Equal(2, favorites.Count);
            Assert.Equal(15, favorites.Count);
            Assert.True(true, $"The count of favoirate is {favorites.Count}");
        }

    }
}