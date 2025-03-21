using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculadoraMatematica.Models
{
    internal class MathApiService
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task<string> EvaluarExpresion(string expresion)
        {
            var json = JsonSerializer.Serialize(new { expr = expresion });
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await client.PostAsync("https://api.mathjs.org/v4/", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                using JsonDocument doc = JsonDocument.Parse(responseBody);

                if (doc.RootElement.TryGetProperty("result", out JsonElement resultElement))
                {
                    return resultElement.GetString() ?? "Error: Resultado nulo";
                }
                else
                {
                    return "Error: No se encontró el resultado en la respuesta";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("Bad Request") || ex.Message.Contains("invalid"))
                {
                    return "Error: La expresión matemática ingresada no es válida.";
                }
                return $"Error: {ex.Message}";
            }
        }
    }
}
