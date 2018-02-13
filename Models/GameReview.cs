namespace WpfExcelInteraction.Models
{
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
