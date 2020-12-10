using DataModel.Standard;
using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Data;

namespace All
{
    public class AttacheFileRepository : IAttacheFileRepository
    {
        private readonly IDbConnection db;

        public AttacheFileRepository()
        {
            db = new SqlConnection("server=(localdb)\\mssqllocaldb;database=dev;intergrated security=true;");        
        }

        public void Add(AttacheFileModel model)
        {
            string sql = "AttachFileAdd";

            //파라메터를 직접 구현
            //db.Execute(sql, new { UserId = model.UserId}, commandType: CommandType.StoredProcedure );

            var parameters = new DynamicParameters();
            parameters.Add("@UserId", value: model.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@BoardId", value: model.BoardId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@ArticleId", value: model.ArticleId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            parameters.Add("@FileName", value: model.FileName, dbType: DbType.String, direction: ParameterDirection.Input);
            parameters.Add("@FileSize", value: model.FileSize, dbType: DbType.Int32, direction: ParameterDirection.Input);

            db.Execute(sql, parameters, commandType: CommandType.StoredProcedure);
        }

        public List<AttacheFileModel> GetAll(int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public List<AttacheFileModel> GetByBoardAndArticle(int boardId, int articleId)
        {
            throw new NotImplementedException();
        }

        public List<AttacheFileModel> GetByFileName(string fileName)
        {
            throw new NotImplementedException();
        }

        public List<AttacheFileModel> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateById(string fileName, int fileSize, int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateDownCountById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
