using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Kabada;

namespace KabadaAPI {
  internal class AIbridge: HttpClient  {
    public string baseAddress { get { return BaseAddress.OriginalString; } set { BaseAddress = new Uri(value);} }

    protected string pack(object o){
      var r=Newtonsoft.Json.JsonConvert.SerializeObject(o, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
      return r;
      }

    protected async virtual Task<Tr> getResult<Tr>(Task<HttpResponseMessage> ts, bool quiet=false, bool asString=false) {
      var response = await ts;
      Tr r;
      if(response.IsSuccessStatusCode){
        if(asString){
         var s=await response.Content.ReadAsStringAsync();
         return (Tr)(object)s;
         }
        r = await response.Content.ReadAsAsync<Tr>();
        return r;
       } else {
        if(quiet!=true){
          //if(response.StatusCode==System.Net.HttpStatusCode.BadRequest){
            var s=await response.Content.ReadAsStringAsync();
            throw new Exception(response.StatusCode+": " +s);
         //   }
          //response.EnsureSuccessStatusCode();
          }
        return default(Tr);
        }
      }

    public virtual async Task<Tr> post<Tp, Tr>(string path, Tp package, bool quiet=false, bool asString=false) {
      var request = new HttpRequestMessage(HttpMethod.Post, path);
      string json = pack(package);
      //request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
      request.Content = new StringContent(json);
      request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      var ts=SendAsync(request);
      return await getResult<Tr>(ts, quiet, asString);
      }

    //===================================================================================================//
    public async Task<string> predict(AIpredictP parm){
      var r=await post<AIpredictP, string>("predict", parm, false, true);
      return r;
      }
    }
  }
