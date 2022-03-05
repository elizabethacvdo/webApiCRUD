using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _2019AM606WACRUD.models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _2019AM606WACRUD.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class estados_equipoController : ControllerBase
    {

        private readonly equipoContext contexto;
        public estados_equipoController(equipoContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/estados_equipo")]
        public IActionResult Get()
        {
            IEnumerable<models.estados_equipo> eslista = (from m in contexto.estados_Equipo select m);
            if (eslista.Count() > 0)
            {
                return Ok(eslista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/estados_equipo/{id_estados_equipo}")]
        public IActionResult Get(int id_estados_equipo)
        {
            estados_equipo m = (from e in contexto.estados_Equipo where e.id_estados_equipo == id_estados_equipo select e).FirstOrDefault();

            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/estados_equipo")]
        public IActionResult guardar([FromBody] estados_equipo nuevo)
        {

            try
            {
                contexto.estados_Equipo.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/estados_equipo")]
        public IActionResult actualizar([FromBody] estados_equipo nuevo)
        {
            estados_equipo existe = (from e in contexto.estados_Equipo where e.id_estados_equipo == nuevo.id_estados_equipo select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.estado = nuevo.estado;
            existe.descripcion = nuevo.descripcion;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }


        [HttpDelete]
        [Route("api/estados_equipo/{id_estados_equipo}")]
        public IActionResult eliminar(int id_estados_equipo)
        {
            estados_equipo existe = (from e in contexto.estados_Equipo where e.id_estados_equipo == id_estados_equipo select e).FirstOrDefault();
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