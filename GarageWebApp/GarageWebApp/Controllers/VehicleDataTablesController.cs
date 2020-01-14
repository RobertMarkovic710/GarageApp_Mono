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
using GarageWebApp.Models;

namespace GarageWebApp.Controllers
{
    public class VehicleDataTablesController : ApiController
    {
        private DBModel db = new DBModel(); //new object of DB model class

        // GET: api/VehicleDataTables
        public IQueryable<VehicleDataTable> GetVehicleDataTable()
        {
            return db.VehicleDataTable; //ovom metodom returnas sve objekte iz baze
        }

        // PUT: api/VehicleDataTables/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleDataTable(int id, VehicleDataTable vehicleDataTable) //UPDATE U BAZI ZA NEKI OBJEKT BAZE
        {
            //if (!ModelState.IsValid) //Ovo u Angularu napravio
            //{
            //    return BadRequest(ModelState);
            //}

            if (id != vehicleDataTable.VehicleID)
            {
                return BadRequest();
            }

            db.Entry(vehicleDataTable).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleDataTableExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);//ako sve prodje oke
        }

        // POST: api/VehicleDataTables
        [ResponseType(typeof(VehicleDataTable))]
        public IHttpActionResult PostVehicleDataTable(VehicleDataTable vehicleDataTable) //SLUZI ZA UNOS NOVOG VOZILA
        {
            //if (!ModelState.IsValid) //ISTO NAPRAVIO U ANGULARU
            //{
            //    return BadRequest(ModelState);
            //}

            db.VehicleDataTable.Add(vehicleDataTable); //PRVA VAZNA
            db.SaveChanges();                          //DRUGA VAZNA

            return CreatedAtRoute("DefaultApi", new { id = vehicleDataTable.VehicleID }, vehicleDataTable);
        }

        // DELETE: api/VehicleDataTables/5
        [ResponseType(typeof(VehicleDataTable))]
        public IHttpActionResult DeleteVehicleDataTable(int id) //ZA DELETE
        {
            VehicleDataTable vehicleDataTable = db.VehicleDataTable.Find(id);
            if (vehicleDataTable == null)
            {
                return NotFound();
            }

            db.VehicleDataTable.Remove(vehicleDataTable);
            db.SaveChanges();

            return Ok(vehicleDataTable);
        }

        protected override void Dispose(bool disposing) //ODBACI db objekt od konstruktora gore, OVERRIDANA IZ APICONTROLLER KLASE, NASLJEDUJE NEKE VAZNE STVARI
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleDataTableExists(int id)
        {
            return db.VehicleDataTable.Count(e => e.VehicleID == id) > 0;
        }
    }
}