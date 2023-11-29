using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE3.Model
{
    public class Paciente
    {
        public int idPaciente { get; set; }
        public string? NombrePac { get; set; }
        public string? ApellidoPac { get; set; }
        public string? RunPac { get; set; }
        public string? Nacionalidad { get; set; }
        public string? Visa { get; set; }
        public string? Genero { get; set; }
        public string? SintomasPac { get; set; }
        public int Medico_idMedico { get; set; }
    }
}