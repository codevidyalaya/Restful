namespace Restful_API.Models.Entities.LocalUsers
{
    public class LocalUser:BaseEntity
    {
        public string Name { get; set; }
        public string UserName { get; set; }        
        public string Password { get; set; }
        public int LocalUserRoleId { get; set; }
        public  LocalUserRole LocalUserRole { get; set; }
    }
}
