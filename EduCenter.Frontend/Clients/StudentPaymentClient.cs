namespace EduCenter.Frontend.Clients;

public class StudentPaymentClient
{
    protected readonly HttpClient _httpClient;
    public virtual string Uri { get; set; } = string.Empty;

    public StudentPaymentClient(HttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
}
