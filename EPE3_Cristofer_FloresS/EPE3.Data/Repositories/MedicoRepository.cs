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
    public class MedicoRepository : IMedicoRepositry
    {
        public readonly MySqlConfiguration _connectionString;
        public MedicoRepository(MySqlConfiguration connectionString)
        {
            _connectionString = connectionString;
        }
        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }

        public Task<IEnumerable<Medico>> GetALLMedicos()
        {
            var db = dbConnection();

            var sql = @"Select idMedico, NombreMed, ApellidoMed, RunMed, Eunacom, NacionalidadMed, Especialidad, Horarios, TarifaHr 
            from Medico";

            return db.QueryAsync<Medico>(sql, new { });
        }

        public Task<Medico> GetDetails(int idMedico)
        {
            var db = dbConnection();

            var sql = @"Select idMedico, NombreMed, ApellidoMed, RunMed, Eunacom, NacionalidadMed, Especialidad, Horarios, TarifaHr 
            from Medico where idMedico = @IdMedico";

            return db.QueryFirstOrDefaultAsync<Medico>(sql, new { IdMedico = idMedico });
        }

        public async Task<bool> InsertMedico(Medico medico)
        {
            var db = dbConnection();

            var sql = @"Insert into medicos(NombreMed, ApellidoMed, RunMed, Eunacom, NacionalidadMed, Especialidad, Horarios, TarifaHr)
             values(@nombreMed, @apellidoMed, @runMed, @eunacom, @nacionalidadMed, @especialidad, @horarios, @tarifaHr)";

            var result = await db.ExecuteAsync(sql, new { medico.NombreMed, medico.ApellidoMed, medico.RunMed, medico.Eunacom,
            medico.NacionalidadMed, medico.Especialidad, medico.Horarios, medico.TarifaHr
            });
            return result > 0;
        }

        public async Task<bool> UpdateMedico(Medico medico)
        {
            var db = dbConnection();

            var sql = @"Update medicos
                        SET NombreMed = @nombreMed 
                            ApellidoMed = @apellidoMed, RunMed = @runMed, Eunacom = @eunacom, 
                            NacionalidadMed = @nacionalidadMed, Especialidad = @especialidad, Horarios = @horarios, 
                            TarifaHr =@tarifaHr where idMedico = @IdMedico";

            var result = await db.ExecuteAsync(sql, new
            {medico.NombreMed, medico.ApellidoMed, medico.RunMed, medico.Eunacom, medico.NacionalidadMed, medico.Especialidad, medico.Horarios, medico.TarifaHr});
            return result > 0;
        }
        public async Task<bool> DeleteMedico(Medico medico)
        {
            var db = dbConnection;
            var sql = @"Delete FROM MEDICOS WHERE idMedico = @IdMedico";
            var result = await db.ExecuteAsync(sql, new { idMedico = medico.idMedico });
            return result > 0;
        }

    }
}
