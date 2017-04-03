using System.Collections.Generic;
using System.Linq;
using lostInWoods;
using System.Data;
using MySql.Data.MySqlClient;
using lostInWoods.Models;
using Microsoft.Extensions.Options;
using Dapper;

namespace lostInWoods.Factory
{
    public class TrailFactory : IFactory<Trail>
    {
        private  IOptions<MySqlOptions> mysqlConfig;
        public TrailFactory(IOptions<MySqlOptions> conf)
        {
            mysqlConfig = conf;
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(mysqlConfig.Value.ConnectionString);
            }
        }
        public IEnumerable<Trail> FindAllTrails()
        {
            using(IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Trail>($"select * from trails");
            }
        }
         public void AddNewTrail(Trail newTrail)
        {
            using (IDbConnection dbConnection = Connection){
                string Querystring=$"insert into trails (Name,Description,Length,Elevation,Latitude,Longitude) values('{newTrail.Name}','{newTrail.Description}','{newTrail.Length}','{newTrail.Elevation}','{newTrail.Latitude}','{newTrail.Longitude}')";
                dbConnection.Open();
                dbConnection.Execute(Querystring, newTrail);
            }
        }  
        public IEnumerable<Trail> GetTrailById(double trailId){
            using (IDbConnection dbConnection = Connection){
                dbConnection.Open();
                return dbConnection.Query<Trail>($"select * from trails where trailId='{trailId}'");
            }
        }   
    }
}