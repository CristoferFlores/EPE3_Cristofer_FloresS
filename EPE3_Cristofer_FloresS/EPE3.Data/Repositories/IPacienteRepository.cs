using EPE3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE3_Cristofer_FloresS.EPE3.Data.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetALLPacientes();
        Task<Medico> GetDetails(int idPaciente);
        Task<bool> InsertPaciente(Paciente paciente);
        Task<bool> UpdatePaciente(Paciente paciente);
        Task<bool> DeletePaciente(Paciente paciente);
    }
}
