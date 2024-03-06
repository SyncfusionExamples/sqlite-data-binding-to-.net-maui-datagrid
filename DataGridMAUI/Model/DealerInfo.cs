using SQLite;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataGridMAUI
{
    public class DealerInfo : INotifyPropertyChanged
    {
        #region Fields

        private int productNo;

        private int productID;

        private string? dealerName;

        private bool isOnline;

        private int productprice;

        private string? dealerImage;

        private DateTime shippedDate;

        private string? shipCity;

        private string? shipCountry;

        #endregion

        [PrimaryKey, AutoIncrement]
        [Display(AutoGenerateField = false)]
        public int ID { get; set; }

        #region Public Properties

        /// <summary>
        /// Gets or sets the value of DealerImage and notifies user when value gets changed
        /// </summary>
        public string? DealerImage
        {
            get
            {
                return this.dealerImage;
            }

            set
            {
                this.dealerImage = value;
                this.RaisePropertyChanged("DealerImage");
            }
        }

        /// <summary>
        /// Gets or sets the value of ProductID and notifies user when value gets changed
        /// </summary>
        public int ProductID
        {
            get
            {
                return this.productID;
            }

            set
            {
                this.productID = value;
                this.RaisePropertyChanged("ProductID");
            }
        }

        /// <summary>
        /// Gets or sets the value of DealerName and notifies user when value gets changed
        /// </summary>
        public string? DealerName
        {
            get
            {
                return this.dealerName;
            }

            set
            {
                this.dealerName = value;
                this.RaisePropertyChanged("DealerName");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether property value IsOnline was true or false and notifies user when value gets changed
        /// </summary>
        public bool IsOnline
        {
            get
            {
                return this.isOnline;
            }

            set
            {
                this.isOnline = value;
                this.RaisePropertyChanged("IsOnline");
            }
        }

        /// <summary>
        /// Gets or sets the value of ProductPrice and notifies user when value gets changed
        /// </summary>
        public int ProductPrice
        {
            get
            {
                return this.productprice;
            }

            set
            {
                this.productprice = value;
                this.RaisePropertyChanged("ProductPrice");
            }
        }

        /// <summary>
        /// Gets or sets the value of ProductNo and notifies user when value gets changed
        /// </summary>
        public int ProductNo
        {
            get
            {
                return this.productNo;
            }

            set
            {
                this.productNo = value;
                this.RaisePropertyChanged("ProductNo");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShippedDate and notifies user when value gets changed
        /// </summary>
        public DateTime ShippedDate
        {
            get
            {
                return this.shippedDate;
            }

            set
            {
                this.shippedDate = value;
                this.RaisePropertyChanged("ShippedDate");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShipCountry and notifies user when value gets changed
        /// </summary>
        public string? ShipCountry
        {
            get
            {
                return this.shipCountry;
            }

            set
            {
                this.shipCountry = value;
                this.RaisePropertyChanged("ShipCountry");
            }
        }

        /// <summary>
        /// Gets or sets the value of ShipCity and notifies user when value gets changed
        /// </summary>
        public string? ShipCity
        {
            get
            {
                return this.shipCity;
            }

            set
            {
                this.shipCity = value;
                this.RaisePropertyChanged("ShipCity");
            }
        }

        #endregion

        #region InotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion
    }
}
