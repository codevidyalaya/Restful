using System.ComponentModel.DataAnnotations;

namespace Restful_API.Models.Entities
{
    public class School : BaseEntity
    {       
        public string ContactPersonName { get; set; }      
        public string ContactPersonNumber { get; set; }
        public string ContactPersonEmail { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int State { get; set; }
        public int City { get; set; }
        public string PinCode { get; set; }
    }
}
