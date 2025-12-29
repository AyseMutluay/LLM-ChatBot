using Mscc.GenerativeAI;
using Mscc.GenerativeAI.Types;
using System.Threading.Tasks;

namespace GeminiChatBot
{
    public class GeminiService
    {
        private readonly GoogleAI _googleAI;
        private readonly GenerativeModel _model;

        // Constructor: Dışarıdan bir anahtar metni bekler
        public GeminiService(string apiKey)
        {
            // API'yi başlatıyoruz
            _googleAI = new GoogleAI(apiKey);



            // Daha yeni olan 2.5 sürümü
            _model = _googleAI.GenerativeModel("gemini-2.5-flash");
        }

        // Botun cevabını getiren metod
        public async Task<string> GetResponseAsync(string userPrompt)
        {
            try
            {
                var response = await _model.GenerateContent(userPrompt);
                return response.Text;
            }
            catch (System.Exception ex)
            {
                return "Hata oluştu: " + ex.Message;
            }
        }
    }
}