using ShareKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reservas.Domain.Model.Reservas
{
   
     public class Pasaje : AggregateRoot<Guid>
    {
        public int Numero { get; private set; }
        public string Nombre { get; private set; }

        public DateTime Horario { get; private set; }
        
        private Pasaje()
        {
            Nombre = string.Empty;
            Horario = DateTime.Now;
        }

        public Pasaje(int _Numero_ , string _Nombre_, DateTime _Horario_)
        {
            Numero = _Numero_;
            Nombre = _Nombre_;
            Horario = _Horario_;
        }

        public static implicit operator Pasaje(int v)
        {
            throw new NotImplementedException();
        }
    }
}
