using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using ServicioWebAPI.Connection;
using ServicioWebAPI.Models;

namespace ServicioWebAPI.Controllers
{
    public class PersonasController : ApiController
    {
        private ServicioWebAPIEntities db = new ServicioWebAPIEntities();

        private PersonaAdmin admin=new PersonaAdmin();

        // GET: api/Personas
        public async Task<IEnumerable<Persona>> GetPersona()
        {
            return await admin.Consultar();
        }

        // GET: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> GetPersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPersona(int id, Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.Id)
            {
                return BadRequest();
            }

            db.Entry(persona).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Personas
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> PostPersona(Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Persona.Add(persona);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = persona.Id }, persona);
        }

        // DELETE: api/Personas/5
        [ResponseType(typeof(Persona))]
        public async Task<IHttpActionResult> DeletePersona(int id)
        {
            Persona persona = await db.Persona.FindAsync(id);
            if (persona == null)
            {
                return NotFound();
            }

            db.Persona.Remove(persona);
            await db.SaveChangesAsync();

            return Ok(persona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PersonaExists(int id)
        {
            return db.Persona.Count(e => e.Id == id) > 0;
        }
    }
}