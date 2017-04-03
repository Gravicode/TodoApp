using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;
using TodoApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoListPage : ContentPage
    {
        TodoViewModel vm { set; get; }
        public TodoListPage()
        {
            vm = new TodoViewModel();
            InitializeComponent();
            BindingContext = vm;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (vm.Items.Count == 0)
                vm.GetItems.Execute(null);
        }
        void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
            => ((ListView)sender).SelectedItem = null;

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
                return;

            //await DisplayAlert("Selected", e.SelectedItem.ToString(), "OK");
            var item = e.SelectedItem as Todo;
            await Navigation.PushAsync(new TodoEditPage(item));

            //Deselect Item
            //((ListView)sender).SelectedItem = null;
        }
        
        

        private async void NewItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TodoNewPage());
        }
    }

    
    
}
