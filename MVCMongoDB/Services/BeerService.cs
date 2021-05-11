using MongoDB.Driver;
using MVCMongoDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCMongoDB.Services
{
    public class BeerService
    {
        private IMongoCollection<Beer> _beers;

        public BeerService(IBarSettings settings)
        {
            var cliente = new MongoClient(settings.Server);
            var database = cliente.GetDatabase(settings.Database);
            _beers = database.GetCollection<Beer>(settings.Collection);
        }

        public List<Beer> GetAllBeers()
        {
            return _beers.Find(d => true).ToList();
        }

        public Beer CreateBeer(Beer beer)
        {
            _beers.InsertOne(beer);
            return beer;
        }

        public void UpdateBeer(string id, Beer beer)
        {
            _beers.ReplaceOne(beer => beer.Id == id, beer);
        }

        public void DeleteBeer(string id)
        {
            _beers.DeleteOne(d => d.Id == id);
        }
    }
}
