using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;

namespace MySite.Models
{
    public class UsersModel
    {
        //[USER_NO], [USER_NM], [ID], [PW], [HDPH_NO], [EMAIL], [IS_DEL], [LAST_CHNG_DT], [LAST_USER_NO]
        [Required][Key]
        public int USER_NO { get; set; }
        [Column(TypeName = "varchar(30)")][Required][MaxLength(30)]
        public string USER_NM { get; set; }
        [Column(TypeName = "varchar(20)")][Required][MaxLength(20)]
        public string ID { get; set; }
        [Column(TypeName = "varchar(20)")][Required][MaxLength(20)]
        public string PW { get; set; }
        [Column(TypeName = "varchar(20)")][Required][MaxLength(20)]
        public string HDPH_NO { get; set; }
        [Column(TypeName="varchar(50)")][MaxLength(50)][EmailAddress]
        public string EMAIL { get; set; }
        [Required]
        public bool IS_DEL { get; set; }
        [Required]
        public DateTime LAST_CHNG_DT { get; set; }
        [Required] 
        public int LAST_USER_NO { get; set; }        
        public int? MAX_CNT { get; }
    }

    public interface IUserRepository
    {
        UsersModel Add(UsersModel model);
        List<UsersModel> User_List(int user_no, string search_key, int page, int cnt_page);
        UsersModel User_Select(int user_no);
        UsersModel Update(UsersModel model);
        int Delete(int user_no);
    }

    public class UserRepository : IUserRepository
    {

        private IConfiguration _config;
        private IDbConnection db;

        public UserRepository(IConfiguration config)
        {
            //config를 통해 데이터베이스 연결문자를 알수있다.
            _config = config;
            //appsettings.json의 내용을 가져다 db연결한다, 직접 코딩해도 되는데 이걸 사용하는게 낫지...
            db = new SqlConnection(_config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        }


        public UsersModel Add(UsersModel model)
        {
            throw new NotImplementedException();
        }

        public int Delete(int user_no)
        {
            throw new NotImplementedException();
        }

        public UsersModel Update(UsersModel model)
        {
            throw new NotImplementedException();
        }

        public List<UsersModel> User_List(int user_no, string search_key, int page, int cnt_page)
        {
            string sp_name = "upUSER_LIST";
            
            var p = new DynamicParameters();
            p.Add("@USER_NO", value: user_no, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SEARCH_KEY", value: search_key, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PAGE", value: user_no, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CNT_PAGE", value: user_no, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return db.Query<UsersModel>(sp_name, p, commandType: CommandType.StoredProcedure).ToList();
        }

        public UsersModel User_Select(int user_no)
        {
            throw new NotImplementedException();
        }
    }
}
