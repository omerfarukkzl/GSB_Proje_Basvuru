using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Net.Http.Headers;

namespace api.Classes
{
    
public class LogExceptionFilter
    {
        // TODO
        // https://medium.com/geekculture/exception-middleware-in-net-core-applications-84e0cc2dacbf
        private readonly RequestDelegate _rdIstek;
        public LogExceptionFilter(RequestDelegate rdIstek)
        {
            _rdIstek = rdIstek;
        }

        public async Task Invoke(HttpContext hcHttpContext)
        {
            try
            {
                await _rdIstek(hcHttpContext);
            }
            catch (Exception exHata)
            {
                bool blnAjaxIstek = hcHttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
                HttpStatusCode hscDurumKodu;
                switch (exHata)
                {
                    case KeyNotFoundException or FileNotFoundException:
                        hscDurumKodu = HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedAccessException:
                        hscDurumKodu = HttpStatusCode.Unauthorized;
                        break;
                    case InvalidOperationException:
                        hscDurumKodu = HttpStatusCode.BadRequest;
                        break;
                    default:
                        hscDurumKodu = HttpStatusCode.InternalServerError;
                        break;
                }

                string strTarih = DateTime.Now.ToString();
                string strSonuc = "############ BASLANGIC ############";
                strSonuc += "\n##### LOG_DATE: " + strTarih;
                strSonuc += "\n##### REQUEST_METHOD: " + hcHttpContext.Request.Method;
                strSonuc += "\n##### REQUEST_GET_DISPLAY_URL: " + hcHttpContext.Request.GetDisplayUrl();
               // strSonuc += "\n##### IP: " + fnZiyaretci_Ip_Bilgisi(hcHttpContext);
                //strSonuc += "\n##### HTTP_REFERER: " + fn.fnZiyaretci_Referans_Bilgisi(hcHttpContext);
                //strSonuc += "\n##### BROWSER_INFO: " + fn.fnZiyaretci_Tarayici_Bilgisi(hcHttpContext);
                strSonuc += "\n##### EXCEPTION_MESSAGE: " + exHata.Message;
                if (exHata.InnerException != null)
                {
                    strSonuc += "\n##### INNER_EXCEPTION_MESSAGE: " + exHata.InnerException.Message;
                }
                strSonuc += "\n##### EXCEPTION_SOURCE: " + (exHata.Source ?? "---");
                strSonuc += "\n##### EXCEPTION_STACK_TRACE: " + (exHata.StackTrace ?? "---");
                strSonuc += "\n############ BITIS ############";

                string strPatika = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/log/");

                if (!Directory.Exists(strPatika))
                {
                    Directory.CreateDirectory(strPatika);
                }

                strTarih = DateTime.Now.ToString("yyyyMMdd hh:mm:ss").Replace(" ", "-").Replace(":", string.Empty);

                
                string strDosya = $"{strTarih}-{hscDurumKodu}.txt";

                strPatika = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/log/" + strDosya);

                using (FileStream fsFileStream = File.Create(strPatika))
                {
                    byte[] bytContent = new UTF8Encoding(true).GetBytes(strSonuc);

                    fsFileStream.Write(bytContent, 0, bytContent.Length);
                }

                //await _rdIstek(hcHttpContext);
                if (!blnAjaxIstek)
                {
                    hcHttpContext.Response.Headers[HeaderNames.Location] = "/404";
                    hcHttpContext.Response.Redirect("/404");
                }
            }
        }
    }


}




