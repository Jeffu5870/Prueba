using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Facturación.Modelo;
using CRUD_Facturación.Modelo.View_Models;
using CRUD_Facturación.Modelo.Respuesta;


namespace CRUD_Facturación.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteCRUDController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta respuesta = new Respuesta();
            respuesta.Verdadero = 0;
            try
            {
                using (Datos_CRUDContext db = new Datos_CRUDContext())
                {
                    var lst = db.Clientes.ToList();
                    respuesta.Verdadero = 1;
                    respuesta.Datos = lst;
                }
            }
            catch(Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        //Método que se utilizará para añadir datos
        [HttpPost]
        public IActionResult Add(ClienteRespuesta oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using(Datos_CRUDContext db = new Datos_CRUDContext())
                {
                    Cliente oCliente = new Cliente();
                    oCliente.Nit = oModel.Nit;
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Apellido = oModel.Apellido;
                    oCliente.Telefono = oModel.Telefono;
                    oCliente.Direccion = oModel.Direccion;
                    db.Clientes.Add(oCliente);
                    db.SaveChanges();
                    respuesta.Verdadero = 1;
                }
                respuesta.Verdadero = 1;

            }
            catch(Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }

        //Método que se utilizará para editar datos
        [HttpPut]
        public IActionResult Edit(ClienteRespuesta oModel)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (Datos_CRUDContext db = new Datos_CRUDContext())
                {
                    Cliente oCliente = db.Clientes.Find(oModel.Nit);
                    oCliente.Nit = oModel.Nit;
                    oCliente.Nombre = oModel.Nombre;
                    oCliente.Apellido = oModel.Apellido;
                    oCliente.Telefono = oModel.Telefono;
                    oCliente.Direccion = oModel.Direccion;
                    db.Entry(oCliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    respuesta.Verdadero = 1;
                }
                respuesta.Verdadero = 1;

            }
            catch (Exception ex)
            {
                respuesta.Mensaje = ex.Message;
            }
            return Ok(respuesta);
        }


        //Método que se utilizará para eliminar datos
        [HttpDelete] //parámetros por url
        public IActionResult Delete(int Nit)
        {
            Respuesta respuesta = new Respuesta();
            try
            {
                using (Datos_CRUDContext db = new Datos_CRUDContext())
                {
                    Cliente oCliente = db.Clientes.Find(Nit);
                    db.Remove(oCliente); //Remove para poder eliminar
                    db.SaveChanges();// Guardar 
                    respuesta.Verdadero = 1;
                }
                

            }
            catch (Exception e)
            {
                respuesta.Mensaje = e.Message;
            }
            return Ok(respuesta);
        }
    }
}
