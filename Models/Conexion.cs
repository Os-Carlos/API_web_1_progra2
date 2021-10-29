using Microsoft.EntityFrameworkCore;

namespace api_web.Models{
    class Conexion:DbContext{
        public Conexion(DbContextOptions<Conexion> options):base(options){}
        public DbSet<Clientes> Clientes{get;set;}
    }

    class Conectar{
        private const string cadenaConexion = "server=localhost;port=3306;database=bd_clientes;user=root;pwd=12902018933";

        public static Conexion create(){
            var constructor = new DbContextOptionsBuilder<Conexion>();
            constructor.UseMySQL(cadenaConexion);
            var cn = new Conexion (constructor.Options);
            return cn;
        }
    }
}