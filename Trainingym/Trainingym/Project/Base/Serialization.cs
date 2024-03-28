using System.Data;
using Newtonsoft.Json;

namespace BdV.Project.Base
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class Helper 
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        #endregion

        #region "Propiedades"
        #endregion

        #region "Funciones"


        #region  "Serialize"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 4/12/2023
        /// Descripcion: Funcion para serializar un objeto anonimo a un string Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string SerializeObject(object obj)
        {
            string json = "";
            try
            {
                if (obj == null)
                {
                    return null;
                }

                json = JsonConvert.SerializeObject(obj, Formatting.None).Replace("\\", "");
            }
            catch (Exception ex)
            {
                json = null;
            }

            return json;
        }
        #endregion

        #region "Deserialize"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 4/12/2023
        /// Descripcion: Funcion para serializar un objeto anonimo a un string Json
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static T DeserializeObject<T>(string json)
        {
            T obj = default(T);
            try
            {
                if (json == null)
                {
                    return obj;
                }

                obj = JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                return obj;
            }

            return obj;
        }
        #endregion

        #region "DataConversion"

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 5/12/2023
        /// Descripcion: funcion para convertir una lista anonima en un objeto tipo dataset
        /// </summary>
        /// <returns></returns>
        public static  DataSet ConvertListToDataSet<T>(this List<T> list)
        {
            DataSet data = new DataSet();
            string json = "";
            
            try
            {
                json = SerializeObject(list);

                data = JsonConvert.DeserializeObject<DataSet>(json);
            }
            catch (Exception ex)
            {
               data = null;
            }

            return data;
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 5/12/2023
        /// Descripcion: funcion para convertir un objeto tipo dataset en una lista de un determinado modelo recibido como parametro
        /// </summary>
        /// <returns></returns>
        public static List<T> ConvertDataSetToList<T>(this DataSet data)
        {
            List<T> list = new List<T>();
            string json = "";

            try
            {
                json = SerializeObject(data);

                list = JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception ex)
            {
                data = null;
            }

            return list;
        }
        #endregion

        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }
}
