using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppBDNotas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
   
    public partial class PageMenu : MasterDetailPage
    {
        public PageMenu()
        {
            InitializeComponent();
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomeDetail)));
        }

        private async void Open_Home(object sender, EventArgs e)
        {
            try
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(HomeDetail)));
                //ocultar o Menu
                IsPresented = false;
            }
            catch(Exception ex)
            {
                await DisplayAlert("OPS!", ex.Message, "OK!");
            }
        }

        private async void Open_Cadastrar(object sender, EventArgs e)
        {
            try
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(CadastrarDetail)));
                //ocultar o Menu
                IsPresented = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("OPS!", ex.Message, "OK!");
            }
        }

        private async void Open_listar(object sender, EventArgs e)
        {
            try
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ListarDetail)));
                //ocultar o Menu
                IsPresented = false;
            }
            catch (Exception ex)
            {
                await DisplayAlert("OPS!", ex.Message, "OK!");
            }
        }
    }
}