using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Job.Models
{
        public class JobDetails{
        public int Id;
        public string jobRole;
        public double package;
        public string company;
        public string location;
        public int experience;
        
    }

    public class AdminModels
    {
        public List<JobDetails> JobList = new List<JobDetails>();
        public void fetch (){
            try{
                SqlConnection connection = new SqlConnection("Data Source=tcp:localhost,1433;User ID=user;Password=user;TrustServerCertificate=True");
                connection.Open();
                SqlCommand command = new SqlCommand($"Select * from job_details",connection);

                SqlDataReader reader =  command.ExecuteReader();
                while(reader.Read()){
                    JobDetails jd = new JobDetails();
                    jd.Id = reader.GetInt32(0);
                    jd.jobRole = reader.GetString(1);
                    jd.package = reader.GetDouble(2);
                    jd.company = reader.GetString(3);
                    jd.location = reader.GetString(4);
                    jd.experience = reader.GetInt32(5);
                    JobList.Add(jd);
                }
            }
            catch(Exception e){
                Console.WriteLine(e.Message);
            }   
        }
        }

        }