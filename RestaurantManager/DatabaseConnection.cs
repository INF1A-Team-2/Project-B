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

        string jsonResponse = res.Content.ReadAsStringAsync().Result;
        
        Console.WriteLine(jsonResponse);
        
        return JsonConvert.DeserializeObject<List<List<object>>>(jsonResponse);
    }

    private DatabaseCredentials GetCredentialsFromJson(string fileName)
    {
        using (StreamReader stream = new StreamReader(fileName))
        {
            return JsonConvert.DeserializeObject<DatabaseCredentials>(stream.ReadToEnd());
        }
    }
}