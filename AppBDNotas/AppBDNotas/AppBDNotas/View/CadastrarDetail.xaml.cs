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
        int id;
        public CadastrarDetail()
        {
            InitializeComponent();
        }

        public CadastrarDetail(ModelNota nota)
        {
            InitializeComponent();
            btSalvar.Text = "Alterar";

            btExcluir.IsVisible = true;

            //carrega os componentes com os valores passados atrave´s do construtor
            id = nota.Id;
            txtTitulo.Text = nota.Titulo;
            txtDados.Text = nota.Dados;
            swFavorito.IsToggled = nota.Favorito;
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
                    nota.Id = id;
                    dbNotas.Alterar(nota);
                    DisplayAlert("Resultado da operação", dbNotas.StatusMessage, "OK");
                }
                Voltar();

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

        private async void btExcluir_CLicked(object sender, EventArgs e)
        {
            //aqui pergunta para a confirmação da exclusão do registro
            bool resp = await DisplayAlert("Excluir Registro", "Deseja Excluir a nota atual?", "Sim!", "Não!");

            //se o retorno der True, o metodo excluir é chamado
            if (resp)
            {
                ServicesBDNota dbNotas = new ServicesBDNota(App.DbPath);
                dbNotas.Excluir(id);
                await DisplayAlert("Resultado da operação", dbNotas.StatusMessage, "OK!!");
            }
            Voltar();
        }

        public void Voltar()
        {
            MasterDetailPage p = (MasterDetailPage)Application.Current.MainPage;
            p.Detail = new NavigationPage(new HomeDetail());
        }
    }
}