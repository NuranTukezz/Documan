using Microsoft.AspNetCore.Mvc;

namespace Documan.Server.Helpers
{
    public class Common
    {
        public static string getConnStr()
        {
            var builder = WebApplication.CreateBuilder();           
            string conn = builder.Configuration.GetConnectionString("connection");

            return conn;
        }
    }
}
