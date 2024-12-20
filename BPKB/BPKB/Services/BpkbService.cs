using BPKB.Data;
using BPKB.Models;
using Microsoft.AspNetCore.WebUtilities;
using System.Xml.Linq;

namespace BPKB.Services
{
    public class BpkbService
    {
        private readonly HttpClient _httpClient;
        public BpkbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BpkbModel>> GetBPKB()
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                IEnumerable<BpkbModel> bpkbs = await _httpClient.GetFromJsonAsync<IEnumerable<BpkbModel>>("https://localhost:7175/api/BPKB/GetBPKB");

                return bpkbs;
            }
            catch (Exception ex)
            {
                return new List<BpkbModel>();
            }
        }
        public async Task<EditModel> GetBpkbByAgreementNumber(string agreementNumber)
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                string baseUrl = "https://localhost:7175/api/BPKB/GetBpkbByAgreementNumber";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, "AgreementNumber", agreementNumber);
                EditModel bpkb = await _httpClient.GetFromJsonAsync<EditModel>(urlWithQuery);
                //IEnumerable<BpkbModel> bpkbs = await _httpClient.GetFromJsonAsync<IEnumerable<BpkbModel>>("");

                return bpkb;
            }
            catch (Exception ex)
            {
                return new EditModel();
            }
        }
        public async Task<IEnumerable<StorageLocationModel>> GetLocation()
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                IEnumerable<StorageLocationModel> locations = await _httpClient.GetFromJsonAsync<IEnumerable<StorageLocationModel>>("https://localhost:7175/api/BPKB/GetLocation");

                return locations;
            }
            catch (Exception ex)
            {
                return new List<StorageLocationModel>();
            }
        }
        public async Task<StorageLocationModel> GetLocationByName(string name)
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                string baseUrl = "https://localhost:7175/api/BPKB/GetLocationByName";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, "LocationName", name);
                StorageLocationModel locations = await _httpClient.GetFromJsonAsync<StorageLocationModel>(urlWithQuery);

                return locations;
            }
            catch (Exception ex)
            {
                return new StorageLocationModel();
            }
        }

        public async Task<UserModel> GetUser(UserModel userData)
        {
            try
            {
                _httpClient.Timeout = TimeSpan.FromSeconds(30);
                var queryParams = new Dictionary<string, string>
                {
                    { "Username", userData.Username },
                    { "Password", userData.Password }                   
                };
                string baseUrl = "https://localhost:7175/api/BPKB/Login";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, queryParams);
                UserModel user = await _httpClient.GetFromJsonAsync<UserModel>(urlWithQuery);

                return user;
            }
            catch (Exception ex)
            {
                return new UserModel();
            }
        }
        public async Task SubmitBPKB(BpkbModel data)
        {
            try
            {
                
                var queryParams = new Dictionary<string, string>
                {
                    { "AgreementNumber", data.AgreementNumber },
                    { "BpkbNo", data.BpkbNo },
                    { "BranchId", data.BranchId },
                    { "BpkbDate", data.BpkbDate.ToString() },
                    { "FakturNo", data.FakturNo },
                    { "FakturDate", data.FakturDate.ToString() },
                    { "LocationId", data.LocationId },
                    { "PoliceNo", data.PoliceNo },
                    { "BpkbDateIn", data.BpkbDateIn.ToString() },
                    { "CreatedBy", data.CreatedBy },
                    { "LastUpdatedBy", data.LastUpdatedBy }
                };
                string baseUrl = "https://localhost:7175/api/BPKB/Create";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, queryParams);
                
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(urlWithQuery, "");

                
            }
            catch (Exception ex)
            {
                
            }
        }
        public async Task DeleteBPKB(string agreementNumber)
        {
            try
            {
                
                string baseUrl = "https://localhost:7175/api/BPKB/Delete";
                string urlWithQuery = QueryHelpers.AddQueryString(baseUrl, "AgreementNumber", agreementNumber);

                HttpResponseMessage response = await _httpClient.PostAsJsonAsync(urlWithQuery, "");


            }
            catch (Exception ex)
            {

            }
        }
    }
}
