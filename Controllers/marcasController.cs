using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2019AM606WACRUD.models;
using Microsoft.EntityFrameworkCore;

namespace _2019AM606WACRUD.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class marcasController : ControllerBase
    {

        private readonly equipoContext contexto;
        public marcasController(equipoContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/marcas")]
        public IActionResult Get()
        {
            IEnumerable<models.marcas> marcalista = (from m in contexto.marcas select m);
            if (marcalista.Count() > 0)
            {
                return Ok(marcalista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/marcas/{id_marcas}")]
        public IActionResult Get(int id_marcas)
        {
            marcas m = (from e in contexto.marcas where e.id_marcas == id_marcas select e).FirstOrDefault();

            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/marcas")]
        public IActionResult guardar([FromBody] marcas nuevo)
        {

            try
            {
                contexto.marcas.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/marcas")]
        public IActionResult actualizar([FromBody] marcas nuevo)
        {
            marcas existe = (from e in contexto.marcas where e.id_marcas == nuevo.id_marcas select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.estados = nuevo.estados;
            existe.nombre_marca = nuevo.nombre_marca;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }


        [HttpDelete]
        [Route("api/marcas/{id_marcas}")]
        public IActionResult eliminar(int id_marcas)
        {
            marcas existe = (from e in contexto.marcas where e.id_marcas== id_marcas select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }


            contexto.Entry(existe).State = EntityState.Deleted;
            contexto.SaveChanges();
            return Ok(existe);
        }
    }
}