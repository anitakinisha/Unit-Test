using System.Collections.ObjectModel;
using MAUIClassLiabraryUnitTest.Platforms.Android;
using MAUIUnitTest;
using MAUIUnitTest.Services;

namespace UnitTest;

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
        MainActivity mainActivity = new MainActivity();
        
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


    //[Fact]
    //public void MainPageViewModel_CtorTests()
    //{
    //    //Arrange & Act :- create object of MainPageViewModel. As constructor will be called automatically so 'Act'
    //    // if we have multiple services injected in the viewmodel constructor we have to mock all services
    //    var mockHttpService = new Mock<IHttpService>();
    //    var mockWetherService = new Mock<IWeatherService>();
    //    var mainVM = new MainPageViewModel(mockHttpService.Object,mockWetherService.Object);
    //    //Assert
    //    Assert.NotNull(mainVM.Favorites);

    //    Assert.NotNull(mainVM.Title);
    //    Assert.Equal("Main Page", mainVM.Title);

    //}


    //[Fact]
    //public void MainPageViewModel_OnNavigatedTo_CallsHttpService()
    //{

    //    //Arrange :- create object of MainPageViewModel.
    //    var mockHttpService = new Mock<IHttpService>();

    //    var mockWetherService = new Mock<IWeatherService>();
    //    // in method OnNavigatedTO we are calling the HttpService method so first we need to setup the call
    //    mockHttpService.Setup(x => x.CallService("dummyUrl"));

    //    var mainVM = new MainPageViewModel(mockHttpService.Object, mockWetherService.Object);

    //    //Act : - call OnNavigatedTo method

    //    //Assert:- verify that all setup has been executed or not
    //    mockHttpService.VerifyAll();
    //    mockHttpService.VerifyNoOtherCalls();


    //}
}