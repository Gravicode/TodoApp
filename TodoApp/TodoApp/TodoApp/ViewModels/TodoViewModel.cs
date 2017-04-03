using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Helpers;
using TodoApp.Models;
using TodoApp.Views;
using Xamarin.Forms;

namespace TodoApp.ViewModels
{
    public class TodoViewModel:INotifyPropertyChanged
    {
        public IDataStore<Todo> engine { set; get; }
        public ObservableCollection<Todo> Items { set; get; }
        public Command GetItems { set; get; }

        private bool _IsBusy;

        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; OnPropertyChanged(); }
        }

        public TodoViewModel()
        {
            Items = new ObservableCollection<Todo>();
            engine = DependencyService.Get<IDataStore<Todo>>();
            GetItems = new Command(()=>GetData());
            
            MessagingCenter.Subscribe<Todo>(this, "newitem", async (item) =>
            {
                var _item = item as Todo;
                Items.Add(_item);
                await engine.InsertData(_item);
            });
            MessagingCenter.Subscribe<Todo>(this, "updateitem", async (item) =>
            {
                var _item = item as Todo;
                await engine.UpdateData(_item.Id.ToString(),_item);
                GetData();


            });
        }

        public async void GetData()
        {
            if (IsBusy) return;
            try
            {
                IsBusy = true;
                var temp = await engine.GetItems();
                if (temp != null)
                {
                    Items.Clear();
                    foreach (var item in temp)
                    {
                        Items.Add(item);
                    }
                }
            }
            finally
            {
                IsBusy = false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
