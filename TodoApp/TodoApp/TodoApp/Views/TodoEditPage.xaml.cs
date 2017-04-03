using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TodoApp.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoApp.Views
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TodoEditPage : ContentPage
    {
        public TodoEditPage(Todo item)
        {
            InitializeComponent();
            BindingContext = item;
        }

        private async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Todo>(this.BindingContext as Todo, "updateitem");
            await Navigation.PopAsync();
        }
    }

   
}
