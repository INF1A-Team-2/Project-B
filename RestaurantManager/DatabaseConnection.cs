using System.Net;
using System.Security.Authentication;
using Newtonsoft.Json;

namespace RestaurantManager;

class DatabaseCredentials
{
    public string Adress;
    public string Token;
}

class DatabaseConnection
{
    private readonly DatabaseCredentials _credentials;
    private readonly HttpClient _httpClient = new HttpClient();

    public DatabaseConnection(string credentialsFileName)
    {
        this._credentials = GetCredentialsFromJson(credentialsFileName);
        
        _httpClient.DefaultRequestHeaders.Add("Token", _credentials.Token);
    }

    public List<List<object>> Execute(string query, params object[] values)
    {
        StringContent body = new StringContent(
            JsonConvert.SerializeObject(new { Query = query, Values = values }),
            System.Text.Encoding.UTF8,
            "application/json");
        
        HttpResponseMessage res = _httpClient.PostAsync(_credentials.Adress, body).Result;
        string responseBody = res.Content.ReadAsStringAsync().Result;

        switch (res.StatusCode)
        {
            case HttpStatusCode.Unauthorized:
                throw new Exception("The provided database token is invalid");
            
            case HttpStatusCode.BadRequest:
                throw new Exception("No query was provided");
            
            case HttpStatusCode.InternalServerError:
                throw new Exception($"An internal database error occured: {responseBody}");
        }
        
        return JsonConvert.DeserializeObject<List<List<object>>>(responseBody);
    }

    private DatabaseCredentials GetCredentialsFromJson(string fileName)
    {
        using (StreamReader stream = new StreamReader(fileName))
        {
            return JsonConvert.DeserializeObject<DatabaseCredentials>(stream.ReadToEnd());
        }
    }
}