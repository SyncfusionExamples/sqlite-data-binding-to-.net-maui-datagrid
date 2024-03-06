using System.Collections.ObjectModel;
using System.ComponentModel;

namespace DataGridMAUI
{
    public class DealerInfoViewModel : INotifyPropertyChanged
    {
        #region Fields

        private ObservableCollection<DealerInfo> dealersInfo;
        private DealerInfo selectedDealerInfo;

        #endregion

        #region Properties
        public DealerInfo SelectedItem
        {
            get
            {
                return selectedDealerInfo;
            }
            set
            {
                selectedDealerInfo = value;
                OnPropertyChanged("SelectedItem");
            }
        }
        public ObservableCollection<DealerInfo> DealersInfo
        {
            get
            {
                return dealersInfo;
            }
            set
            {
                dealersInfo = value;
                OnPropertyChanged("DealersInfo");
            }
        }

        #endregion

        public Command CreateDealerInfoCommand { get; set; }
        public Command<object> EditDealerInfoCommand { get; set; }
        public Command SaveItemCommand { get; set; }
        public Command DeleteItemCommand { get; set; }
        public Command AddItemCommand { get; set; }

        #region Constructor
        public DealerInfoViewModel()
        {
            GenerateContacts();
            CreateDealerInfoCommand = new Command(OnCreateDealerInfo);
            EditDealerInfoCommand = new Command<object>(OnEditDealerInfo);
            SaveItemCommand = new Command(OnSaveItem);
            DeleteItemCommand = new Command(OnDeleteItem);
            AddItemCommand = new Command(OnAddNewItem);
        }
        #endregion

        #region Methods

        private async void GenerateContacts()
        {
            DealersInfo = new ObservableCollection<DealerInfo>();
            DealersInfo = new DealerInfoRepository().GetDealerDetails(20);
            PopulateDB();
        }

        private async void PopulateDB()
        {
            foreach (DealerInfo dealerInfo in DealersInfo)
            {
                var item = await App.Database.GetDealerInfoAsync(dealerInfo);
                if (item == null)
                    await App.Database.AddDealerInfoAsync(dealerInfo);
            }
        }
        private async void OnAddNewItem()
        {
            await App.Database.AddDealerInfoAsync(SelectedItem);
            DealersInfo.Add(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnDeleteItem()
        {
            await App.Database.DeleteDealerInfoAsync(SelectedItem);
            DealersInfo.Remove(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private async void OnSaveItem()
        {
            await App.Database.UpdateDealerInfoAsync(SelectedItem);
            await App.Current.MainPage.Navigation.PopAsync();
        }

        private void OnEditDealerInfo(object obj)
        {
            SelectedItem = (obj as Syncfusion.Maui.DataGrid.DataGridCellTappedEventArgs).RowData as DealerInfo;
            var editPage = new Views.EditPage();
            editPage.BindingContext = this;
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }

        private void OnCreateDealerInfo()
        {
            SelectedItem = new DealerInfo() { DealerName = "", DealerImage = "" };
            var editPage = new Views.EditPage();
            editPage.BindingContext = this;
            App.Current.MainPage.Navigation.PushAsync(editPage);
        }

        #endregion

        #region Interface Member

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string name)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
