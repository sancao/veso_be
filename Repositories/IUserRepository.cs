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
    public interface IUserRepository
    {
        User Authenticate(string username, string password);
        void Create(User user);
        void Delete(int id);
        User Get(int id);
        List<User> GetUsers();
        void Update(User user);
    }
    public class UserRepository : IUserRepository
    {
        private IConfiguration _configuration;

        public UserRepository(IConfiguration config)
        {
            _configuration = config;
        }

        public User Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            using (MySqlConnection db = new MySqlConnection(
                _configuration.GetConnectionString("ConnectionString")))
            {
                var user = db.Query<User>("SELECT id FROM Users where username='"+username+"'").SingleOrDefault();
                // var user = _context.Users.SingleOrDefault(x => x.Username == username);
 
                // check if username exists
                if (user == null)
                    return null;

                // check if password is correct
                // if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                //     return null;

                // authentication successful
                return user;
            }
        }

        public List<User> GetUsers()
        {
            // using (IDbConnection db = new SqlConnection(connectionString))
            // {
            //     return db.Query<User>("SELECT * FROM Users").ToList();
            // }
            return null;
        }
 
        public User Get(int id)
        {
            // using (IDbConnection db = new SqlConnection(connectionString))
            // {
            //     return db.Query<User>("SELECT * FROM Users WHERE Id = @id", new { id }).FirstOrDefault();
            // }
            return null;
        }
 
        public void Create(User user)
        {
            // using (IDbConnection db = new SqlConnection(connectionString))
            // {
            //     var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age)";
            //     db.Execute(sqlQuery, user);
 
            //     // если мы хотим получить id добавленного пользователя
            //     //var sqlQuery = "INSERT INTO Users (Name, Age) VALUES(@Name, @Age); SELECT CAST(SCOPE_IDENTITY() as int)";
            //     //int? userId = db.Query<int>(sqlQuery, user).FirstOrDefault();
            //     //user.Id = userId.Value;
            // }
        }
 
        public void Update(User user)
        {
            // using (IDbConnection db = new SqlConnection(connectionString))
            // {
            //     var sqlQuery = "UPDATE Users SET Name = @Name, Age = @Age WHERE Id = @Id";
            //     db.Execute(sqlQuery, user);
            // }
        }
 
        public void Delete(int id)
        {
            // using (IDbConnection db = new SqlConnection(connectionString))
            // {
            //     var sqlQuery = "DELETE FROM Users WHERE Id = @id";
            //     db.Execute(sqlQuery, new { id });
            // }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
 
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
 
            return true;
        }
    }
}