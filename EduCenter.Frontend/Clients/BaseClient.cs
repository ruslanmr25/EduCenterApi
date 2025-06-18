using EduCenter.Frontend.Responses;
using System.Net.Http;
using System.Net.Http.Json;

namespace EduCenter.Frontend.Clients;
public class BaseClient<T> where T : class
{




    protected readonly HttpClient _httpClient;

    public BaseClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }


    protected async Task<PaginatedResponse<T>> GetAllAsync(string url, int pageIndex = 1, int pageSize = 40)
    {


        var fullUrl = $"{url}?pageIndex={pageIndex}&pageSize={pageSize}";


        var response = await _httpClient.GetFromJsonAsync<PaginatedResponse<T>>(fullUrl);

        return response ?? new PaginatedResponse<T>();


    }


    protected async Task CreateAsync<M>(string url, M entity)
    {

        await _httpClient.PostAsJsonAsync<M>(url, entity);
    }





}
