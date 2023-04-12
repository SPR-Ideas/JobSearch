using Microsoft.Data.SqlClient;
namespace Job.Models
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }

        public bool CheckPassword(){
            try{
                SqlConnection connection = new SqlConnection("Data Source=tcp:localhost,1433;User ID=user;Password=user;TrustServerCertificate=True");
                connection.Open();
                SqlCommand command = new SqlCommand($"Select password from UserLogin where username='{this.username}'",connection);

                SqlDataReader reader =  command.ExecuteReader();

                if(reader.Read()){
                    return (this.password == reader.GetString(0)?true:false);
                    }
                return false;
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }
            return false;
        }

    }
}
