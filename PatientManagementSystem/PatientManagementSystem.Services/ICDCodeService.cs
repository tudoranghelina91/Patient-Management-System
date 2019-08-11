using PatientManagementSystem.Domain;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace PatientManagementSystem.Services
{
    class ICDCodeService : IICDCodeService
    {
        public string GetByICDCode(string icdCode)
        {
            string postURL = string.Format("http://icd10api.com/?code={0}&desc=short&r=json", icdCode);
            WebRequest request = WebRequest.Create(postURL);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();
            string jsonText;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                jsonText = sr.ReadToEnd();
            }
            return jsonText;
        }

        public Diagnosis Deserialize(string diagnosis)
        {
            ICDCode icdCode = JsonConvert.DeserializeObject<ICDCode>(diagnosis);
            return new Diagnosis
            {
                Name = icdCode.Name,
                Inclusions = icdCode.Inclusions,
                ExcludesOne = icdCode.ExcludesOne,
                ExcludesTwo = icdCode.ExcludesTwo,
                Description = icdCode.Description,
                Type = icdCode.Type
            };
        }

        public string GetByName(string icdName)
        {
            string postURL = string.Format("http://icd10api.com/?code={0}&desc=short&r=json", icdName);
            WebRequest request = WebRequest.Create(postURL);
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";

            var response = (HttpWebResponse)request.GetResponse();
            string jsonText;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                jsonText = sr.ReadToEnd();
            }
            return jsonText;
        }
    }
}
