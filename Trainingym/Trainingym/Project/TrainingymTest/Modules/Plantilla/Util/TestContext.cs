using BdV.Project.Base;
using Microsoft.EntityFrameworkCore;
using Test.Project.Model;

namespace Project.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class TestContext : DbContext
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        #endregion

        #region "Propiedades"

        public DbSet<Member_Model> members { get; set; }
        public DbSet<Product_Model> products { get; set; }
        public DbSet<Order_Model> orders { get; set; }


        #endregion

        #region "Funciones"

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(HelperResponse.Configuration("cnxSQLSERVER")); 
        }
        #endregion

        #region "Metodos & constructores"

        #endregion

        #region "Eventos"
        #endregion

        #region "Destructor"

        #endregion
    }
}
