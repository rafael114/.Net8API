using System.Net;
using Test.Project.Model;
using Project.Base;
using Project.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore.Internal;

namespace Test.Project.BLL
{
    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 28/3/2024
    /// Descripcion: controlador desarrollado para la prueba de Trainingym
    /// </summary>
    public class Plantilla_BLL : BaseController
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
        /// Descripcion: Crea base de datos con modelo de entidades actuales
        /// </summary>
        /// <param name="isList"></param>
        /// <param name="isError"></param>
        /// <returns></returns>
        public async Task<AnonymousResponse_Model> CreateDB()
        {
            response = new AnonymousResponse_Model();
            try
            {
                using (var context = new TestContext())
                {
                    context.Database.EnsureCreated();
                }

            }
            catch (Exception ex)
            {
                response.data = "ocurrio una excepcion en la peticion";
                
            }
            return response;
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: Consulta ultima orden de un usuario en especifico
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task<AnonymousResponse_Model> UserlastOrder(long member)
        {
            Task<AnonymousResponse_Model> task = new Task<AnonymousResponse_Model>(() => 
            {
                response = new AnonymousResponse_Model();

                try
                {
                    using (var context = new TestContext())
                    {
                        var lastOrder = context.orders
                                               .Where(x => x.memberId == member)
                                               .OrderByDescending(x => x.orderDate)
                                               .Select(x => new {
                                                                    NroOrden = x.id,
                                                                    FechaPedido = x.orderDate,
                                                                    Miembro = x.memberId, 
                                                                    Producto = x.productId}).FirstOrDefault();

                        if (lastOrder == null)
                        {
                            response.SendError(-3, "Ha ocurrido un error en la peticion");
                        }
                        else
                        {
                            response.SendResponseOK(0, "", lastOrder);
                        }
                    }

                    
                }
                catch (Exception ex)
                {
                    response.data = "ocurrio una excepcion en la peticion";

                }

                return response;
                
            });
            task.Start();

            return await task;

        }
        #endregion

        #region "POST"        

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: Actualiza las entidades de la base de datos por metodo de migracion
        /// </summary>
        /// <param name="isList"></param>
        /// <param name="isError"></param>
        /// <returns></returns>
        public async Task<AnonymousResponse_Model> UpdateDb()
        {
            response = new AnonymousResponse_Model();
            try
            {
                
                using (var context = new TestContext())
                {                    
                    context.Database.Migrate();                                    
                }
            }
            catch (Exception ex)
            {
                response.data = "ocurrio una excepción en la petición";
            }
            return response;
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: Carga informacion de prueba en la base de datos
        /// </summary>
        /// <param name="product"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task<AnonymousResponse_Model> LoadDemoInfo(string product = "", string member = "")
        {
            response = new AnonymousResponse_Model();
            try
            {
                using (var context = new TestContext())
                {
                    if (member.IsNullOrEmpty() && product.IsNullOrEmpty())
                    {
                        response.SendError(-1, "Se debe cargar al menos un dato");

                        return response;
                    }

                    if (!member.IsNullOrEmpty())
                    {
                        Member_Model memberModel = new Member_Model
                        {
                            name = member
                        };

                        context.members.Add(memberModel);
                    }

                    if (!product.IsNullOrEmpty())
                    {
                        Product_Model productModel = new Product_Model
                        {
                            name = product
                        };

                        context.products.Add(productModel);
                    }

                    context.SaveChanges();
                }


                response.SendResponseOK(0, "Informacion cargada con exito");

            }
            catch (Exception ex)
            {
                response.data = "ocurrio una excepción en la petición";
            }
            return response;
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 28/3/2024
        /// Descripcion: Carga informacion de prueba en la base de datos
        /// </summary>
        /// <param name="product"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public async Task<AnonymousResponse_Model> LoadOrderInfo(long memberId, long productId)
        {
            response = new AnonymousResponse_Model();
            try
            {
                using (var context = new TestContext())
                {
                    if (memberId == null || memberId == 0)
                    {
                        response.SendError(-2, "ingrese un usuario valido");
                    }
                    else if (productId == null || productId == 0)
                    {
                        response.SendError(-2, "ingrese un producto valido");
                    }
                    else
                    {
                        context.orders.Add(new Order_Model
                        {
                            memberId = memberId
                            ,
                            productId = productId
                            ,
                            orderDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                        }); ;
                    }

                    context.SaveChanges();
                }


                response.SendResponseOK(0, "Informacion cargada con exito");

            }
            catch (Exception ex)
            {
                response.data = "ocurrio una excepción en la petición";
            }
            return response;
        }
        #endregion

        #region "PUT"
        #endregion




        #endregion

        #region "Metodos o Constructores"

        /// <summary>
        /// 
        /// </summary>
        public Plantilla_BLL()
        {

        }
        #endregion

        #region "Destructores"

        /// <summary>
        /// 
        /// </summary>
        ~Plantilla_BLL()
        {

        }
        #endregion
    }
}
