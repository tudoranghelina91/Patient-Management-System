using PatientManagementSystem.Domain;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.IdentityModel.Claims;

namespace PatientManagementSystem.Services
{
    class ICDCodeService : IICDCodeService
    {
        const string clientId = "3ac58862-d3ec-48b8-b12f-1ca2aa85b7df_3694a49d-7621-4c6c-99c8-4a0077b6f5d1";
        const string clientSecret = " b9DejBuEXYoUeLa0zqz4Pjhzd2GJxrdaKRXStDNOUQ0=";

        public Diagnosis Deserialize(string ICDCode)
        {
            throw new System.NotImplementedException();
        }

        public string GetByICDCode(string ICDCode)
        {
            throw new System.NotImplementedException();
        }

        public string GetByName(string ICDName)
        {
            throw new System.NotImplementedException();
        }

        public async Task GetByNameAsync(string clientId, string clientSecret, string name)
        {
            var client = new HttpClient();
            var disco = await client.GetByteArrayAsync
        }
    }
}
