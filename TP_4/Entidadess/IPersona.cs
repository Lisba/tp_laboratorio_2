using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public interface IPersona
    {
        int Id { get; }
        string Nombre { get; }
        string Apellido { get; }
        int Dni { get; }
        string Email { get; }

        string ConcatNombreApellido(string nombre, string apellido);
    }
}
