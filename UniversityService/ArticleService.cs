using Microsoft.Extensions.Configuration;
using Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UniversityService.Interfaces;

namespace UniversityService
{
    public class ArticleService : IArticleService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ArticleService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;   
            _configuration = configuration;
        }

        public async Task<List<ArticlesResponse>> GetResultHttp() 
        {
            var sectionurl = _configuration.GetSection("htttpConnection:jsonmock");

            string url = new($"{sectionurl.Value}?page=1");

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);

            var initialResponse = await _httpClient.SendAsync(requestMessage);

            var response = await initialResponse.Content.ReadAsStringAsync();
            
            //Primer consulta, donde me sirve principalmente para saber la cantidad de hojas existentes en la API.
            
            var initialData = JsonSerializer.Deserialize<ApiResponse>(response);

            var articles = new List<ArticlesResponse>();

            for (int page = 1; page <= initialData.TotalPages; page++)
            {
                string urlfor = new($"{sectionurl.Value}?page={page}");
                var requestMessageFor = new HttpRequestMessage(HttpMethod.Get, urlfor);
                var responseFull = await _httpClient.SendAsync(requestMessageFor);

                var responseFor = await responseFull.Content.ReadAsStringAsync();

                var pageData = JsonSerializer.Deserialize<ApiResponse>(responseFor);

                foreach (var article in pageData.Data)
                {
                    ArticlesResponse articlesResponse = new ArticlesResponse();
                    articlesResponse.Name = article.Title ?? article.StoryTitle;
                    articlesResponse.Comments = article.NumComments ?? 0;

                    if (!string.IsNullOrEmpty(articlesResponse.Name))
                    {
                        articles.Add(articlesResponse);
                    }
                }
            }

            var sortedArticles = articles
                    .OrderByDescending(a => a.Comments)
                    .ThenByDescending(a => a.Name)
                    .ToList();

            return sortedArticles;
        }
    }
}
