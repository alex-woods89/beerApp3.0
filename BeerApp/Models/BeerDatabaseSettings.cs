namespace BeerApp.Models
{
    public class BeerDatabaseSettings : IBeerDatabaseSettings
    {
        public string BeerCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
