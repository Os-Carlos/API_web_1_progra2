using System.ComponentModel.DataAnnotations;

namespace api_web.Models{
    public class Clientes{
        [Key]
        public int idCliente {get;set;}
        public string nit {get;set;}
        public string nombres {get;set;}
        public string apellidos {get;set;}
        public string direccion {get;set;}
        public string telefono {get;set;}
    }
}