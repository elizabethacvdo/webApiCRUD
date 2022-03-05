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
 //   [Route("api/[controller]")]
    [ApiController]
    public class tipo_equipoController : ControllerBase
    {

        private readonly equipoContext contexto;
        public tipo_equipoController(equipoContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/tipo_equipo")]
        public IActionResult Get()
        {
            IEnumerable<models.tipo_equipo> eslista = (from m in contexto.tipo_equipo select m);
            if (eslista.Count() > 0)
            {
                return Ok(eslista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/tipo_equipo/{id_tipo_equipo}")]
        public IActionResult Get(int id_tipo_equipo)
        {
            tipo_equipo m = (from e in contexto.tipo_equipo where e.id_tipo_equipo == id_tipo_equipo select e).FirstOrDefault();

            if (m != null)
            {
                return Ok(m);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/tipo_equipo")]
        public IActionResult guardar([FromBody] tipo_equipo nuevo)
        {

            try
            {
                contexto.tipo_equipo.Add(nuevo);
                contexto.SaveChanges();
                return Ok(nuevo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/tipo_equipo")]
        public IActionResult actualizar([FromBody] tipo_equipo nuevo)
        {
            tipo_equipo existe = (from e in contexto.tipo_equipo where e.id_tipo_equipo== nuevo.id_tipo_equipo select e).FirstOrDefault();
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
        [Route("api/tipo_equipo/{id_tipo_equipo}")]
        public IActionResult eliminar(int id_tipo_equipo)
        {
            tipo_equipo existe = (from e in contexto.tipo_equipo where e.id_tipo_equipo == id_tipo_equipo select e).FirstOrDefault();
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