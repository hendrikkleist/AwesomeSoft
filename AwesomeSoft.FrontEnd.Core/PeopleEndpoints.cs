using AwesomeSoft.Domain.Entities;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AwesomeSoft.FrontEnd.Core;

public class PeopleEndpoints
{
    public async Task<List<Person>> GetPeople()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://localhost:7182/People"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Person>>(body, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
    }

    public async Task<bool> CreatePerson(int id, string FirstName, string LastName)
    {
        var client = new HttpClient();
        var person = new Person() {Id = id, FirstName = FirstName, LastName = LastName };
        var serializedPerson = JsonSerializer.Serialize(person);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://localhost:7182/People"),
            Content = new StringContent(serializedPerson)
            {
                Headers =
                {
                    ContentType = new MediaTypeHeaderValue("application/json")
                }
            }
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }

    public async Task<Person> GetPerson(int id)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://localhost:7182/People/{id}"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<Person>(body, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
    }

    public async Task<int> UpdatePerson(Person person)
    {
        var client = new HttpClient();
        var serializedPerson = JsonSerializer.Serialize(person);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri($"https://localhost:7182/People/{person.Id}"),
            Content = new StringContent(serializedPerson)
            {
                Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
            }
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<int>(body, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
    }

    public async Task<bool> DeletePerson(Person person)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri($"https://localhost:7182/People/{person.Id}"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }

    public async Task<List<Booking>> GetBookings(Person person)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://localhost:7182/People/getbookings/{person.Id}"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<Booking>>(body, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
    }
}
