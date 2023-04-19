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
                SqlConnection connection = new SqlConnection("Data Source=LocalHost;Encrypt=False;Initial Catalog=Practice;Integrated Security=True;");
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

    public class DeleteJobRole{
        public void DeleteJob(int id){
            try{
                SqlConnection connection = new SqlConnection("Data Source=LocalHost;Encrypt=False;Initial Catalog=Practice;Integrated Security=True;");
                connection.Open();
                string cmd = $"Delete from job_details where job_id={id}";
                
                SqlCommand command = new SqlCommand(cmd,connection);
                int row = command.ExecuteNonQuery();
                if(row==1){Console.WriteLine("Job Deleted");}
                connection.Close();
                }
            
            catch(SqlException e){
                Console.WriteLine(e.Message);
                
            } 
        }
    }

}
