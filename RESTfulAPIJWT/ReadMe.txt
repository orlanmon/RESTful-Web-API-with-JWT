



How to use this demo.

#1 Register a User Name and Password with the system.  This will store the user name and password hash in a database.
#2 Login by providing a registered User Name and Password.   User name and Password will be verified against database.   
   JWT will then be passed back to be used in subsequent Web API Calls.
#3 Make Web API Calls passing JWT in Header of Web API Call.


// General Notes

JWT 

https://supertokens.com/blog/what-is-jwt

JSON Web Token is an open industry standard (RFC 7519)

Token is a string that contains some information that can be verified securely

Header: Consists of two parts:
The signing algorithm that’s being used.
The type of token, which, in this case, is mostly “JWT”.

Payload: The payload contains the claims for the JSON object. 
Also contains fields like exp (expire date),   iat (time jwt created), etc

Signature: A string that is generated via a cryptographic algorithm that can be used to verify the integrity of the JSON payload.
Base64URLSafe(HMACHSHA256(<header>, <payload>, <secret key>))



https://www.youtube.com/watch?v=UwruwHl3BlU

https://www.youtube.com/watch?v=TDY_DtTEkes


https://jwt.io/introduction

https://medium.com/code-wave/how-to-make-your-own-jwt-c1a32b5c3898


Debug ASP.NET CORE IN IIS

https://learn.microsoft.com/en-us/visualstudio/debugger/how-to-enable-debugging-for-aspnet-applications?view=vs-2022




Swagger specify header as:  bearer "JWT Token String"


bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoib3JsYW5kbyIsImh0dHA6Ly9zY2hlbWFzLm1pY3Jvc29mdC5jb20vd3MvMjAwOC8wNi9pZGVudGl0eS9jbGFpbXMvcm9sZSI6IkFkbWluIiwiZXhwIjoxNzM2MTAxNDQ2fQ.2GfymtiEvMjTzsA-Ce2gePh6gRJAkkduQKg0yO9GJzq4jiThTpgpfgx8angTISxBCgREMy8tBVS5q2EamyHnPw





// JWT

            /* Header.Payload.Signature */

            // Header 

            /*
            {
                "alg": "HmacSha512",   signing algorithm
                "typ": "JWT"
            } 
            
            Header is Base64Url encoded
            */

            // Payload

            /*
             Registered Claims
             Payload is Base64Url encoded
            */

            // Signature

            /*
             
            HMACSHA256(
            base64UrlEncode(header) + "." +
            base64UrlEncode(payload),
            secret)

            To create the signature part you have to take the encoded header, 
            the encoded payload, a secret, the algorithm specified in the header, and sign that.
            */













/* Stored Procedures */

USE JWTAuthentication

GO

CREATE PROCEDURE [dbo].[sp_GetUser]
  
  @UserName varchar(50)
  
AS 
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 

	Select * FROM dbo.[User] WHERE UserName LIKE Concat('%',@UserName,'%')

  END 

END
GO

USE JWTAuthentication

GO

CREATE PROCEDURE [dbo].[sp_InsertUser]
  
  @UserName varchar(50),
  @PasswordHash varchar(1000)
AS 
BEGIN 

 SET NOCOUNT ON; 

  BEGIN 

	DECLARE @UserID BigInt

	INSERT INTO dbo.[User] ([UserName], [PasswordHash] ) VALUES( @UserName, @PasswordHash )

	SELECT @UserID = SCOPE_IDENTITY()

    SELECT @UserID

  END 

END
GO


























/* Code Snippets */


private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
  }

 
private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
{
     using (var hmac = new HMACSHA512(passwordSalt))
      {
               var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
               return computedHash.SequenceEqual(passwordHash);
       }
 } 

  class SignToken
    {
        static void Main(string[] args)
        {
            try
            {
                // reading the content of a private key PEM file, PKCS8 encoded 
                string privateKeyPem = File.ReadAllText("...");
                // keeping only the payload of the key 
                privateKeyPem = privateKeyPem.Replace("-----BEGIN PRIVATE KEY-----", "");
                privateKeyPem = privateKeyPem.Replace("-----END PRIVATE KEY-----", "");
                byte[] privateKeyRaw = Convert.FromBase64String(privateKeyPem);
                // creating the RSA key 
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
                provider.ImportPkcs8PrivateKey(new ReadOnlySpan<byte>(privateKeyRaw), out _);
                RsaSecurityKey rsaSecurityKey = new RsaSecurityKey(provider);
                // Generating the token 
                var now = DateTime.UtcNow;
                var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, "YOUR_CLIENTID"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
                var handler = new JwtSecurityTokenHandler();
                var token = new JwtSecurityToken
                (
                    "YOUR_CLIENTID",
                    "https://AAAS_PLATFORM/idp/YOUR_TENANT/authn/token",
                    claims,
                    now.AddMilliseconds(-30),
                    now.AddMinutes(60),
                    new SigningCredentials(rsaSecurityKey, SecurityAlgorithms.RsaSha256)
                );
                // handler.WriteToken(token) returns the token ready to send to AaaS !
                Console.WriteLine( handler.WriteToken(token) );
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine(
                     new System.Diagnostics.StackTrace().ToString()
                );
            }
        }
    }



    public async Task MyMethodAsync()
{
    Task<int> longRunningTask = LongRunningOperationAsync();
    // independent work which doesn't need the result of LongRunningOperationAsync can be done here

    //and now we call await on the task 
    int result = await longRunningTask;
    //use the result 
    Console.WriteLine(result);
}

public async Task<int> LongRunningOperationAsync() // assume we return an int from this long running operation 
{
    await Task.Delay(1000); // 1 second delay
    return 1;
}

