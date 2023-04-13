using Microsoft.Data.SqlClient;
namespace Job.Models
{
    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }

        public bool CheckPassword(int is_admin=0){
            try{
                SqlConnection connection = new SqlConnection("Data Source=tcp:localhost,1433;User ID=user;Password=user;TrustServerCertificate=True");
                connection.Open();
                SqlCommand command = new SqlCommand($"Select password , isAdmin from UserLogin where username='{this.username}'",connection);

                SqlDataReader reader =  command.ExecuteReader();

                if(reader.Read()){
                    if(is_admin==1){
                        if (this.password == reader.GetString(0) & reader.GetBoolean(1))
                        return true;
                    }else{
                        if(this.password == reader.GetString(0) & !reader.GetBoolean(1))
                        return true;
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
}
