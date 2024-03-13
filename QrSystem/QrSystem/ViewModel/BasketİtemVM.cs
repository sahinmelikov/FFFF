using System.ComponentModel.DataAnnotations;

namespace QrSystem.ViewModel
{
    public class BasketİtemVM
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
   
        public string Description { get; set; }
       
        public double Price { get; set; }
        public string TableName { get; set; }
        public int QrCodeId { get; set; }
        public int ProductId { get; set; }
   
        public bool IsApproved { get; set; }
        public string ImagePath { get; set; }
   
        public int ProductCount { get; set; }
    }
}
