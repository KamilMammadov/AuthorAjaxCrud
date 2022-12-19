namespace DemoApplication.Areas.Client.ViewModels.Basket
{
    public class BookViewModel
    {
     

        public int Id { get; set; }
        public string Title { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public BookViewModel(int id, string title, string imgUrl, decimal price, int quantity, decimal total)
        {
            Id = id;
            Title = title;
            ImgUrl = imgUrl;
            Price = price;
            Quantity = quantity;
            Total = total;
        }
    }
}
