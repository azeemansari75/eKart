using Orders.BLL.DTOs;
using System.Net;
using System.Net.Http.Json;

namespace Orders.BLL.HttpClientHelper;

public class UsersServiceClient
{
    private readonly HttpClient _httpClient;

    public UsersServiceClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UserDTO?> GetUserByUserID(Guid userID)
    {
        HttpResponseMessage response = await _httpClient.GetAsync($"/api/users/{userID}");

        if (!response.IsSuccessStatusCode)
        {
            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
            else if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new HttpRequestException("Bad request", null, HttpStatusCode.BadRequest);
            }
            else
            {
                throw new HttpRequestException($"Http request failed with status code {response.StatusCode}");
            }
        }


        UserDTO? user = await response.Content.ReadFromJsonAsync<UserDTO>();

        if (user == null)
        {
            throw new ArgumentException("Invalid User ID");
        }

        return user;
    }
}
