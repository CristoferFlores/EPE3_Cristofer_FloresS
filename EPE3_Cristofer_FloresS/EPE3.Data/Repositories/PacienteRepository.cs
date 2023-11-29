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
    public class PacienteRepository : IPacienteRepository
    {
        public readonly MySqlConfiguration _connectionString;
        public PacienteRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Paciente>> GetALLPacientes()
        {
            var db = dbConnection();

            var sql = @"Select idPaciente, NombrePac, ApellidoPac, RunPac, Nacionalidad, Visa, Genero, SintomasPac, Medico_idMedico 
            from Paciente";

            return db.QueryAsync<Paciente>(sql, new { });
        }

        public Task<Paciente> GetDetails(int idPaciente)
        {
            var db = dbConnection();

            var sql = @"Select idPaciente, NombrePac, ApellidoPac, RunPac, Nacionalidad, Visa, Genero, SintomasPac, Medico_idMedico 
            from Medico where idPaciente = @IdPaciente";

            return db.QueryFirstOrDefaultAsync<Paciente>(sql, new { IdPaciente = idPaciente });
        }

        public async Task<bool> InsertPaciente(Paciente paciente)
        {
            var db = dbConnection();

            var sql = @"Insert into medicos(NombrePac, ApellidoPac, RunPac, Nacionalidad, Visa, Genero, SintomasPac, Medico_idMedico)
             values(@nombrePac, @apellidoPac, @runPac, @nacionalidad, @visa, @genero, @sintomasPac, @medico_idMedico)";

            var result = await db.ExecuteAsync(sql, new
            {
                paciente.NombrePac,
                paciente.ApellidoPac,
                paciente.RunPac,
                paciente.Nacionalidad,
                paciente.Visa,
                paciente.Genero,
                paciente.SintomasPac,
                paciente.Medico_idMedico
            });
            return result > 0;
        }

        public async Task<bool> UpdatePaciente(Paciente paciente)
        {
            var db = dbConnection();

            var sql = @"Update medicos
                        SET NombrePac = @nombrePac 
                            ApellidoPac = @apellidoPac, RunPac = @runPac, Nacionalidad = @nacionalidad, 
                            Visa = @visa, Genero = @genero, SintomasPac = @sintomasPac, 
                            Medico_idMedico =@medico_idMedico where idPaciente = @IdPaciente";

            var result = await db.ExecuteAsync(sql, new
            { paciente.NombrePac, paciente.ApellidoPac, paciente.RunPac, paciente.Nacionalidad, paciente.Visa, paciente.Genero, paciente.SintomasPac, paciente.Medico_idMedico });
            return result > 0;
        }
        public async Task<bool> DeleteMedico(Paciente paciente)
        {
            var db = dbConnection;
            var sql = @"Delete FROM Pacientes WHERE idPaciente = @IdPaciente";
            var result = await db.ExecuteAsync(sql, new { idMedico = paciente.idPaciente });
            return result > 0;
        }

    }
}

