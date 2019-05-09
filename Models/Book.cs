namespace console_library.Models
{
    class Book
    {
        public string Title { get; private set; }
        public string Author { get; private set; }
        public bool Available { get; set; }


        //Properties
        // public string Title { get; set;}
        // public string Author { get; set;}
        // public bool Available {get; set;}
         public Book(string title, string author, bool available = true)
        {
            Title = title;
            Author = author;
            Available = true;
        }
    }
}