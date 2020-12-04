using Microsoft.Extensions.Configuration;
using SUIT.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
//using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace SUIT.DA
{
    public enum SqlCodeExceptions
    {
        SqlConnectionBroken = -1,
        SqlTimeout = -2,
        SqlCouldNotOpenConnection = 2,
        SqlForeignKeyViolation = 547,
        SqlOutOfMemory = 701,
        SqlOutOfLocks = 1204,
        SqlDeadlockVictim = 1205,
        SqlLockRequestTimeout = 1222,
        SqlInvalidDatabase = 4060,
        SqlTimeoutWaitingForMemoryResource = 8645,
        SqlLowMemoryCondition = 8651,
        SqlLoginFailed = 18456,
        SqlWordbreakerTimeout = 30053
    }
    
    public class DA_Connection
    {

        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddDbContext<BloggingContext>(options =>
        //        options.UseSqlServer(Configuration.GetConnectionString("BloggingDatabase")));
        //}

        //public SqlConnection connection_OC()
        //{
        //    SqlConnection vg_SqlConnection = new SqlConnection();
        //    Configuration.GetConnectionString("RazorPagesMovieContext");

        //    //configuration.GetConnectionString("DefaultConnection")
        //    //vg_SqlConnection.ConnectionString = Configuration  Configuration
        //    ///new ConfigurationBuilder().("csKey_Principal");
        //    return vg_SqlConnection;
        //}



        public SqlConnection connection_Sysmacon()
        {
            SqlConnection vg_SqlConnection = new SqlConnection();
            vg_SqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["csKey_Sysmacon"].ConnectionString;
            return vg_SqlConnection;
        }


        public BE_MensajeApp errorSql(int errorNumber, SqlException sqlEx)
        {
            BE_MensajeApp mensajeApp = new BE_MensajeApp();
            mensajeApp.mensajeId = eMensaje.ErrorBD;

            switch (errorNumber)
            {
                case (int)SqlCodeExceptions.SqlConnectionBroken:
                    mensajeApp.descripcion = "No se encuentra el servidor de base de datos";
                    break;
                case (int)SqlCodeExceptions.SqlTimeout:
                    mensajeApp.descripcion = "Expiró el tiempo de espera. Timeout";
                    break;
                case (int)SqlCodeExceptions.SqlCouldNotOpenConnection:
                    mensajeApp.descripcion = "No se pudo abrir conexión a la base de datos";
                    break;
                case (int)SqlCodeExceptions.SqlForeignKeyViolation:
                    mensajeApp.descripcion = "Error de llave foránea";
                    break;
                case (int)SqlCodeExceptions.SqlOutOfMemory:
                    mensajeApp.descripcion = "Servidor con memoria agotada";
                    break;
                case (int)SqlCodeExceptions.SqlOutOfLocks:
                    mensajeApp.descripcion = "Servidor sin capacidad de bloqueos";
                    break;
                case (int)SqlCodeExceptions.SqlDeadlockVictim:
                    mensajeApp.descripcion = "SqlDeadlockVictim";
                    break;
                case (int)SqlCodeExceptions.SqlLockRequestTimeout:
                    mensajeApp.descripcion = "Expiró el tiempo de bloqueo. Timeout";
                    break;
                case (int)SqlCodeExceptions.SqlInvalidDatabase:
                    mensajeApp.descripcion = "Base de datos inválida o inexistente";
                    break;
                case (int)SqlCodeExceptions.SqlTimeoutWaitingForMemoryResource:
                    mensajeApp.descripcion = "SqlTimeoutWaitingForMemoryResource";
                    break;
                case (int)SqlCodeExceptions.SqlLowMemoryCondition:
                    mensajeApp.descripcion = "SqlLowMemoryCondition";
                    break;
                case (int)SqlCodeExceptions.SqlLoginFailed:
                    mensajeApp.descripcion = "Error de inicion de sesión. LoginFailed";
                    break;
                case (int)SqlCodeExceptions.SqlWordbreakerTimeout:
                    mensajeApp.descripcion = "SqlWordbreakerTimeout";
                    break;
            }

            return mensajeApp;
        }
    }
}
