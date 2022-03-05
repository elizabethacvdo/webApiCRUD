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
  //  [Route("api/[controller]")]
    [ApiController]
    public class equiposController : ControllerBase
    {
        private readonly equipoContext contexto;
        public equiposController(equipoContext mi)
        {
            contexto = mi;
        }


        [HttpGet]
        [Route("api/equipos")]
        public IActionResult Get()
        {
            var equipolista = (from e in contexto.equipos join m in contexto.marcas on e.marca_id equals m.id_marcas join et in contexto.tipo_equipo
                                on e.tipo_equipo_id equals et.id_tipo_equipo join es in contexto.estados_Equipo on
                               e.estado_equipo_id equals es.id_estados_equipo select new
                               { e.nombre,e.marca_id,m.nombre_marca,es.descripcion
                               });
            if (equipolista.Count() > 0)
            {
                return Ok(equipolista);

            }
            return NotFound();
        }


        [HttpGet]
        [Route("api/equipos/{id_equipos}")]
        public IActionResult Get(int id_equipos)
        {
            equipos equipo = (from e in contexto.equipos where e.id_equipos == id_equipos select e).FirstOrDefault();

            if (equipo != null)
            {
                return Ok(equipo);
            }
            return NotFound();
        }


        [HttpPost]
        [Route("api/equipos")]
        public IActionResult guardar([FromBody] equipos nuevoEquipo)
        {

            try
            {
                contexto.equipos.Add(nuevoEquipo);
                contexto.SaveChanges();
                return Ok(nuevoEquipo);
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }


        [HttpPut]
        [Route("api/equipos")]
        public IActionResult actualizar([FromBody] equipos nuevoEquipo)
        {
            equipos existe = (from e in contexto.equipos where e.id_equipos == nuevoEquipo.id_equipos select e).FirstOrDefault();
            if (existe is null)
            {
                return NotFound();

            }

            existe.estado = nuevoEquipo.estado;
            existe.costo = nuevoEquipo.costo;
            contexto.Entry(existe).State = EntityState.Modified;
            contexto.SaveChanges();
            return Ok(existe);
        }


        [HttpDelete]
        [Route("api/equipos/{id_equipos}")]
        public IActionResult eliminar(int id_equipos)
        {
            equipos existe = (from e in contexto.equipos where e.id_equipos == id_equipos select e).FirstOrDefault();
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