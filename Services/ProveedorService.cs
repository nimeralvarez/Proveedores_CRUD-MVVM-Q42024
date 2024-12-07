

using Proveedores_CRUD_MVVM_Q42024.Models;
using SQLite;

namespace Proveedores_CRUD_MVVM_Q42024.Services
{
    public class ProveedorService
    {
        private readonly SQLiteConnection connection;

        public ProveedorService()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Proveedor.db3");
            connection = new SQLiteConnection(dbPath);
            connection.CreateTable<Proveedor>();
        }
        
        public List<Proveedor> GetAll()
        {
            var res=connection.Table<Proveedor>().ToList();
            return res;
        }

        public int Insert(Proveedor proveedor)
        {
            return connection.Insert(proveedor);
        }

        public int Update(Proveedor proveedor)
        {
            return connection.Update(proveedor);
        }

        public int Delete(Proveedor proveedor)
        {
            return connection.Delete(proveedor);
        }
    }
}
