using System;
using FindStock.View;
using Xamarin.Forms;

namespace FindStock
{
    public partial class MainView : ContentPage
    {
        // internal ListViewPageViewModel Vm { get; set; }



        public MainView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);//1st.Pageのバーを消す


            //var model = new YourModel();
            //BindingContext = model;

            var model = new ListViewPageViewModel();
            BindingContext = model;

            var tapRec = new TapGestureRecognizer();
            image1.GestureRecognizers.Add(tapRec);
            image2.GestureRecognizers.Add(tapRec);
            image3.GestureRecognizers.Add(tapRec);
            image4.GestureRecognizers.Add(tapRec);
            image5.GestureRecognizers.Add(tapRec);

            tapRec.Tapped += (sender, e) =>
            {
                // タップされた Image に応じて Model.SelectedIndex を設定
                if (object.ReferenceEquals(sender, image1)) { model.SelectedIndex = 1; }
                else if (object.ReferenceEquals(sender, image2)) { model.SelectedIndex = 2; }
                else if (object.ReferenceEquals(sender, image3)) { model.SelectedIndex = 3; }
                else if (object.ReferenceEquals(sender, image4)) { model.SelectedIndex = 4; }
                else if (object.ReferenceEquals(sender, image5)) { model.SelectedIndex = 5; }
            };



        }



        public void OnEdit(object sender, EventArgs e)
        {

            var newPage = new ContentPage();
            Navigation.PushAsync(newPage);

            var poppedPage = Navigation.PopAsync();


            var usercode = new Entry { Placeholder = "Code", Keyboard = Keyboard.Text, };



            //mi.CommandParameter as ContactHistoryItem

            MenuItem mi = ((MenuItem)sender);
            var par = mi.CommandParameter;
            var selectedText = this.DisplayActionSheet("Edit", "Close", "Chancel", new string[] { "qqqq", "すいか", "ぶどう" });

            if (selectedText != null)
            {
                //buttonDialog2.Text = selectedText;
            }

            DisplayAlert("Edit Context Action", e.ToString() + " edit context action", "OK");

            //ListViewPageViewModel.OnLabelClicked(mi);


        }


        internal void CanselCommand(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new EntryPage(sender, e));
            var mi = ((MenuItem)sender);

            //var itemindex = mi.CommandParameter;
            var itemindex = ((Price)mi.CommandParameter).Idindex;
            DisplayAlert("CanselCOmmand Context Action", itemindex + " cansel context action", "OK");
        }



        internal void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            var mi = ((MenuItem)sender);
            var option = mi.Text;

            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            DisplayAlert("Item Selected", e.SelectedItem.ToString(), "Ok");
            //((ListViewPage)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.

        }


        /// <summary>
        /// ListViewの項目選択時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new EntryPage(sender, e));

        }


        /// <summary>
        /// 項目タップ時に呼ばれる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            //this.Navigation.PushAsync(new EntryPage(e));
            //Navigation.PopAsync();
            //DisplayAlert("Item Tapped", item.ToString(), "Ok");

        }

    }

}
