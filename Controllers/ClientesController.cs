using Microsoft.AspNetCore.Mvc;
using System.Linq;
using api_web.Models;

namespace api_web.Controllers{
    [Route("api/[controller]")]
    public class ClientesController:Controller{
        private Conexion dbConexion;

        public ClientesController(){
            dbConexion = Conectar.create();
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.Clientes.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id){
            var clientes = dbConexion.Clientes.SingleOrDefault(a => a.idCliente == id);
            if(clientes != null){
                return Ok(clientes);
            } else{
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] Clientes clientes){
            if(ModelState.IsValid){
                dbConexion.Clientes.Add(clientes);
                dbConexion.SaveChanges();
                return Ok("insertado");
            } else{
                return NotFound();
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] Clientes clientes){
            var v_clientes = dbConexion.Clientes.SingleOrDefault(a => a.idCliente == clientes.idCliente);
            if(v_clientes != null && ModelState.IsValid){
                dbConexion.Entry(v_clientes).CurrentValues.SetValues(clientes);
                dbConexion.SaveChanges();
                return Ok("actualizado");
            } else{
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            var clientes = dbConexion.Clientes.SingleOrDefault(a => a.idCliente == id);
            if(clientes != null){
                dbConexion.Clientes.Remove(clientes);
                dbConexion.SaveChanges();
                return Ok("eliminado");
            } else{
                return NotFound();
            }
        }
    }
}