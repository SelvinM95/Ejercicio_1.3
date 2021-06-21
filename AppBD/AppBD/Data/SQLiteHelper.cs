using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using AppBD.Modelos;
using System.Threading.Tasks;

namespace AppBD.Data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper( string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Personas>().Wait();
        }

        //Guardar Datos
        public Task <int> SavePersonaAsync(Personas persona)
        {
            if (persona.id !=0)
            {
                return db.UpdateAsync(persona);
            }
            else
            {
                return db.InsertAsync(persona);
            }
        }

        //Muestar todos los datos de la BD
        public Task<List<Personas>> GetPersonasAsync()
        {
            return db.Table<Personas>().ToListAsync();
        }

        //Muestar todos los datos de la BD por ID
        public Task<Personas> GetPersonasByIdAsync(int id)
        {
            return db.Table<Personas>().Where(a => a.id == id).FirstOrDefaultAsync();
        }

        //Borrar datos
        public Task<int> DeletePersonasAsync(Personas persona)
        {
            return db.DeleteAsync(persona);
        }
    }
}
