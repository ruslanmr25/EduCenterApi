using EduCenter.Frontend.Interfaces;
using EduCenter.Frontend.Responses;

namespace EduCenter.Frontend.Clients;

public abstract class BaseClient<T> : IClient
    where T : class
{
    //  readonly string Uri = string.Empty;

    protected readonly HttpClient _httpClient;

    public virtual string Uri { get; set; } = string.Empty;

    public BaseClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }

    protected async Task<PaginatedResponse<T>> GetAllAsync(
        string url,
        int pageIndex = 1,
        int pageSize = 40
    )
    {
        var fullUrl = $"{url}?pageIndex={pageIndex}&pageSize={pageSize}";

        var response = await _httpClient.GetFromJsonAsync<PaginatedResponse<T>>(fullUrl);

        return response ?? new PaginatedResponse<T>();
    }

    protected async Task CreateAsync<M>(string url, M entity)
    {
        await _httpClient.PostAsJsonAsync<M>(url, entity);
    }

    protected async Task UpdateAsync<M>(string url, M entity)
    {
        var response = await _httpClient.PutAsJsonAsync<M>(url, entity);

        if (!response.IsSuccessStatusCode)
            throw new Exception(
                $"Failed to update entity at {url}. Status code: {response.StatusCode}"
            );
    }

    protected async Task<T> GetByIdAsync(int id, string url)
    {
        var fullUrl = $"{url}/{id}";
        var response = await _httpClient.GetFromJsonAsync<T>(fullUrl);

        return response ?? throw new Exception($"Entity with ID {id} not found at {fullUrl}");
    }

    public async Task DeleteAsync(int id)
    {
        string url = $"{Uri}/{id}";

        var response = await _httpClient.DeleteAsync(url);
    }
}
