using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppBDNotas.ViewModel;
using AppBDNotas.Model;

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

        private void ListaNotas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //crio um obejto nota quer irá receber todos os dados  o item selecionado da lista
            ModelNota nota = (ModelNota)ListaNotas.SelectedItem;
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new CadastrarDetail(nota));
        }
    }
}