namespace Trainingym.Project.TrainingymTest.Modules.Plantilla.Model
{
    public class Json_Model
    {        
        /// <summary>
        /// 
        /// </summary>
        public int postId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string body { get; set; }        

    }

    /// <summary>
    /// 
    /// </summary>
    public class CommentCount_Model 
    {
        /// <summary>
        /// 
        /// </summary>
        public int postId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int commentCount { get; set; }
    }
}
