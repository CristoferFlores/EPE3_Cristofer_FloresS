using EPE3.Data.Repositories;
using EPE3.Model;
using MySql.Data.MySqlClient;
using EPE3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace EPE3_Cristofer_FloresS.EPE3.Data.Repositories
{
    public class ReservaRepository : IReservaRepository
    {
        public readonly MySqlConfiguration _connectionString;
        public ReservaRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Reserva>> GetALLReserva()
        {
            var db = dbConnection();

            var sql = @"Select idReserva, Especialidad, DiaReserva, Paciente_idPaciente
            from Reserva";

            return db.QueryAsync<Reserva>(sql, new { });
        }

        public Task<Reserva> GetDetails(int idReserva)
        {
            var db = dbConnection();

            var sql = @"Select idReserva, Especialidad, DiaReserva, Paciente_idPaciente 
            from Medico where idReserva = @IdReserva";

            return db.QueryFirstOrDefaultAsync<Reserva>(sql, new { IdReserva = idReserva });
        }

        public async Task<bool> InsertMedico(Reserva reserva)
        {
            var db = dbConnection();

            var sql = @"Insert into medicos(Especialidad, DiaReserva, Paciente_idPaciente)
             values(@especialidad, @diaReserva, @paciente_idPaciente)";

            var result = await db.ExecuteAsync(sql, new
            {
                reserva.Especialidad,
                reserva.DiaReserva,
                reserva.Paciente_idPaciente,

            });
            return result > 0;
        }

        public async Task<bool> UpdateMedico(Reserva reserva)
        {
            var db = dbConnection();

            var sql = @"Update reserva
                        SET Especialidad = @especialidad 
                            DiaReserva = @diaReserva, Paciente_idPaciente = @paciente_idPaciente where idMedico = @IdMedico";

            var result = await db.ExecuteAsync(sql, new
            { reserva.Especialidad, reserva.DiaReserva, reserva.Paciente_idPaciente });
            return result > 0;
        }
        public async Task<bool> DeleteMedico(Reserva reserva)
        {
            var db = dbConnection;
            var sql = @"Delete FROM MEDICOS WHERE idMedico = @IdMedico";
            var result = await db.ExecuteAsync(sql, new { idMedico = reserva.idReserva });
            return result > 0;
        }

    }
}