using EPE3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EPE3.Data.Repositories
{
    public interface IMedicoRepositry
    {
        Task<IEnumerable<Medico>> GetALLMedicos();
        Task<Medico> GetDetails(int IdMedico);
        Task<bool> InsertMedico(Medico medico);
        Task<bool> UpdateMedico(Medico medico);
        Task<bool> DeleteMedico(Medico medico);
    }
}

