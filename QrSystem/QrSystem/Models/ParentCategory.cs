using QrSystem.Models.BaseId;

namespace QrSystem.Models
{
    public class ParentCategory:Base
    {
        public string Name { get; set; }
       public bool Isactive {  get; set; }
        public List<Product> Products { get; set; }
       
    }
}
