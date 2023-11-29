using System;
namespace MAUIUnitTest.Services
{
    public interface IHttpService
    {
        Task CallService(string Url);
    }
}

