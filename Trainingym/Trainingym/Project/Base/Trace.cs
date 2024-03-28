
using Project.Base;

namespace Project.Trace
{
    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 24/11/2023
    /// Descripcion: Clase para la declaracion de funcionalidades de trazabilidad y escritura de logs del sistema
    /// </summary>
    public static class Trace_Class
    {
        #region "Constantes"
        #endregion

        #region "Variables"

        #endregion

        #region "Propiedades"
        #endregion

        #region "Funciones"


        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 27/11/2023
        /// Descripcion: Sobrecarga de la funcion la cual puede indicar si imprimir un archivo de traza y espeficiar el nombre del archivo si es deseado
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static async void Trace(string body)
        {
            try
            {
                body = $"\n {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n{body}";
                
                PrintFile(body);
                
            }
            catch (Exception ex)
            {
                return;
            }            
        }
        
        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 27/11/2023
        /// Descripcion: Sobrecarga de la funcion la cual puede indicar si imprimir un archivo de traza y espeficiar el nombre del archivo si es deseado
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public static async void Trace(string body, string fileName = "", bool isPrintFile = true)
        {
            try
            {
                body = $"\n {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}\n{body}";

                if (isPrintFile)
                {
                    PrintFile(body, fileName);
                }
            }
            catch (Exception ex)
            {
                return;
            }            
        }

        /// <summary>
        /// Autor: Rafael Zambrano
        /// Fecha: 24/11/2023
        /// Descripcion: Funcion para la impresion de archivo de traza
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="body"></param>
        public static void PrintFile(string body,  string fileName = "BdV-UAF.txt", bool isPrint = true)
        {
            BaseController baseController = new BaseController();
            string fileBody = "";
            string fileDir = $@"{baseController.BASEDIR}{(baseController.BASEDIR.Contains("\\") ? "\\" : "//")}ErrorLog{(baseController.BASEDIR.Contains("\\") ? "\\" : "//")}{fileName}";
            try
            {
                if (!Directory.Exists($@"{baseController.BASEDIR}{(baseController.BASEDIR.Contains("\\") ? "\\" : "//")}ErrorLog"))
                {
                    Directory.CreateDirectory($@"{baseController.BASEDIR}{(baseController.BASEDIR.Contains("\\") ? "\\" : "//")}ErrorLog");
                }
                else if (!File.Exists(fileDir))
                {
                    File.Create(fileDir);
                }
                
                using (StreamReader sr = new StreamReader(fileDir))
                { 
                    fileBody = sr.ReadToEnd();                    
                }

                using (StreamWriter wr = new StreamWriter(fileDir))
                {
                    wr.Write(fileBody + body);
                    wr.Flush();
                    wr.Close();
                }
            }
            catch (Exception ex)
            {
                return;
            }
        }
        #endregion

        #region "Metodos o Constructores"

        #endregion

        #region "Destructores"

        #endregion
    }
}
