using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace LightControl;

public static class HttpRequest
{
    private static readonly HttpClient client = new()
    {
        BaseAddress = new Uri("http://192.168.0.163:5000/api/lights/color"),
    };

    private static readonly string uri = "http://192.168.0.163:5000/api/lights/color";

    private static readonly SemaphoreSlim _requestLock = new(1);
    
    public static async Task SendColor(int r, int g, int b, int w)
    {
        await _requestLock.WaitAsync();
        try
        {
            var payload = new
            {
                color = new
                {
                    all = new[] { r, g, b, w }
                }
            };

            string jsonPayload = JsonSerializer.Serialize(payload);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            await client.PutAsync(uri, content);
        }
        catch (Exception ex)
        {
            //FileConsole.WriteLine(ex.ToString());
        }
        finally
        {
            _requestLock.Release();
        }
    }

    public static async Task SendAlpha(int a)
    {
        await _requestLock.WaitAsync();
        try
        {
            var payload = new
            {
                alpha = a
            };

            var jsonPayload = JsonSerializer.Serialize(payload);

            var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(uri, content);

            await response.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            //FileConsole.WriteLine(ex.ToString());
        }
        finally
        {
            _requestLock.Release();
        }
    }
}