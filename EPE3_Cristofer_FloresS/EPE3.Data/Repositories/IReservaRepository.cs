using EPE3.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EPE3_Cristofer_FloresS.EPE3.Data.Repositories
{
    public class IReservaRepository
    {
        Task<IEnumerable<Reserva>> GetALLReservas();
        Task<Reserva> GetDetails(int idReserva);
        Task<bool> InsertReserva(Reserva reserva);
        Task<bool> UpdateReserva(Reserva reserva);
        Task<bool> DeleteReserva(Reserva reserva);
    }
}