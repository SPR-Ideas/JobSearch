using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Job.Models
{
    public class UserMap
    {
        public int Id {get;set;}
        public int JId{get;set;}

        public void apply(){
            try{
                SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=JobHunt;Integrated Security=True;Encrypt=False");
                connection.Open();
                string cmd = $"Insert into JOB_IRST values({this.JId},{this.Id})";
                SqlCommand command = new SqlCommand(cmd,connection);
                int row = command.ExecuteNonQuery();
                if(row==1){Console.WriteLine("Job applied");}
                connection.Close();
                }

            catch(SqlException e){
                Console.WriteLine(e.Message);

            }
        }
    }
}
