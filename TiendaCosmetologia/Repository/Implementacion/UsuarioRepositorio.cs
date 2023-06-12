using Microsoft.EntityFrameworkCore;
using SistemaVentaCosmeticos.Models;
using SistemaVentaCosmeticos.Repository.Contratos;
using System.Collections.Generic;
using System.Linq.Expressions;
using Dapper;
using System.Data;

namespace SistemaVentaCosmeticos.Repository.Implementacion
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly DBVentaCosmeticosContext _dbContext;

        public UsuarioRepositorio(DBVentaCosmeticosContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuario>> Consultar(Expression<Func<Usuario, bool>> filtro = null)
        {
            var query = $@"SELECT * FROM [Usuario]
                            {{where}}";

            using (var connection = _dbContext.CreateConnection())
            {
                var list = await connection.QueryAsync<Usuario>(query, filtro);
                return list;
            }
        }

        public async Task<IEnumerable<Usuario>> Crear(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("NombreApellidos", entidad.NombreApellidos);
                    parameters.Add("Correo", entidad.Correo);
                    parameters.Add("IdRol", entidad.IdRol);
                    parameters.Add("Clave", entidad.Clave);
                    parameters.Add("EsActivo", entidad.EsActivo);

                    var result = await connection.QueryAsync<Usuario>("SPCrearUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("NombreApellidos", entidad.NombreApellidos);
                    parameters.Add("Correo", entidad.Correo);
                    parameters.Add("IdRol", entidad.IdRol);
                    parameters.Add("Clave", entidad.Clave);
                    parameters.Add("EsActivo", entidad.EsActivo);

                    var result = await connection.QueryAsync<Usuario>("SPEditarUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }               
            
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(Usuario entidad)
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("IdUsuario", entidad.IdUsuario);

                    var result = await connection.QueryAsync<Usuario>("SPEliminarUsuario", parameters, commandType: CommandType.StoredProcedure);

                    return true;
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> Lista()
        {
            try
            {
                using (var connection = _dbContext.CreateConnection())
                {
                    return await connection.QueryAsync<Usuario>("SPListarUsuario", null, commandType: CommandType.StoredProcedure);

                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<Usuario>> Obtener(Expression<Func<Usuario, bool>> filtro = null)
        {
            try
            {
                var query = $@"SELECT * FROM [Usuario]
                            {{where}}";

                using (var connection = _dbContext.CreateConnection())
                {
                    var list = await connection.QueryAsync<Usuario>(query, filtro);
                    return list;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
