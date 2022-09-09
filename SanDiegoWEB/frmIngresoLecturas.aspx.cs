using Newtonsoft.Json;
using SanDiegoBE;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Script.Serialization;

namespace Prueba_San_Diego
{
    public partial class frmIngresoLecturas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        private void LlenarGrid()
        {
            try
            {
                HttpWebRequest request;
                WebResponse response;
                var strResultado = string.Empty;
                var direccion = "http://localhost:49581/Api/LecturaContador/";

                request = (HttpWebRequest)(WebRequest.Create(direccion));
                response = request.GetResponse();

                Stream responseStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                strResultado = reader.ReadToEnd();

                List<LecturaContadorBE> vDatos = JsonConvert.DeserializeObject<List<LecturaContadorBE>>(strResultado);

                GridDatos.DataSource = vDatos;
                GridDatos.AutoGenerateColumns = false;
                GridDatos.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ ex.Message + "');</script>");
            }
        }

        protected void Grabar_Click(object sender, EventArgs e)
        {
            GrabarDatos();
        }

        private async void GrabarDatos()
        {
            try
            {
                var vReg = new LecturaContadorBE();
                vReg.NumContador = txtNumContador.Text;
                vReg.Fecha = Convert.ToDateTime(txtFechaLectura.Text);
                vReg.Valor = Convert.ToDecimal(txtValor.Text);
                vReg.Observaciones = txtObservaciones.Text;

                HttpClient client = new HttpClient();
                //client.BaseAddress = new Uri("http://localhost:49581/Api/LecturaContador/Add");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(vReg);
                var stringContent = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("http://localhost:49581/Api/LecturaContador/Add", stringContent);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Registro Guardado Exitosamente');", true);

                    txtNumContador.Text = string.Empty;
                    txtFechaLectura.Text = string.Empty;
                    txtValor.Text = string.Empty;
                    txtObservaciones.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('" + ex.Message + "');", true);
            }
        }
    }
}