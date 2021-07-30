using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace piu {
  //  public partial class Transponder : Transponder_FB { }

  public class Transponder : HttpClient {
    public Transponder(){ init(); }

    protected virtual void init() {
      DefaultRequestHeaders.Accept.Clear();
      DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      }

    public string baseAddress { get { return BaseAddress.OriginalString; } set { BaseAddress = new Uri(value);} }

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
          if(response.StatusCode==System.Net.HttpStatusCode.BadRequest){
            var s=await response.Content.ReadAsStringAsync();
            throw new Exception("BadRequest:"+s);
            }
          response.EnsureSuccessStatusCode();
          }
        return default(Tr);
        }
      }

    public virtual async Task<Tr> post<Tp, Tr>(string path, Tp package, bool quiet=false, bool asString=false) {
      var request = new HttpRequestMessage(HttpMethod.Post, path);
      string json = JsonConvert.SerializeObject(package, 0, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                       //Jasonizator.Pack(package);
      //request.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
      request.Content = new StringContent(json);
      request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      var ts=SendAsync(request);
      return await getResult<Tr>(ts, quiet, asString);
      }

    public virtual async Task<string> postS<Tp>(string path, Tp package, bool quiet=false) {
      return await post<Tp, string>(path, package, quiet, true);
      }


    public virtual async Task<string> GO(string path, string package, bool quiet=false) { 
      return await postS<string>(path, package, quiet);
      }
    }
  }
