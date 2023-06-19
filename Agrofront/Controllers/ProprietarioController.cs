//using Agrofront.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.ResponseCompression;
//using System.Text.Json;
//using System.Text.Json.Serialization;
//using Newtonsoft.Json;
//using System.Net.Http.Json;
//using System.Net.Http.Headers;
//using System.Text;

//namespace Agrofront.Controllers
//{
//    public class ProprietarioController : Controller
//    {
//        private readonly string ENDPOINT = "http://localhost:5211/api/Propriedade/Cadastrar";
//        private readonly HttpClient httpClient = null;


//        public ProprietarioController()
//        {
//            httpClient = new HttpClient();
//            httpClient.BaseAddress = new Uri(ENDPOINT);
//        }
//        [HttpPost]
//        public async Task<IActionResult> Cadastrar(ProprietarioViewModel proprietario)
//        {
//            try
//            {
//                HttpResponseMessage response = await httpClient.PostAsync(proprietario);
//                if (response.IsSuccessStatusCode)
//                {
//                    string content = await response.Content.ReadAsStringAsync();
//                    proprietario = JsonConvert.DeserializeObject<List<ProprietarioViewModel>>(content);
//                }
//                else
//                {
//                    ModelState.AddModelError(null, "Erro ao processar a solicitação");
//                }

//                return View(proprietario);
//            }
//            catch(Exception ex)
//            {
//                string message = ex.Message;
//                throw ex;
//            }
//            return View();
//        }
//    }
//}

