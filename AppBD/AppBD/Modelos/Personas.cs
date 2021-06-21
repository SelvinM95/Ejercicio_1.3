using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppBD.Modelos
{
    public class Personas
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        [MaxLength(250)]
        public String nombre { get; set; }

        [MaxLength(250)]
        public String apellidos { get; set; }

        public int edad { get; set; }

        [MaxLength(100), Unique]
        public String correo { get; set; }

        [MaxLength(300)]
        public String direccion { get; set; }

        public DateTime fechanac { get; set; }
    }
}
