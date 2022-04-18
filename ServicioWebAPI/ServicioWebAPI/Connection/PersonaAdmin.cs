using ServicioWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ServicioWebAPI.Connection
{
    public class PersonaAdmin
    {
        public async Task<IEnumerable<Persona>> Consultar()
        {
            using (ServicioWebAPIEntities contexto = new ServicioWebAPIEntities()) { 
                return await contexto.Persona.AsNoTracking().ToListAsync();
                    }
        }
    }
}