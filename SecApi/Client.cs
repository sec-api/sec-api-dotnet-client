using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SecApi.Exception;


namespace SecApi
{
    public sealed class Client : IDisposable
    {
        private readonly HttpClient _httpClient;
        private const string JsonMimeType = "application/json";
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        /// <summary>
        /// Create new API client
        /// </summary>
        /// <param name="apiAuthToken">API authentication token received from https://sec-api.com</param>
        public Client(string apiAuthToken)
        {
            if (apiAuthToken == null)
                throw new ArgumentNullException(nameof(apiAuthToken));
            if (string.IsNullOrWhiteSpace(apiAuthToken))
                throw new ArgumentException(nameof(apiAuthToken));

            apiAuthToken = apiAuthToken.Trim();

            var httpHandler = new HttpClientHandler();
            _httpClient = new HttpClient(httpHandler, true);
            _httpClient.BaseAddress = new Uri("https://sec-api.com/api/v2/");
            _httpClient.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse("Bearer " + apiAuthToken);
        }

        /// <summary>
        /// Get company details
        /// </summary>
        /// <param name="companyId">Company Id</param>
        /// <returns>Company</returns>
        public async Task<Company> GetCompanyAsync(string companyId)
        {
            if (companyId == null)
                throw new ArgumentNullException(nameof(companyId));
            if (string.IsNullOrWhiteSpace(companyId))
                throw new ArgumentException(nameof(companyId));

            var url = "companies/" + companyId;
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            
            var company = JsonSerializer.Deserialize<Company>(resStr, JsonOptions);
            return company;
        }

        /// <summary>
        /// Find companies
        /// </summary>
        /// <param name="query">Search query</param>
        /// <returns>Found companies</returns>
        public async Task<IEnumerable<Company>> FindCompaniesAsync(CompanyQuery query)
        {
            if (query == null)
                throw new ArgumentNullException(nameof(query));
            
            const string url = "companies/find";
            var reqContent = new StringContent(JsonSerializer.Serialize(query), Encoding.UTF8, JsonMimeType);
            using var res = await _httpClient.PostAsync(url, reqContent);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            
            var companies = JsonSerializer.Deserialize<IEnumerable<Company>>(resStr, JsonOptions);
            return companies;
        }

        /// <summary>
        /// Get filing details
        /// </summary>
        /// <param name="filingId">Filing Id</param>
        /// <returns>Filing</returns>
        public async Task<Filing> GetFilingAsync(string filingId)
        {
            if (filingId == null)
                throw new ArgumentNullException(nameof(filingId));
            if (string.IsNullOrWhiteSpace(filingId))
                throw new ArgumentException(nameof(filingId));

            var url = "filings/" + filingId;
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            
            var filing = JsonSerializer.Deserialize<Filing>(resStr, JsonOptions);
            return filing;
        }

        /// <summary>
        /// Find filings
        /// </summary>
        /// <param name="search">Filing query</param>
        /// <param name="start">Start index</param>
        /// <param name="limit">Limit results. Max allowed results: 1000</param>
        /// <returns>Found filings</returns>
        public async Task<IEnumerable<Filing>> FindFilingsAsync(FilingSearch search, ulong? start = null, ulong? limit = null)
        {
            if (search == null)
                throw new ArgumentNullException(nameof(search));
            
            var url = "filings/find";
            if (start != null && limit != null)
                url += $"?start={start}&limit={limit}";
            else if (start != null)
                url += $"?start={start}";
            else if (limit != null)
                url += $"?limit={limit}";
            
            var reqContent = new StringContent(JsonSerializer.Serialize(search), Encoding.UTF8, JsonMimeType);
            using var res = await _httpClient.PostAsync(url, reqContent);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            
            var filings = JsonSerializer.Deserialize<IEnumerable<Filing>>(resStr, JsonOptions);
            return filings;
        }
        
        /// <summary>
        /// Get filing complete submission text file
        /// </summary>
        /// <param name="filingId">Filing Id</param>
        /// <returns>Complete submission text file</returns>
        public async Task<string> GetFilingCompleteTextFileAsync(string filingId)
        {
            if (filingId == null)
                throw new ArgumentNullException(nameof(filingId));
            if (string.IsNullOrWhiteSpace(filingId))
                throw new ArgumentException(nameof(filingId));

            var url = "filings/" + filingId + "/completeTextFile";
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            return resStr;
        }
        
        /// <summary>
        /// Get the raw content of specific file from the filing
        /// </summary>
        /// <param name="filingId">Filing Id</param>
        /// <param name="sequence">File sequence starting from '1'</param>
        /// <returns>File raw content</returns>
        public async Task<byte[]> GetFilingFileAsync(string filingId, int sequence)
        {
            if (filingId == null)
                throw new ArgumentNullException(nameof(filingId));
            if (string.IsNullOrWhiteSpace(filingId))
                throw new ArgumentException(nameof(filingId));
            if (sequence < 1)
                throw new ArgumentException(nameof(filingId));

            var url = "filings/" + filingId + "/file/" + sequence;
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resBytes = await res.Content.ReadAsByteArrayAsync();
            return resBytes;
        }
        
        /// <summary>
        /// Get the raw content of specific file from the filing
        /// </summary>
        /// <param name="filingId">Filing Id</param>
        /// <param name="filename">Filename</param>
        /// <returns>File raw content</returns>
        public async Task<byte[]> GetFilingFileAsync(string filingId, string filename)
        {
            if (filingId == null)
                throw new ArgumentNullException(nameof(filingId));
            if (string.IsNullOrWhiteSpace(filingId))
                throw new ArgumentException(nameof(filingId));

            var url = "filings/" + filingId + "/file/" + filename;
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resBytes = await res.Content.ReadAsByteArrayAsync();
            return resBytes;
        }
        
        /// <summary>
        /// Get the extracted text from the main filing form
        /// </summary>
        /// <param name="filingId">Filing Id</param>
        /// <returns>Extracted text</returns>
        public async Task<string> GetFilingTextAsync(string filingId)
        {
            if (filingId == null)
                throw new ArgumentNullException(nameof(filingId));
            if (string.IsNullOrWhiteSpace(filingId))
                throw new ArgumentException(nameof(filingId));

            var url = "filings/" + filingId + "/text";
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            return resStr;
        }

        /// <summary>
        /// Get all company tickers
        /// </summary>
        /// <returns>Company tickers</returns>
        public async Task<IEnumerable<CompanyTicker>> GetTickersAsync()
        {
            const string url = "tickers";
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            
            var tickers = JsonSerializer.Deserialize<IEnumerable<CompanyTicker>>(resStr, JsonOptions);
            return tickers;
        }
        
        /// <summary>
        /// Get all SIC codes
        /// </summary>
        /// <returns>SIC codes</returns>
        public async Task<IEnumerable<SicCode>> GetSectorsSicCodesAsync()
        {
            const string url = "sectors/sicCodes";
            using var res = await _httpClient.GetAsync(url);
            ValidateResponse(res);
            var resStr = await res.Content.ReadAsStringAsync();
            
            var sicCodes = JsonSerializer.Deserialize<IEnumerable<SicCode>>(resStr, JsonOptions);
            return sicCodes;
        }
        
        private static void ValidateResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case (int)HttpStatusCode.OK:
                    return;
                case (int)HttpStatusCode.BadRequest:
                    throw new BadRequestSecApiException(response.ReasonPhrase);
                case (int)HttpStatusCode.Unauthorized:
                    throw new UnauthorizedSecApiException(response.ReasonPhrase);
                case (int)HttpStatusCode.NotFound:
                    throw new NotFoundSecApiException(response.ReasonPhrase);
                case 429:
                    throw new TooManyRequestsSecApiException(response.ReasonPhrase);
                default:
                    throw new UnknownSecApiException(response.ReasonPhrase);
            }
        }
        
        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}