namespace MauiApp2;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        var shopl = (ShopList)BindingContext;
        listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
    }

    async void OnSaveButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        slist.Date = DateTime.UtcNow;
        await App.Database.SaveShopListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        var slist = (ShopList)BindingContext;
        await App.Database.DeleteShopListAsync(slist);
        await Navigation.PopAsync();
    }

    async void OnChooseButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProductPage((ShopList)this.BindingContext)
        {
            BindingContext = new Product()
        });
    }

    async void OnDeleteItemClicked(object sender, EventArgs e)
    {
        Product product = listView.SelectedItem as Product;
        var shopList = (ShopList)BindingContext;

        if (product != null)
        {
            await App.Database.DeleteListProductAsync(shopList.ID, product.ID);
            
            listView.ItemsSource = await App.Database.GetListProductsAsync(shopList.ID);
        }
        else
        {
            await DisplayAlert("Error", "Please select a product to delete", "OK");
        }
    }
}