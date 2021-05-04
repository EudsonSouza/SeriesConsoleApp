using System;
namespace Series
{
    public class Serie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Deleted { get; set; }


        public Serie(int Id, Genre genre, string title, string description, int year)
        {
            this.Id = Id;
            this.Description = description;
            this.Genre = genre;
            this.Title = title;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string ret = Environment.NewLine;
            ret += "Genre: " + this.Genre + Environment.NewLine;
            ret += "Title: " + this.Title + Environment.NewLine;
            ret += "Description: " + this.Description + Environment.NewLine;
            ret += "Realease Year: " + this.Description + Environment.NewLine;
            return ret;
        }
        public string GetTitle()
        {
            return this.Title;
        }
        public int GetId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.Deleted = true;
        }

        public bool isDeleted()
        {
            return this.Deleted;
        }
    }
}