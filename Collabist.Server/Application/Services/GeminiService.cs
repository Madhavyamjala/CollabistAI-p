using System.Net.Http.Json;
using Collabist.Server.Domain.Constants;
using Microsoft.Extensions.Configuration;

namespace Collabist.Server.Application.Services
{
    /*GeminiService
        Purpose
            Sends prompts to Google's Gemini API and retrieves responses.
        Responsibilities
            Formats requests
            Calls Gemini endpoint
            Extracts text responses
        Notes
            Uses free Gemini REST API
        TODO
            Add streaming support
            Add error classification
     */

    public class GeminiService
    {
        private readonly HttpClient _http;
        private readonly string _apiKey;

        public GeminiService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _apiKey = config["Gemini:ApiKey"]!;
        }

        public async Task<string> GenerateAsync(string prompt)
        {
            var url =
                $"{GeminiConstants.BaseUrl}/{GeminiConstants.Model}:generateContent?key={_apiKey}";

            var request = new
            {
                contents = new[]
                {
                    new
                    {
                        parts = new[]
                        {
                            new { text = prompt }
                        }
                    }
                }
            };

            var response = await _http.PostAsJsonAsync(url, request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadFromJsonAsync<GeminiResponse>();

            return json?.Candidates?[0]?.Content?.Parts?[0]?.Text
                   ?? "No response from Gemini.";
        }
    }

    public class GeminiResponse
    {
        public Candidate[]? Candidates { get; set; }
    }

    public class Candidate
    {
        public GeminiContent? Content { get; set; }
    }

    public class GeminiContent
    {
        public GeminiPart[]? Parts { get; set; }
    }

    public class GeminiPart
    {
        public string? Text { get; set; }
    }
}
