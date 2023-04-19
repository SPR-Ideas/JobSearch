using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Job.Models
{
    public class CreateJobRole
    {
        public JobModel job = new JobModel();
        private readonly IConfiguration _configuration;

        public CreateJobRole(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void addJob(){

            try{
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("localdb"));
                connection.Open();
                string cmd = "";
                cmd += "insert into job_details values"+
                        $"('{job.jobRole}',{job.package},'{job.company}','{job.location}',{job.experience},0)";
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
        private readonly IConfiguration _configuration;
        public DeleteJobRole(IConfiguration configuration){
            _configuration = configuration;
        }
        public void DeleteJob(int id){
            try{
                SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("localdb") );
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

    public class JobSearch{
        public int Id {get;set;}
        public string SearchQuery {get;set;}
    }
    public class JobModel{
        public string jobRole { get ;set;}
        public double package {get;set;}
        public string company {get;set;}
        public string  location {get;set;}
        public string experience {get;set;}
    }

}
