namespace Sit.Intranet.ViewModel
{
    public class Page
    {
        public Page(string title) : this(title, null)
        {
        }

        public Page(string title, Page parent)
        {
            Parent = parent;
            Title = title;
        }

        public Page Parent
        {
            get; private set; 
        }

        public string Title { get; private set; }
    }
}