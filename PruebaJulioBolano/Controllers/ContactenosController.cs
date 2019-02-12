using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PruebaJulioBolano.Controllers
{
    public class ContactenosController : Controller
    {
        // GET: Contactenos
        public ActionResult Index()
        {

            return View();
        }

        // GET: Contactenos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contactenos/Create
        public ActionResult Create()
        {
            var resultado = GetListadoTipoDocumentos();

            ViewBag.TipoDocumentos = resultado.Select(p => new SelectListItem() { Value = p.IdTipoDocumento.ToString(), Text = p.TipoDocumento }).ToList<SelectListItem>();
                     
            return View();
        }

        // POST: Contactenos/Create
        [HttpPost]
        public ActionResult Create(PruebaJulioBolano.WsContactenos.EntContactenos contactenos)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    SetContactenos(contactenos);
                    return RedirectToAction("Index");
                }

                return View(contactenos);

            }
            catch
            {
                return View(contactenos);
            }
        }

        // GET: Contactenos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contactenos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contactenos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contactenos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        private List<WsContactenos.EntTipoDocumento> GetListadoTipoDocumentos()
        {
            try
            {
                var url = "http://localhost:49215/Servicios/ServicioContactenos.svc/GetTiposDocumentos";

                List<WsContactenos.EntTipoDocumento> ListaTipoDocumentos = new List<WsContactenos.EntTipoDocumento>();

                // Synchronous Consumption
                var syncClient = new WebClient();
                var content = syncClient.DownloadString(url);

                // Create the Json serializer and parse the response
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<WsContactenos.EntTipoDocumento>));
                using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(content)))
                {
                    ListaTipoDocumentos = (List<WsContactenos.EntTipoDocumento>)serializer.ReadObject(ms);
                }

                return ListaTipoDocumentos;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void SetContactenos(WsContactenos.EntContactenos contactenos)
        {
            try
            {
                var url = "http://localhost:49215/Servicios/ServicioContactenos.svc/SetContactenos";

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";

                System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
                string json = JsonConvert.SerializeObject(contactenos);
                Byte[] byteArray = encoding.GetBytes(json);

                request.ContentLength = byteArray.Length;
                request.ContentType =  @"application/json";

                using (Stream dataStream = request.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
