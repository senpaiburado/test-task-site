using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Mvc;
using ProjectTest.Models;

namespace ProjectTest.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View("Index");
        }

        public IActionResult Contact()
        {
            return View("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            string url = "http://isapi.mekashron.com/icu-tech/ICUTech.dll/soap/IICUTech";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/xml;charset=\"utf-8\"";
            request.Accept = "text/xml";
            XmlDocument soapEnvelopeXml = new XmlDocument();
            string filepath = Directory.GetCurrentDirectory() + "/wwwroot/Files/request_data.xml";
            string xmlData = await System.IO.File.ReadAllTextAsync(filepath);
            xmlData = xmlData.Replace("%1", model.UserName).Replace("%2", model.Password);
            soapEnvelopeXml.LoadXml(xml: xmlData);

            using (Stream stream = await request.GetRequestStreamAsync())
            {
                soapEnvelopeXml.Save(stream);
            }

            string soapResult;

            using (WebResponse response = await request.GetResponseAsync())
            {
                using (StreamReader rd = new StreamReader(response.GetResponseStream()))
                {
                    soapResult = rd.ReadToEnd();
                }
            }

            int start = soapResult.IndexOf('{');
            int end = soapResult.IndexOf('}');
            string jsonContent = soapResult.Substring(start, end - start + 1);

            LoginResponseJsonModel jsonModel = Newtonsoft.Json.JsonConvert.DeserializeObject<LoginResponseJsonModel>(jsonContent);

            if (jsonModel.ResultCode == 0)
            {
                ViewBag.Result = "Successful";
                ViewBag.Color = "#24ed0e";
            }
            else
            {
                ViewBag.Result = "There is error! See ResultMessage.";
                ViewBag.Color = "#f44242";
            }

            return View("LoginResponse", jsonModel);
        }
    }
}
