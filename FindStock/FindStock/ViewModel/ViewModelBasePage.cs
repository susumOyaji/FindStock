using System.ComponentModel;

namespace FindStock
{
    /// <summary>
    /// ViewModelの基本クラス。INotifyPropertyChangedの実装を提供します。
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
       // int _selectedIndex;



        /// <summary>
        /// プロパティの変更があったときに発行されます。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// PropertyChangedイベントを発行します。
        /// </summary>
        /// <param name="propertyName">プロパティ名</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //public int SelectedIndex
        //{
        //    get { return _selectedIndex; }
        //    set
        //    {
        //        if (_selectedIndex == value)
        //            return;
        //        _selectedIndex = value;
        //        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedIndex)));
        //    }
        //}


    }
}