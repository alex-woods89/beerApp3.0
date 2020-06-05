using BeerApp.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace BeerApp.Services
{
    public class BeerService
    {
        private readonly IMongoCollection<Beer> _beers;

        public BeerService(IBeerDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _beers = database.GetCollection<Beer>(settings.BeerCollectionName);
        }

        public List<Beer> Get() =>
            _beers.Find(beer => true).ToList();

        public Beer Get(string id) =>
            _beers.Find<Beer>(beer => beer.objectid == id).FirstOrDefault();

        public Beer Create(Beer beer)
        {
            _beers.InsertOne(beer);
            return beer;
        }

        public void Update(string id, Beer beerIn) =>
            _beers.ReplaceOne(beer => beer.objectid == id, beerIn);

        public void Remove(Beer beerIn) =>
            _beers.DeleteOne(beer => beer.objectid == beerIn.objectid);

        public void Remove(string id) =>
            _beers.DeleteOne(beer => beer.objectid == id);
    }
}
