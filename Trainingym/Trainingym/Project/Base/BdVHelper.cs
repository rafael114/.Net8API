

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Newtonsoft.Json;
using Project.Base;

namespace BdV.Project.Base
{
    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 4/12/2023
    /// Descripcion: Clase para la definicion de funciones de deserializacion de objetos
    /// </summary>
    public partial class HelperResponse
    {
        #region "Constantes"
        #endregion

        #region "Variables"

        public static string SQLServerTemplate => @"
    SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON
BEGIN TRY
	SET NOCOUNT ON	
	SET DATEFORMAT YMD
	
		BEGIN TRAN ""@tran""

		    @script
		COMMIT TRAN ""@tran""
END TRY
BEGIN CATCH
	SELECT ERROR_NUMBER()  AS [Error]
		  ,ERROR_MESSAGE() AS [Message]
		  ,ERROR_LINE()	   AS [Line]

	IF @@TRANCOUNT > 0
	BEGIN
		ROLLBACK TRAN ""@tran""
	END
END CATCH
";

        /// <summary>
        /// 
        /// </summary>
        public static StatusInfo status;

        public static AnonymousResponse_Model response { get; set; } = new AnonymousResponse_Model();

        #endregion

        #region "Propiedades"
        #endregion

        #region "Funciones"

        #region "Database functions"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 4/12/2023
        /// Descripcion: Funcion para ejecutar script de base de datos
        /// </summary>
        /// <param name="cnx"></param>
        /// <param name="script"></param>
        /// <param name="isTemplate"></param>
        /// <returns></returns>
        public static StatusInfo TranExecSQLServer(string cnx, string script, bool isTemplate = false)
        {
            status = new StatusInfo();

            if (string.IsNullOrEmpty(cnx) || string.IsNullOrEmpty(script))
            {
                status.SendStatus(-1, $"{(string.IsNullOrEmpty(cnx) ? "El parametro de conexión a base de datos esta vacío" 
                                    : $"{(string.IsNullOrEmpty(script) ? "El script esta vacío" : "")}")}");
            }        
            else
            {
                try
                {
                    using (var con = new SqlConnection(cnx))
                    {
                        if (con.State == System.Data.ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        if (isTemplate)
                        {
                            script = SetSQLServerTemplate(script);
                        }

                        con.Execute(script, commandType: System.Data.CommandType.Text);

                    }
                }
                catch (Exception ex)
                {
                    status.SendStatus(-2, ex.Message);
                }
            }           
            return status;    
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 5/12/2023
        /// Descripcion: Funcion para ejecutar script de base de datos
        /// </summary>
        /// <param name="cnx"></param>
        /// <param name="script"></param>
        /// <param name="isTemplate"></param>
        /// <returns></returns>
        public static StatusInfo GetDataSetSQLServer(string cnx, string script, bool isTemplate = false)
        {
            if (string.IsNullOrEmpty(cnx) || string.IsNullOrEmpty(script))
            {
                status.SendStatus(-1, $"{(string.IsNullOrEmpty(cnx) ? "El parametro de conexión a base de datos esta vacío" : $"{(string.IsNullOrEmpty(script) ? "El script esta vacío" : "")}")}");
            }
            else
            {
                try
                {
                    DataSet data = new DataSet();
                    using (var con = new SqlConnection(cnx))
                    {
                        if (con.State == System.Data.ConnectionState.Closed)
                        {
                            con.Open();
                        }

                        if (isTemplate)
                        {
                            script = SetSQLServerTemplate(script);
                        }

                        data = con.Query<DataSet>(script, commandType: System.Data.CommandType.Text).ToList().ConvertListToDataSet();
                    }
                }
                catch (Exception ex)
                {
                    status.SendStatus(-2, ex.Message);
                }
            }
            return status;
        }


        
        #endregion

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 4/12/2023
        /// Descripcion: funcion para agregar parametros adicinales necesarios para la implementacion de la plantilla SQL Server
        /// </summary>
        /// <param name="template"></param>
        /// <returns></returns>
        public static string SetSQLServerTemplate (string body) => body = SQLServerTemplate.Replace("@script", body).Replace("@tran", $"BdVUAF{new Guid()}");


        private static IConfiguration _configuration;

        public static string Configuration(string key)
        {
            string value = "";

            {
                if (_configuration == null)
                {

                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory()
                        )
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

                    _configuration = builder.Build();
                }

                value = _configuration[key];
                return value;
            }
        }
        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }

    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 5/12/2023
    /// Descripcion: Clase modelo para obtener resultados de funciones de forma generica
    /// </summary>
    public class StatusInfo 
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        #endregion

        #region "Propiedades"

        /// <summary>
        /// 
        /// </summary>
        public bool isOK { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public object data { get; set; } = null;
        #endregion

        #region "Funciones"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 5/12/2023
        /// </summary>
        /// <param name="error"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public StatusInfo SendStatus(int error, string text) => new StatusInfo { isOK = (error != 0 ? false : true), errorCode = error, message = text };


        

        
        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }
}
