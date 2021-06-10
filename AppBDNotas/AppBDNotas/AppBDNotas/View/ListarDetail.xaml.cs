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

        private void SwFavorito_Toggle(object sender, ToggledEventArgs e)
        {
            //criação do objeto da classe SErvicesBDNota
            ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);

            //açaõ de quando do control switch estiver selecionado
            if (swFavorito.IsToggled)
            {
                ListaNotas.ItemsSource = dbNotas.ListarFavoritos();
            }
            else //ação de qdo do control switch NÃO estiver selecionado
            {
                //faz a busca pela lista inteira
                AtualizaLista();
            }
        }

        private void BtLocalizar_Clicked(object sender, EventArgs e)
        {
            String titulo = ""; //captura do texto da busca
            if (txtNota.Text != null) titulo = txtNota.Text;
            ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);

            //chamada do metodo de busca por título da nota
            ListaNotas.ItemsSource = dbNotas.Localizar(titulo);
            txtNota.Text = ""; //limpa o Text
        }

        private void BtTodos_Clicked(object sender, EventArgs e)
        {
            //retorna a lista inteira
            AtualizaLista();
        }
    }
}