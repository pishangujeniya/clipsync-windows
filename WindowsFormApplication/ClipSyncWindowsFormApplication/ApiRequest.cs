using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ClipSync
{
    class ApiRequest
    {
        public static async void CallApiAsync(string url, int request_code, FormUrlEncodedContent array_parameters_key_value, ICallApiResponseListener callApiResponseListener)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebApi.api_domain);
                client.DefaultRequestHeaders.Accept.Clear();
                HttpResponseMessage response = await client.PostAsync(url, array_parameters_key_value);
                if (response.IsSuccessStatusCode)
                {
					// Get the URI of the created resource
					Console.WriteLine(response.Content.ReadAsStringAsync().Result.ToString());
					callApiResponseListener.CallApiResponse(request_code, false, JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString()));
                }
                else
                {
                    callApiResponseListener.CallApiResponse(request_code, true, JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result.ToString()));
                }
            }
        }

        public interface ICallApiResponseListener
        {
            void CallApiResponse(int request_code, bool isError, dynamic json_response);
        }
    }
}
