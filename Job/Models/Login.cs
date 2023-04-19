using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Job.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        private readonly IConfiguration _configuration;

        public Login(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool CheckPassword(int is_admin=0){
            try{
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("localdb"));
                connection.Open();
                SqlCommand command = new SqlCommand($"Select password , isAdmin ,id from UserLogin where username='{this.username}'",connection);
                SqlDataReader reader =  command.ExecuteReader();
                if(reader.Read()){
                    if(is_admin==1){
                        if (this.password == reader.GetString(0) & reader.GetBoolean(1))
                        {
                            this.Id = reader.GetInt32(2);
                            return true;
                        }

                    }
                    else{
                        if(this.password == reader.GetString(0) & !reader.GetBoolean(1))
                        {
                            this.Id = reader.GetInt32(2);
                            return true;
                        }

                    }
                }
                Console.WriteLine("Invalid Credentials");
                return false;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return false;
        }

    }

    public class LoginModel{
        public int Id {get;set;}
        public string username {get;set;}

        public string password {get;set;}
    }
}
