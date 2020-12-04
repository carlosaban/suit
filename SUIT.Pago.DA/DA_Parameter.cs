using SUIT.Pago.BE.n;
using SUIT.Security.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SUIT.Pago.DA.n
{
    public class DA_Parameter
    {
        public MySQLDatabase _database { get; set; }

        public DA_Parameter(MySQLDatabase database)
        {
            _database = database;
        }

        public List<BE_Parameter> GetParameter(int idParameter)
        {
            BE_Parameter bE_Parameter = null;
            List<BE_Parameter> bE_Parameters = new List<BE_Parameter>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idparameter", idParameter == 0 ? DBNull.Value : (object) idParameter);

            var rows = _database.QuerySP("sp_getParameter", parameters);

            foreach (var row in rows)
            {
                bE_Parameter = new BE_Parameter();
                bE_Parameter.idParameter = string.IsNullOrEmpty(row["idparameter"]) ? 0 : int.Parse(row["idparameter"]); ;
                bE_Parameter.initials = row["initials"];
                bE_Parameter.name = row["name"];
                bE_Parameter.createdBy = row["createdBy"];
                bE_Parameter.createdDate = string.IsNullOrEmpty(row["createdDate"]) ? DateTime.MinValue : DateTime.Parse(row["createdDate"]);
                bE_Parameter.createdDateFormat = bE_Parameter.createdDate.ToShortDateString();
                bE_Parameter.updatedBy = row["updatedBy"];
                bE_Parameter.updatedDate = string.IsNullOrEmpty(row["updatedDate"]) ? DateTime.MinValue : DateTime.Parse(row["updatedDate"]);
                bE_Parameter.updatedDateFormat = bE_Parameter.updatedDate.ToShortDateString();
                bE_Parameter.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                bE_Parameters.Add(bE_Parameter);

            }
            return bE_Parameters;
        }


        public BE_Parameter CreateParameter(BE_Parameter bE_Parameter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_initials", bE_Parameter.initials);
            parameters.Add("_name", bE_Parameter.name);
            parameters.Add("_createdBy", bE_Parameter.createdBy);
            parameters.Add("_isEnabled", bE_Parameter.isEnabled);

            var id = _database.ExecuteSPGetId("sp_createParameter", parameters);

            bE_Parameter.idParameter = int.Parse(id.ToString());
            
            return bE_Parameter;
        }


        public BE_Parameter UpdateParameter(BE_Parameter bE_Parameter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idparameter", bE_Parameter.idParameter);
            parameters.Add("_initials", bE_Parameter.initials);
            parameters.Add("_name", bE_Parameter.name);
            parameters.Add("_updatedBy", bE_Parameter.updatedBy);
            parameters.Add("_isEnabled", bE_Parameter.isEnabled);

            var result = _database.ExecuteSP("sp_updateParameter", parameters);

            if (result > 0)
            {
                return bE_Parameter;
            }

            return null;
        }

        public int DeleteParameter(int idParameter)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idparameter", idParameter);

            var result = _database.ExecuteSP("sp_deleteParameter", parameters);

            if (result > 0)
            {
                return idParameter;
            }

            return 0;
        }

        public List<BE_ParameterDetail> GetParameterDetail(int idParameter, int idParameterDetail)
        {
            BE_ParameterDetail bE_Parameter = null;
            List<BE_ParameterDetail> bE_Parameters = new List<BE_ParameterDetail>();
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idparameter", idParameter == 0 ? DBNull.Value : (object)idParameter);
            parameters.Add("_idparameterdetail", idParameterDetail == 0 ? DBNull.Value : (object)idParameterDetail);

            var rows = _database.QuerySP("sp_getParameterDetail", parameters);

            foreach (var row in rows)
            {
                bE_Parameter = new BE_ParameterDetail();
                bE_Parameter.idParameterDetail = string.IsNullOrEmpty(row["idparameterdetail"]) ? 0 : int.Parse(row["idparameterdetail"]); 
                bE_Parameter.idParameter = string.IsNullOrEmpty(row["idparameter"]) ? 0 : int.Parse(row["idparameter"]); 
                bE_Parameter.value = row["value"];
                bE_Parameter.text = row["text"];
                bE_Parameter.order = string.IsNullOrEmpty(row["order"]) ? 0 : int.Parse(row["order"]);
                bE_Parameter.createdBy = row["createdBy"];
                bE_Parameter.createdDate = string.IsNullOrEmpty(row["createdDate"]) ? DateTime.MinValue : DateTime.Parse(row["createdDate"]);
                bE_Parameter.createdDateFormat = bE_Parameter.createdDate.ToShortDateString();
                bE_Parameter.updatedBy = row["updatedBy"];
                bE_Parameter.updatedDate = string.IsNullOrEmpty(row["updatedDate"]) ? DateTime.MinValue : DateTime.Parse(row["updatedDate"]);
                bE_Parameter.updatedDateFormat = bE_Parameter.updatedDate.ToShortDateString();
                bE_Parameter.idParameterDetailParent = string.IsNullOrEmpty(row["idparameterdetailparent"]) ? 0 : int.Parse(row["idparameterdetailparent"]);
                bE_Parameter.isEnabled = string.IsNullOrEmpty(row["isEnabled"]) ? false : row["isEnabled"].Equals("1") ? true : false;
                bE_Parameters.Add(bE_Parameter);

            }
            return bE_Parameters;
        }


        public BE_ParameterDetail CreateParameterDetail(BE_ParameterDetail bE_ParameterDetail)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idparameter", bE_ParameterDetail.idParameter);
            parameters.Add("_value", bE_ParameterDetail.value);
            parameters.Add("_text", bE_ParameterDetail.text);
            parameters.Add("_order", bE_ParameterDetail.order);
            parameters.Add("_createdBy", bE_ParameterDetail.createdBy);
            parameters.Add("_idparameterdetailparent", bE_ParameterDetail.idParameterDetailParent == 0 ? DBNull.Value : (object)bE_ParameterDetail.idParameterDetailParent);
            parameters.Add("_isEnabled", bE_ParameterDetail.isEnabled);

            var id = _database.ExecuteSPGetId("sp_createParameterDetail", parameters);

            bE_ParameterDetail.idParameter = int.Parse(id.ToString());

            return bE_ParameterDetail;
        }


        public BE_ParameterDetail UpdateParameterDetail(BE_ParameterDetail bE_ParameterDetail)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idparameterdetail", bE_ParameterDetail.idParameterDetail);
            parameters.Add("_idparameter", bE_ParameterDetail.idParameter);
            parameters.Add("_value", bE_ParameterDetail.value);
            parameters.Add("_text", bE_ParameterDetail.text);
            parameters.Add("_order", bE_ParameterDetail.order);
            parameters.Add("_updatedBy", bE_ParameterDetail.updatedBy);
            parameters.Add("_idparameterdetailparent", bE_ParameterDetail.idParameterDetailParent == 0 ? DBNull.Value : (object)bE_ParameterDetail.idParameterDetailParent);
            parameters.Add("_isEnabled", bE_ParameterDetail.isEnabled);

            var result = _database.ExecuteSP("sp_updateParameterDetail", parameters);

            if (result > 0)
            {
                return bE_ParameterDetail;
            }

            return null;
        }

        public int DeleteParameterDetail(int idParameterDetail)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("_idparameterdetail", idParameterDetail);

            var result = _database.ExecuteSP("sp_deleteParameterDetail", parameters);

            if (result > 0)
            {
                return idParameterDetail;
            }

            return 0;
        }
    }
}
