using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using veso_be.Entities;

using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Dapper;
 
namespace veso_be.Repositories
{
    public interface IDaiLyRepository
    {
        bool Create(DaiLy daily);
        bool Delete(int id);
        DaiLy Get(int id);
        List<DaiLy> Get();
        bool Update(DaiLy daily);
    }

    public class DaiLyRepository : IDaiLyRepository
    {
        private IConfiguration _configuration;

        public DaiLyRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public List<DaiLy> Get()
        {
            using (MySqlConnection db = new MySqlConnection(
                _configuration.GetConnectionString("ConnectionString")))
            {
                var daily = db.Query<DaiLy>("SELECT id,ma_dai_ly MaDaiLy,ten_dai_ly TenDaiLy, FROM daily").ToList();
                
                return daily;
            }
        }
 
        public DaiLy Get(int id)
        {
            using (MySqlConnection db = new MySqlConnection(
                _configuration.GetConnectionString("ConnectionString")))
            {
                var daily = db.Query<DaiLy>("SELECT id,ma_dai_ly MaDaiLy,ten_dai_ly TenDaiLy, FROM daily where id='"+ id +"'").SingleOrDefault();
                
                return daily;
            }
        }
 
        public bool Create(DaiLy daily)
        {
            using (MySqlConnection db = new MySqlConnection(
                _configuration.GetConnectionString("ConnectionString")))
            {
                var sqlQuery = "INSERT INTO daily (ma_dai_ly, ten_dai_ly) VALUES(@MaDaiLy, @TenDaiLy)";
                return db.Execute(sqlQuery, daily)>0;

                //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
                //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
                //user.Id = userId.Value;
            }

            return false;
        }
 
        public bool Update(DaiLy daily)
        {
            using (MySqlConnection db = new MySqlConnection(
                _configuration.GetConnectionString("ConnectionString")))
            {
                var sqlQuery = "UPDATE daily SET ma_dai_ly = @MaDaiLy, ten_dai_ly = @TenDaiLy WHERE id = @Id";
                return db.Execute(sqlQuery, daily)>0;
            }

            return false;
        }
 
        public bool Delete(int id)
        {
            using (MySqlConnection db = new MySqlConnection(
                _configuration.GetConnectionString("ConnectionString")))
            {
                var sqlQuery = "DELETE FROM daily WHERE id = @Id";
                return db.Execute(sqlQuery, new { id })>0;
            }

            return false;
        }
    }
}