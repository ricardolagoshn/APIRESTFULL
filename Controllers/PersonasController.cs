using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APIRESTFULL.Controllers
{
    public static class PersonasController
    {
        //Post Methods

        public async static Task<Models.Msg> CreatePerson(Models.Personas persona)
        {
            Models.Msg msg = new Models.Msg();

            String jsonObject = JsonConvert.SerializeObject(persona);

            StringContent contenido = new StringContent(jsonObject, Encoding.UTF8, "application/json");

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = null;

                response = await client.PostAsync("http://192.168.40.92/crud-php/PostPersons.php", contenido);

                if (response != null)
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var resultado = await response.Content.ReadAsStringAsync();
                        msg = JsonConvert.DeserializeObject<Models.Msg>(resultado);
                    }
                }
            }

            return msg;


        }


    }
}
