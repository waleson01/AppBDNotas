using AppBDNotas.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBDNotas
{
    public partial class App : Application
    {
        public static String DbName; 
        public static String DbPath;

        public App()
        {
            InitializeComponent();

            MainPage = new PageMenu();
        }

        //Metodo construtor recebendo o local e o nome do BD
        public App(string dbPath, string dbName)
        {
            InitializeComponent();
            //armazenando os valores nas propriedades publicas(globais)
            App.DbName = dbName;
            App.DbPath = dbPath;
            MainPage = new PageMenu();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
