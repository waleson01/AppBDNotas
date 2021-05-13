using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBDNotas.ViewModel;

namespace AppBDNotas.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListarDetail : ContentPage
    {
        public ListarDetail()
        {
            InitializeComponent();
            AtualizaLista();
        }

        public void AtualizaLista()
        {
            ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);
            ListaNotas.ItemsSource = dbNotas.Listar();
        }
    }
}