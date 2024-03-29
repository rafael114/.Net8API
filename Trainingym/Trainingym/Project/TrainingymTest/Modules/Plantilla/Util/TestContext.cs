using BdV.Project.Base;
using Microsoft.EntityFrameworkCore;
using Project.Base;
using Test.Project.Model;

namespace Project.Util
{
    /// <summary>
    /// 
    /// </summary>
    public class TestContext(bool isSQLServer) : DbContext
    {
        #region "Constantes"
        #endregion

        #region "Variables"
        public string dbPath = $"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Test.sqlite")}";
        #endregion

        #region "Propiedades"

        public DbSet<Member_Model> members { get; set; }
        public DbSet<Product_Model> products { get; set; }
        public DbSet<Order_Model> orders { get; set; }


        #endregion

        #region "Funciones"

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (isSQLServer)
            {
                optionsBuilder.UseSqlServer(HelperResponse.Configuration("cnxSQLSERVER"));
            }
            else
            {
                optionsBuilder.UseSqlite(HelperResponse.Configuration(dbPath));
            }
             
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
