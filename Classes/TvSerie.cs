namespace Series
{
    public class TvSerie : BaseEntity
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }
        private bool Deleted { get; set; }
        public TvSerie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string text = "";
            text += "Gender: " + this.Genre + "\n";
            text += "Title: " + this.Title + "\n";
            text += "Description: " + this.Description + "\n";
            text += "Year: " + this.Year + "\n";
            text += "Deleted: " + this.Deleted + "\n";
            return text;
        }

        public string getTitle()
        {
            return this.Title;
        }
        public int getId()
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