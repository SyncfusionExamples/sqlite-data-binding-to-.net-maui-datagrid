# sqlite-data-binding-to-.net-maui-datagrid
In this article, we explain how to bind SQLite data to the .NET MAUI DataGrid (Syncfusion SfDataGrid) and keep the grid synchronized with your local database. The sample shows a simple pattern: a page-level BindingContext that provides commands and services, a Syncfusion SfDataGrid to visualize rows, and a SQLite repository (exposed via App.Database) that loads and persists records. The grid’s ItemsSource is assigned asynchronously in OnAppearing, ensuring the UI displays the latest data whenever the page becomes visible.

## xaml
```
<ContentPage.BindingContext>
    <local:DealerInfoViewModel x:Name="viewModel"/>
</ContentPage.BindingContext>

<ContentPage.Content>
    <Grid>
        <syncfusion:SfDataGrid x:Name="dataGrid"                                
                            NavigationMode="Cell"                               
                            GridLinesVisibility="Both" 
                            SelectionMode="Single"                               
                            HeaderGridLinesVisibility="Both">
            <syncfusion:SfDataGrid.Behaviors>
                <local:SfDataGridBehavior/>
            </syncfusion:SfDataGrid.Behaviors>
            <syncfusion:SfDataGrid.Columns>
                <syncfusion:DataGridImageColumn MappingName="DealerImage"
                                        HeaderText="Dealer Image" />
            </syncfusion:SfDataGrid.Columns>
        </syncfusion:SfDataGrid>
        <ImageButton Margin="20" CornerRadius="20" HeightRequest="40" WidthRequest="40"  Background="{StaticResource Primary}"
                                    VerticalOptions="End" HorizontalOptions="End"
                                Command="{Binding CreateDealerInfoCommand}" Source="add.png"/>

    </Grid>
</ContentPage.Content>
```

This page wires up a SfDataGrid and an ImageButton. The grid is configured with grid lines, single selection, and a DataGridImageColumn to render an image from the DealerImage field. The ImageButton invokes a command (CreateDealerInfoCommand) on the BindingContext to start creating a new item that will ultimately be saved to SQLite.

## C#
The code-behind ensures the grid is always populated with the latest data from SQLite when the page appears.
```
protected async override void OnAppearing()
{
    base.OnAppearing();
    dataGrid.ItemsSource = await App.Database.GetDealerInfosAsync();            
}
```
The call to App.Database.GetDealerInfosAsync() retrieves entities (e.g., DealerInfo models) from the local database. Assigning the result to ItemsSource binds the grid to the live data set. If you add, edit, or delete records elsewhere in the app and return to this page, OnAppearing will refresh the grid’s data.

## SQLite setup and data flow
- Data access: App.Database typically encapsulates an initialized SQLiteAsyncConnection and provides async CRUD methods such as GetDealerInfosAsync, AddDealerInfoAsync, UpdateDealerInfoAsync, and DeleteDealerInfoAsync.
- View model: DealerInfoViewModel exposes commands (e.g., CreateDealerInfoCommand) that navigate to an editor page or open a form, then persists the new record to SQLite via App.Database and optionally triggers a UI refresh.
- Refresh pattern: Because the grid is repopulated in OnAppearing, the latest rows are shown after any navigation back from the edit page. For real-time updates without leaving the page, bind the grid to an ObservableCollection and add/remove items in-memory alongside SQLite persistence.

##### Conclusion
 
I hope you enjoyed learning about how to bind SQLite data in .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!