namespace BeerApp.Models
{
    public interface IBeerDatabaseSettings
    {
        string BeerCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}