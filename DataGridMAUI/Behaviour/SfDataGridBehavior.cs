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
            dataGrid.CellTapped += OnDataGridCellTapped;
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
            dataGrid = null;
        }
    }
}
