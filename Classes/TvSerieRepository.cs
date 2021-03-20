using System.Collections.Generic;
using Series.Interfaces;

namespace Series
{
    public class TvSerieRepository : IRepository<TvSerie>
    {

        private List<TvSerie> TvSeriesList = new List<TvSerie>();
        public void Delete(int Id)
        {
            TvSeriesList[Id].Delete();
        }

        public void Insert(TvSerie entity)
        {
            TvSeriesList.Add(entity);

        }

        public List<TvSerie> List()
        {
            return TvSeriesList;
        }

        public int NextId()
        {
            return TvSeriesList.Count;
        }

        public TvSerie ReturnsById(int Id)
        {
            return TvSeriesList[Id];
        }

        public void Update(int Id, TvSerie entity)
        {

            TvSeriesList[Id] = entity;
        }
    }
}