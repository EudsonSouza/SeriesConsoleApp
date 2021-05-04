using Series.Interfaces;
using System.Collections.Generic;


namespace Series
{
    public class SeriesRepository : IRepository<Serie>
    {
        private List<Serie> serieList = new List<Serie>();
        public void Delete(int id)
        {
            serieList[id].Delete();
        }

        public Serie GetById(int id)
        {
            return serieList[id];
        }

        public void Insert(Serie entity)
        {
            serieList.Add(entity);
        }

        public List<Serie> List()
        {
            return serieList;
        }

        public int NextId()
        {
            return serieList.Count;
        }

        public void Update(int id, Serie entity)
        {
            serieList[id] = entity;
        }
    }
}