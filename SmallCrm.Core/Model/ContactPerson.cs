namespace SmallCrm.Core.Model
{
    public class ContactPerson
    {
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Firstname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Lastname { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public PossitionCategory Position { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Customer customer { get; set; }
    }
}
