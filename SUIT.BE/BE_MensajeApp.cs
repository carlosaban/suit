using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.BE
{
    public enum eMensaje
    {
        GrabarOK = 1,
        GrabarError = 2,
        ActualizarOK = 3,
        ActualizarError = 4,
        EliminarOK = 5,
        EliminarError = 6,
        ValidarOK = 7,
        ValidarError = 8,
        ErrorBD = 9,
        ErrorGeneral = 10,
    }

    public enum eAccion
    {
        Insertar = 'I',
        Modificar = 'U',
        Eliminar = 'D'
    }

    public class BE_MensajeApp
    {
        public eMensaje mensajeId { get; set; }
        public string descripcion { get; set; }
        public bool exito { get; set; }
        public eMensaje codigo { get; set; }
    }
}
