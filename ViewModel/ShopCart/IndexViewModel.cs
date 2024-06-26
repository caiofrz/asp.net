namespace asp.net_mvc.ViewModel.ShopCart
{
    public class IndexViewModel
    {
        public string Title { get; set; }

        public Models.ShopCart ShopCart { get; set; }
        public double TotalValue { get; set; }

    }
}