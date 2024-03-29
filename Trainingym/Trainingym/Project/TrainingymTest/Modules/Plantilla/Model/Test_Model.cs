using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Project.Model
{
    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 28/3/2024
    /// Descripcion: Clase con entidades de la base de datos
    /// </summary>
    /// 
	public class Member_Model
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        #endregion

        #region "Propiedades"

        /// <summary>
        /// 
        /// </summary>
        /// 
        [Key]
        public long id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [MaxLength(500)]
		public string name { get; set; }

		#endregion

		#region "Funciones"
		#endregion

		#region "Metodos o Constructores"
		#endregion

		#region "Destructores"
		#endregion
	}

    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 28/3/2024
    /// Descripcion: Clase con modelo tipo plantilla para modelo de pruebavuel
    /// </summary>
    /// 
    public class Product_Model
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        #endregion

        #region "Propiedades"

        /// <summary>
        /// 
        /// </summary>
        /// 
        [Key]
        public long id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        [MaxLength(500)]
        public string name { get; set; }

        #endregion

        #region "Funciones"
        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }

    /// <summary>
    /// Autor: Rafael Zambrano
    /// Fecha: 28/3/2024
    /// Descripcion: Clase con modelo tipo plantilla para modelo de prueba
    /// </summary>
    /// 
    public class Order_Model
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        #endregion

        #region "Propiedades"
        /// <summary>
        /// 
        /// </summary>
        /// 
        [Key]
        public long id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// 
        
        public long memberId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long productId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        ///         
        public DateTime orderDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("memberId")]
        private Member_Model member { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("productId")]
        private Product_Model product { get; set; }
        #endregion

        #region "Funciones"
        #endregion

        #region "Metodos o Constructores"
        #endregion

        #region "Destructores"
        #endregion
    }
}
