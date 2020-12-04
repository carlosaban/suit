using SUIT.BE;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.DA
{
    public class DA_Aux
    {

        public List<BE_Aux> listar(string codEmp)
        {
            List<BE_Aux> vResultado = new List<BE_Aux>();
            BE_Aux oEntidad = null;
            SqlDataReader oSqlDataReader = null;
            SqlConnection pSql_Connection = new DA_Connection().connection_Sysmacon();

            using (SqlCommand oSqlCommand = new SqlCommand("SP_TGAUX_LISTAR", pSql_Connection))
            {
                try
                {
                    oSqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    oSqlCommand.Parameters.Clear();
                    oSqlCommand.Parameters.Add(new SqlParameter("@PI_COD_EMP", (codEmp == string.Empty ? (object)DBNull.Value : codEmp)));
                    pSql_Connection.Open();
                    oSqlDataReader = oSqlCommand.ExecuteReader();
                    while (oSqlDataReader.Read())
                    {
                        oEntidad = new BE_Aux();
                        oEntidad.codemp = Convert.ToString(oSqlDataReader["codemp"]);
                        oEntidad.codaux = Convert.ToString(oSqlDataReader["codaux"]);
                        oEntidad.razaux = Convert.ToString(oSqlDataReader["razaux"]);
                        oEntidad.rucaux = Convert.ToString(oSqlDataReader["rucaux"]);

                        vResultado.Add(oEntidad);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (pSql_Connection != null) { pSql_Connection.Close(); }
                    if (oSqlCommand != null) { oSqlCommand.Dispose(); }
                }
            }
            return vResultado;
        }

    }
}
