namespace QrSystem.Models
{
    public class Ofisant
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public Restorant Restorant { get; set; }
        public int? RestorantId { get; set; }
        public List<RestourantTables>RestourantTables { get; set; } 
    }
}
