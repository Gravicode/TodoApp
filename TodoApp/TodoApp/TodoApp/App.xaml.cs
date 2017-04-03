using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TodoApp.Helpers;
using TodoApp.Models;
using TodoApp.Views;
using Xamarin.Forms;

namespace TodoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //we will use sqlite first
            DependencyService.Register<RestEngine<Todo>>();
            MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new TodoListPage())
                    {
                        Title = "My Todos"

                    }
                }
            };


            //new TodoApp.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
