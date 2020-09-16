using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CobaltElectronics.Models;

namespace CobaltElectronics.Controllers
{
    public class ProizvodsApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/ProizvodsApi
        public IQueryable<Proizvod> GetProizvods()
        {
            return db.Proizvods;
        }

        // GET: api/ProizvodsApi/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult GetProizvod(int id)
        {
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return Ok(proizvod);
        }

        // PUT: api/ProizvodsApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProizvod(int id, Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != proizvod.Id)
            {
                return BadRequest();
            }

            db.Entry(proizvod).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProizvodExists(id))
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

        // POST: api/ProizvodsApi
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult PostProizvod(Proizvod proizvod)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Proizvods.Add(proizvod);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = proizvod.Id }, proizvod);
        }

        // DELETE: api/ProizvodsApi/5
        [ResponseType(typeof(Proizvod))]
        public IHttpActionResult DeleteProizvod(int id)
        {
            Proizvod proizvod = db.Proizvods.Find(id);
            if (proizvod == null)
            {
                return NotFound();
            }

            db.Proizvods.Remove(proizvod);
            db.SaveChanges();

            return Ok(proizvod);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProizvodExists(int id)
        {
            return db.Proizvods.Count(e => e.Id == id) > 0;
        }
    }
}