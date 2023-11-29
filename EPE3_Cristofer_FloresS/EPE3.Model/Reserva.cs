using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE3.Model
{
    public class Reserva
    {
        public int idReserva { get; set; }
        public string? Especialidad { get; set; }
        public DateTime DiaReserva { get; set; }
        public int Paciente_idPaciente { get; set; }
    }
}

