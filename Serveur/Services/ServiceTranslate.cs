using arsoudeServeur.Models.DTOs;
using Google.Cloud.Translate.V3;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
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

        public async Task<string> TranslateText(string text, string targetLanguage)
        {
            TranslateTextRequest request = new TranslateTextRequest
            {
                Contents = { text },
                TargetLanguageCode = targetLanguage,
                Parent = $"projects/{projectId}"
            };

            TranslateTextResponse response = await client.TranslateTextAsync(request);

            return response.Translations[0].TranslatedText;
        }

        public async Task<IEnumerable<TraductionIndicator>> DetectLanguage(Object objet)
        {

            List<string> stringObjet = new List<string>();

            Type type = objet.GetType();

            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (field.FieldType == typeof(string))
                {
                    string value = (string)field.GetValue(objet);
                    if (value != null)
                    {
                        stringObjet.Add(value);
                    }
                }
            }

            List<TraductionIndicator> stringObjetTraduit = new List<TraductionIndicator>();

            if (!(stringObjet.Count >= 5))
            {
                
                foreach (string text in stringObjet)
                {
                    string textTraduction = text;
                    if (textTraduction.Length > 30)
                    {
                        textTraduction = textTraduction.Substring(0, 30);
                    }

                    DetectLanguageRequest request = new DetectLanguageRequest
                    {
                        Content = textTraduction,
                        Parent = $"projects/{projectId}"
                    };

                    DetectLanguageResponse response = client.DetectLanguage(request);

                    TraductionIndicator traductionIndicator = new TraductionIndicator()
                    {
                        text = text,
                        targetLanguage = response.Languages[0].LanguageCode
                    };

                    stringObjetTraduit.Add(traductionIndicator);
                }

                
            }

            return stringObjetTraduit.ToList();


        }//return response.Languages[0].LanguageCode;   
    }
}
