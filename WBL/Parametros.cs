using BD;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WBL
{
    public interface IParametrosService
    {
        Task<DBEntity> Create(ParametrosEntity entity);
        Task<DBEntity> Delete(ParametrosEntity entity);
        Task<IEnumerable<ParametrosEntity>> Get();
        Task<ParametrosEntity> GetById(ParametrosEntity entity);
        Task<DBEntity> Update(ParametrosEntity entity);
    }

    public class TitulosService : IParametrosService
    {
        private readonly IDataAccess sql;

        public TitulosService(IDataAccess _sql)
        {
            sql = _sql;
        }


        public async Task<IEnumerable<ParametrosEntity>> Get()
        {
            try
            {
                var result = sql.QueryAsync<ParametrosEntity>("ListarParametros");

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public async Task<ParametrosEntity> GetById(ParametrosEntity entity)
        {
            try
            {
                var result = sql.QueryFirstAsync<ParametrosEntity>("VerDetalleParametros", new
                {

                    entity.Id_Parametro

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }


        public async Task<DBEntity> Create(ParametrosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("InsertarParametros", new
                {

                    entity.Descripcion,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<DBEntity> Update(ParametrosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EditarParametros", new
                {
                    entity.Id_Parametro,
                    entity.Codigo,
                    entity.Descripcion,
                    entity.Valor,
                    entity.Estado

                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public async Task<DBEntity> Delete(ParametrosEntity entity)
        {
            try
            {
                var result = sql.ExecuteAsync("EliminarParametros", new
                {
                    entity.Id_Parametro,


                });

                return await result;
            }
            catch (Exception)
            {

                throw;
            }



        }



    }
}