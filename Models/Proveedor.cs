using SQLite;
namespace Proveedores_CRUD_MVVM_Q42024.Models
{
    public class Proveedor
    {
        [PrimaryKey, AutoIncrement] public int IdProveedor { get; set; }
        [NotNull] public string NombreEmpresa { get; set; }
        [NotNull] public string Rtn { get; set; }
        [NotNull] public string Direccion {  get; set; }
        [NotNull] public string Telefono { get; set; }
    }
}
