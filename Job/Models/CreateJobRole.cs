using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace Job.Models
{
    public class CreateJobRole
    {
            public string jobRole { get ;set;}
            public double package {get;set;}
            public string company {get;set;}
            public string  location {get;set;}
            public string experience {get;set;}

            public void addJob(){
                
                try{
                SqlConnection connection = new SqlConnection("Data Source=tcp:localhost,1433;User ID=user;Password=user;TrustServerCertificate=True");
                connection.Open();
                string cmd = "";
                cmd += "insert into job_details values"+
                        $"('{this.jobRole}',{this.package},'{this.company}','{this.location}',{this.experience},0)";
                SqlCommand command = new SqlCommand(cmd,connection);
                int row = command.ExecuteNonQuery();
                if(row==1){Console.WriteLine("Job Added");}
                connection.Close();
                }
            
            catch(SqlException e){
                Console.WriteLine(e.Message);
            } 
            }
    }

}
