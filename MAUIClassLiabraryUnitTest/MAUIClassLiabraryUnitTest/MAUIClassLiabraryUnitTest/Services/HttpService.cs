using System;
namespace MAUIUnitTest.Services
{
	public class HttpService : IHttpService
    {
        public async Task CallService(string Url)
        {
            //to something
            await Task.Delay(200);
            return;
        }
    }
}

