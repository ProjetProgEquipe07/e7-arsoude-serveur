using Google.Cloud.Translate.V3;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace arsoudeServeur.Services
{
    public class ServiceTranslate
    {
        TranslationServiceClient client;
        string jsonPath = @".\arsoude-412818-0698c822564d.json";
     
        string projectId = "arsoude-412818";
        string targetLanguage = "";

        public ServiceTranslate()
        {
            TranslationServiceClientBuilder builder = new TranslationServiceClientBuilder
            {
                CredentialsPath = jsonPath
            };

            client = builder.Build();
        }

        public async Task<string> TranslateText(string text)
        {
            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents = { text },
                TargetLanguageCode = "en",
                Parent = $"projects/{projectId}"
            };

            TranslateTextResponse response = await client.TranslateTextAsync(request);

            return response.Translations[0].TranslatedText;
        }

        public async Task<string> DetectLanguage(string text)
        {

            if (text.Length > 30)
            {
                text = text.Substring(0, 30);
            }

            DetectLanguageRequest request = new DetectLanguageRequest
            {
                Content = text,
                Parent = $"projects/{projectId}"
            };

            DetectLanguageResponse response = client.DetectLanguage(request);


            return response.Languages[0].LanguageCode;
        }

        public async Task<string> TranslateEnglish(string text)
        {
            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents = { text } ,
                TargetLanguageCode = "en",
                Parent = $"projects/{projectId}"
            };

            TranslateTextResponse response = await client.TranslateTextAsync(request);

            return response.Translations[0].TranslatedText;
        }

        public async Task<string> TranslateFrançais(string text)
        {
            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents = { text },
                TargetLanguageCode = "fr",
                Parent = $"projects/{projectId}"
            };

            TranslateTextResponse response = await client.TranslateTextAsync(request);

            return response.Translations[0].TranslatedText;
        }
    }
}
