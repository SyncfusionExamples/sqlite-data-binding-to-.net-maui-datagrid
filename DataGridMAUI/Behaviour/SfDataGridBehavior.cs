using Syncfusion.Maui.DataGrid;
namespace DataGridMAUI
{
    public class SfDataGridBehavior : Behavior<SfDataGrid>
    {
        SfDataGrid dataGrid;
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);
            dataGrid = bindable as SfDataGrid;
            dataGrid.AutoGeneratingColumn += OnAutoGeneratingColumn;
            dataGrid.CellTapped += OnDataGridCellTapped;
        }

        private void OnAutoGeneratingColumn(object? sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column != null)
            {
                if (e.Column.MappingName == "ID")
                    e.Cancel = true;
                else if (e.Column.MappingName == "ProductID")
                {
                    e.Column.HeaderText = "Product ID";
                    e.Column.Format = "D";
                }
                else if (e.Column.MappingName == "IsOnline")
                    e.Column.HeaderText = "Is Online";
                else if (e.Column.MappingName == "ProductNo")
                {
                    e.Column.HeaderText = "Product No";
                    e.Column.Format = "D";
                }
                else if (e.Column.MappingName == "DealerName")
                    e.Column.HeaderText = "Dealer Name";
                else if (e.Column.MappingName == "ProductPrice")
                    e.Column.HeaderText = "Product Price";
                else if (e.Column.MappingName == "ShippedDate")
                    e.Column.HeaderText = "Shipped Date";
                else if (e.Column.MappingName == "ShipCountry")
                    e.Column.HeaderText = "Ship Country";
                else if (e.Column.MappingName == "ShipCity")
                    e.Column.HeaderText = "Ship City";


            }
        }

        private void OnDataGridCellTapped(object? sender, DataGridCellTappedEventArgs e)
        {
            var bindingContext = dataGrid.BindingContext as DealerInfoViewModel;
            if (bindingContext != null)
            {
                bindingContext.EditDealerInfoCommand.Execute(e);
            }
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            base.OnDetachingFrom(bindable);
            dataGrid.CellTapped -= OnDataGridCellTapped;
            dataGrid.AutoGeneratingColumn -= OnAutoGeneratingColumn;
            dataGrid = null;
        }
    }
}
