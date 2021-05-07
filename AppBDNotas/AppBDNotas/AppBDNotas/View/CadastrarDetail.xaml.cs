using AppBDNotas.Model;
using AppBDNotas.ViewModel;
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
    public partial class CadastrarDetail : ContentPage
    {
        public CadastrarDetail()
        {
            InitializeComponent();
        }

        private void btSalvar_Clicked(object sender, EventArgs e)
        {
            try
            {
                ModelNota nota = new ModelNota();
                nota.Titulo = txtTitulo.Text;
                nota.Dados = txtDados.Text;
                nota.Favorito = swFavorito.IsToggled;
                ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);
                if(btSalvar.Text == "Inserir")
                {
                    dbNotas.Inserir(nota);
                    DisplayAlert("REsultado da operção", dbNotas.StatusMessage, "OK");
                }
                else
                {

                }
                MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
                p.Detail = new NavigationPage(new HomeDetail());
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        private void btCancelar_CLicked(object sender, EventArgs e)
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new HomeDetail());
        }
    }
}