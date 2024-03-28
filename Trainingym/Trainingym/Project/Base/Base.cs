using BdV.Project.Base;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace Project.Base
{
    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 23/11/2023
    /// Descripcion: Clase controladora con funciones genericas de respuestas Http personalizables
    /// </summary>
    public class BaseController : ControllerBase 
    {
        #region "Constantes"

        /// <summary>
        /// 
        /// </summary>
        public string BASEDIR = AppDomain.CurrentDomain.BaseDirectory;
        #endregion

        #region "Variables"

        /// <summary>
        /// propiedad generica para respuestas de servicios
        /// </summary>
        public int statusCode { get; set; } = 200;

        /// <summary>
        /// propiedad generica para el envio de informacion en las respuestas de servicios
        /// </summary>
        public object data { get; set; } = null;

        /// <summary>
        /// 
        /// </summary>
        public AnonymousResponse_Model response { get; set; } = new AnonymousResponse_Model();
        #endregion

        #region "Propiedades"
        #endregion

        #region "Funciones"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 23/11/2023
        /// Descripcion: Funcion generica para retornar una respuesta con un status personalizado con un objeto anonimo como parametro
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual IActionResult GenericReturnReponse(int statusCode, object data) => StatusCode(statusCode, data);


        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 23/11/2023
        /// Descripcion: Funcion generica para retornar una respuesta con un status personalizado con un objeto anonimo como parametro
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual IActionResult GenericReturnReponse() => StatusCode(statusCode, data);

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 24/11/2023
        /// Descripcion: Funcion generica para retornar una respuesta con un status personalizado con un objeto anonimo como parametro
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual IActionResult GenericReturnResponse(AnonymousResponse_Model model) => StatusCode(model.getStatus, Helper.SerializeObject(model));


        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 24/11/2023
        /// Descripcion: Funcion generica para retornar una respuesta con un status personalizado con un objeto anonimo como parametro
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected virtual IActionResult GenericReturnResponse() => StatusCode(statusCode, response.data);
        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }

    /// <summary>
    /// 
    /// </summary>
    public class AnonymousResponse_Model
    {
        #region "Constantes"
        #endregion

        #region "Variables"                
        #endregion

        #region "Propiedades"

        /// <summary>
        /// propiedad para definir Codigos Http de la respuesta
        /// </summary>
        ///                
        private int statusCode { get; set; }

        /// <summary>
        /// Propiedad para retornar codigos de error en el objeto de respuesta
        /// </summary>
        public int errorCode { get; set; }

        /// <summary>
        /// Propiedad para retornar mensajes en el objeto de respuesta
        /// </summary>
        public string message { get; set; }

        /// <summary>
        /// Propiedad para retornar objetos en el objeto de respuesta
        /// </summary>
        public object data { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public string getJson
        {
            get
            {
                return Helper.SerializeObject(data);
            }
        }

        [JsonIgnore]
        public int getStatus 
        {
            get 
            {
                return statusCode;
            }
        }
  
        #endregion

        #region "Funciones"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 30/11/2023
        /// Descripcion: Funcion para retornar respuesta http OK generica
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public void SendResponseOK(int errorCode = 0, string message = "", object data = null)
        {
            statusCode = 200;
            this.errorCode = errorCode;
            this.message = message;
            this.data = data;
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 13/12/2023
        /// Descripcion: Funcion para retornar respuesta http InternalServerError generica
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        public void SendError(int errorCode = 0, string message = "", object data = null)
        {
            statusCode = 500;
            this.errorCode = errorCode;
            this.message = message;
            this.data = data;
        }

        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }
}
