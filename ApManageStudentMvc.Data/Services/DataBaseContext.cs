using System.Data.Entity;

namespace ApManageStudent.Data.Services
{
    // puerta a la base de datos.
    public class DataBaseContext : DbContext
    {
        //Definir la dabase set el tipo de tablas que usa nuestra base de datos en relacion a nuestros objetos
        //Convencion para plurales
        
        public DbSet<Entities.Student> Students { get; set; }
    }
}