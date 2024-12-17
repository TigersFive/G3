using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

public class MomoPaymentService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;

    public MomoPaymentService(IConfiguration configuration, HttpClient httpClient)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }

    public async Task<string> CreatePaymentRequestAsync(decimal amount, string orderId)
    {
        var momoApiUrl = _configuration["MomoAPI:MomoApiUrl"];
        var secretKey = _configuration["MomoAPI:SecretKey"];
        var accessKey = _configuration["MomoAPI:AccessKey"];
        var partnerCode = _configuration["MomoAPI:PartnerCode"];
        var returnUrl = _configuration["MomoAPI:ReturnUrl"];
        var notifyUrl = _configuration["MomoAPI:NotifyUrl"];
        var requestType = _configuration["MomoAPI:RequestType"];

        var requestBody = new
        {
            partnerCode = partnerCode,
            accessKey = accessKey,
            requestId = Guid.NewGuid().ToString(),
            amount = amount,
            orderId = orderId,
            orderInfo = "Thanh toán bảo hiểm xe",
            returnUrl = returnUrl,
            notifyUrl = notifyUrl,
            requestType = requestType,
            extraData = "{}" // Optional: Any extra data you want to pass
        };

        var requestBodyJson = JsonConvert.SerializeObject(requestBody);
        var byteData = Encoding.UTF8.GetBytes(requestBodyJson);
        var requestContent = new StringContent(requestBodyJson, Encoding.UTF8, "application/json");

        // Sign the request
        var signature = GenerateSignature(secretKey, requestBodyJson);
        requestContent.Headers.Add("Signature", signature);

        // Send the request to Momo API
        var response = await _httpClient.PostAsync(momoApiUrl, requestContent);
        var responseContent = await response.Content.ReadAsStringAsync();
        
        return responseContent; // This will be the result from Momo
    }

    private string GenerateSignature(string secretKey, string requestBodyJson)
    {
        // Implement the signature generation logic based on the Momo API documentation
        var signatureData = secretKey + requestBodyJson;
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(signatureData)); // Sample, adjust as per Momo spec
    }
}
