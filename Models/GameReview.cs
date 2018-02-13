namespace WpfExcelInteraction.Models
{
    /// <summary>
    /// A small class containing two strings, one for the game's title and one for its review.
    /// </summary>
    public class GameReview
    {
        private string title;
        private string review;

        public GameReview(string title, string review)
        {
            this.title = title;
            this.review = review;
        }

        public string Title
        {
            get => title;
            set => title = value;
        }

        public string Review
        {
            get => review;
            set => review = value;
        }
    }
}
