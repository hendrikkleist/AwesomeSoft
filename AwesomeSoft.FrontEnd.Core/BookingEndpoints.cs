using AwesomeSoft.Domain.Entities;
using AwesomeSoft.FrontEnd.Core.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace AwesomeSoft.FrontEnd.Core
{
    public class BookingEndpoints
    {
        public async Task<Schedule> GetScheduleForRoom(int meetingRoomId)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://localhost:7182/Booking/schedule/{meetingRoomId}"),
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<Schedule>(body, new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true
                });
                return result;
            }
        }

        public async Task<bool> CreateBooking(Booking booking)
        {
            var client = new HttpClient();
            var serializedBooking = JsonSerializer.Serialize(booking);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7182/Booking/book"),
                Content = new StringContent(serializedBooking)
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
                Console.WriteLine(body);
                return response.IsSuccessStatusCode;
            }
        }
    }
}
