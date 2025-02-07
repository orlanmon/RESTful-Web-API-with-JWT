using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RESTfulAPIJWT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace RESTfulWebAPIJWT.Controllers
{

    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {

            this._configuration = configuration;
        }

        [HttpPost]
        public ActionResult<User> Register(UserDTO request)
        {

            User user = new User();
            Int64 UserID = 0;

            try
            {

                // Create a Hash of the Password

                string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

                user.Username = request.Username;
                user.PasswordHash = passwordHash;

                UserID = AddUser(user);

                return Ok(user);

            }
            catch (Exception ex) {


                return StatusCode(500, new { message = "Register Error: " + ex.Message });

            }

          
        }

        [HttpPost]
        public ActionResult<string> Login(UserDTO request)
        {

            User user = null;

            try
            {

                // Database Lookup if User Exists
                user = GetUser(request.Username);

                if (user == null)
                {

                    return BadRequest("User not found");

                }

                // Verify the Password against its Hash

                if (!BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                {
                    return BadRequest("Wrong Password");
                }

                string token = CreateToken(user);

                return Ok(token);

            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "Login Error: " + ex.Message });

            }


        }


        // Generate JWT Token
        private string CreateToken(User user)
        {
           
            try
            {


                // JWT Claims for Payload

                List<Claim> claims = new List<Claim>
            {

                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")

            };

                // Create Issuer Signing Security Key From Secret Key  - used in Signature segment of JWT Token

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:TokenSecretKey").Value!));

                // Create a Digital Signature for the Signing Security Key 

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);


                // Generate JWT Token

                var token = new JwtSecurityToken(

                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cred

                    );



                var jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return jwt;

            }
            catch (Exception ex)
            {


                throw new Exception("CreateToken Error: " + ex.Message);


            }

        }


        private User GetUser(string username)
        {

            SqlConnection objSQLConnection = null;
            SqlCommand objSQLCommand = null;    
            SqlDataAdapter objDataAdapter = null;
            string strSQL = string.Empty;
            string strConnection = string.Empty;
            DataSet dataSet = null; 
            User objUser = null;

            try
            {

                strConnection = _configuration.GetSection("AppSettings:DBConnectionJWTAuthentication").Value!;

                using (objSQLConnection = new SqlConnection(strConnection))
                {



                    strSQL = "sp_GetUser";
                    objSQLCommand = new SqlCommand(strSQL, objSQLConnection);
                    objSQLCommand.CommandType = CommandType.StoredProcedure;




                    objSQLCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50);

                    objSQLCommand.Parameters["@UserName"].Value = username;

                    objDataAdapter = new SqlDataAdapter(objSQLCommand);

                    dataSet = new DataSet();

                    objDataAdapter.Fill(dataSet);


                    if (dataSet.Tables[0].Rows.Count > 0)
                    {

                        objUser = new User();

                        objUser.Username = Convert.ToString(dataSet.Tables[0].Rows[0]["UserName"]);
                        objUser.PasswordHash = Convert.ToString(dataSet.Tables[0].Rows[0]["PasswordHash"]);

                    }
                    else
                    {
                        objUser = null;

                    }

                }

                return objUser;

            }
            catch (Exception ex)
            {


                throw new Exception("GetUser Error: " + ex.Message);


            }
        }


        private Int64 AddUser(User user)
        {

            
                SqlConnection objSQLConnection = null;
                SqlCommand objSQLCommand = null;

                string strSQL = string.Empty;
                string strConnection = string.Empty;
                Int64 UserID = 0;

            try
            {

                strConnection = _configuration.GetSection("AppSettings:DBConnectionJWTAuthentication").Value!;

                using (objSQLConnection = new SqlConnection(strConnection))
                {
                    objSQLConnection.Open();

                    strSQL = "sp_InsertUser";
                    objSQLCommand = new SqlCommand(strSQL, objSQLConnection);
                    objSQLCommand.CommandType = CommandType.StoredProcedure;


                    objSQLCommand.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
                    objSQLCommand.Parameters["@UserName"].Value = user.Username;

                    objSQLCommand.Parameters.Add("@PasswordHash", SqlDbType.VarChar, 1000);
                    objSQLCommand.Parameters["@PasswordHash"].Value = user.PasswordHash;

                    UserID = (Int64)objSQLCommand.ExecuteScalar();

                }

                return UserID;

            }
            catch (Exception ex) { 
            
                
                throw new Exception("Adduser Error: " +  ex.Message);

            
            }
            
           
        }


    }
}
