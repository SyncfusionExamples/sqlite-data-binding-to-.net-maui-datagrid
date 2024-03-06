namespace DataGridMAUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            dataGrid.ItemsSource = await App.Database.GetDealerInfosAsync();            
        }
    }

}
