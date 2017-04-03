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
    public partial class TodoNewPage : ContentPage
    {
        public Todo Item { set; get; }
        public TodoNewPage()
        {
            Item = new Todo();
            InitializeComponent();
            BindingContext = Item;
        }
        

        private void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send<Todo>(this.Item, "newitem");
            Navigation.PopAsync();
        }
    }
    
}
