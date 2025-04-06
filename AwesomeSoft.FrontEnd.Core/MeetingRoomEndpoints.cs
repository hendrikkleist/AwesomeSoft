using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AwesomeSoft.Domain.Entities;

namespace AwesomeSoft.FrontEnd.Core;

public class MeetingRoomEndpoints
{
    public async Task<List<MeetingRoom>> GetMeetingRooms()
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("https://localhost:7182/MeetingRoom"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<List<MeetingRoom>>(body, new JsonSerializerOptions() 
            { 
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
    }

    public async Task<bool> CreateMeetingRoom(MeetingRoom meetingRoom)
    {
        var client = new HttpClient();
        var serializedMeetingRoom = JsonSerializer.Serialize(meetingRoom);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://localhost:7182/MeetingRoom"),
            Content = new StringContent(serializedMeetingRoom)
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

    public async Task<MeetingRoom> GetMeetingRoom(int id)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri($"https://localhost:7182/MeetingRoom/{id}"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MeetingRoom>(body, new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }
    }

    public async Task<int> UpdateMeetingRoom(MeetingRoom meetingRoom)
    {
        var client = new HttpClient();
        var serializedMeetingRoom = JsonSerializer.Serialize(meetingRoom);
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Put,
            RequestUri = new Uri($"https://localhost:7182/MeetingRoom/{meetingRoom.Id}"),
            Content = new StringContent(serializedMeetingRoom)
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

    public async Task<bool> DeleteMeetingRoom(MeetingRoom meetingRoom)
    {
        var client = new HttpClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Delete,
            RequestUri = new Uri($"https://localhost:7182/MeetingRoom/{meetingRoom.Id}"),
        };
        using (var response = await client.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }
    }
}
