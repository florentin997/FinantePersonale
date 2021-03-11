using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FinantePersonale.Droid;
using FinantePersonale;
using SQLite;
using System.IO;

namespace FinanteWEB_API.Controllers
{
    public class FinanteController : ApiController
    {
        public static string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "finante_db.sqlite");
        SqlConnection db = new SqlConnection(dbPath);
        
        // GET: api/Finante
        public IEnumerable<string> GetIncomeValue(float value)
        {
           // var listaStudenti = db.ValueModelCh.Where(x => x.Id == Id);

            return listaStudenti;
        }

        // GET: api/Finante/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Finante
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Finante/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Finante/5
        public void Delete(int id)
        {
        }
    }
}
