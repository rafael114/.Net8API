using Test.Project.BLL;
using Test.Project.Model;
using Microsoft.AspNetCore.Mvc;
using Project.Base;
using Project.Util;

namespace Test.Project.Controller
{
    /// <summary>
    /// Autor: *Autor de la clase*
    /// Fecha: *Fecha de creacion de la clase*
    /// Descripcion: *breve descripcion del funcionamiento de la clase*
    /// </summary>
    /// 
    [ApiController]
    [Route("/Api/V1/Test")]
    public class Test_Controller : BaseController
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        #endregion

        #region "Propiedades"
        #endregion

        #region "Funciones"

        #region "GET"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: Crea base de datos con modelos de entidades actuales
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("CreateDb")]
        public async Task<IActionResult> CreateDb() 
        {
            Plantilla_BLL bll = new Plantilla_BLL();
            response = bll.CreateDB().Result;


            return GenericReturnResponse(response);
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: Crea base de datos con modelos de entidades actuales
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("userLastOrder")]
        public async Task<IActionResult> userLastOrder(long member)
        {
            Plantilla_BLL bll = new Plantilla_BLL();
            response = bll.UserlastOrder(member).Result;


            return GenericReturnResponse(response);
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: Consulta endpoint de JsonPlaceholder y devuelve los objetos con el id mas repetido
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("JsonManipulation")]
        public async Task<IActionResult> JsonManipulation()
        {
            Plantilla_BLL bll = new Plantilla_BLL();
            response = bll.JsonManipulation().Result;


            return GenericReturnResponse(response);
        }



        #endregion

        #region "POST"


        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: inserta informacion de pruebas en base de datos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("LoadDemoInfo")]
        public async Task<IActionResult> LoadDemoInfo(string product = "", string member = "")
        {
            Plantilla_BLL bll = new Plantilla_BLL();
            response = new AnonymousResponse_Model();

            response = bll.LoadDemoInfo(product, member).Result;

            return GenericReturnResponse(response);

        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: inserta informacion de pruebas en base de datos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("LoadOrder")]
        public async Task<IActionResult> loadOrder(long product, long member)
        {
            Plantilla_BLL bll = new Plantilla_BLL();
            response = new AnonymousResponse_Model();

            response = bll.LoadOrderInfo(member, product).Result;

            return GenericReturnResponse(response);

        }
        #endregion

        #region "PUT"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: actualiza base de datos con modelos de entidades actuales
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateDb")]
        public async Task<IActionResult> UpdateDb()
        {
            Plantilla_BLL bll = new Plantilla_BLL();
            response = new AnonymousResponse_Model();

            response = bll.UpdateDb().Result;

            return GenericReturnResponse(response);

        }
        #endregion

        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }

}
