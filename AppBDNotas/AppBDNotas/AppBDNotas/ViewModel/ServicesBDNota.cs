using AppBDNotas.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBDNotas.ViewModel
{
    public class ServicesBDNota
    {
        //Obejeto de Conexão
        SQLiteConnection conn;

        //Variavel de retorno do status (resultado) do BD
        public string StatusMessage { get; set; }

        //Método construtor, criação do Banco de Dados
        public ServicesBDNota(string dbPath)
        {
            if (dbPath == "") dbPath = App.DbPath;  //caso não encontre o local atribiu o valor da variavel global
            conn = new SQLiteConnection(dbPath);  //define o banco
            conn.CreateTable<ModelNota>(); //cria a tabela notas 
        }

        //Metodo de inserção de registros no Banco de Dados
        public void Inserir(ModelNota nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))  //caso esteja vazio o campo Titulo
                    throw new Exception("Titulo da nota não informado");

                if (string.IsNullOrEmpty(nota.Dados)) //caso esteja vazio o campo Dados
                    throw new Exception("Dados da nota não informados");

                int result = conn.Insert(nota);  //inserção do registro no banco de Dados

                if (result != 0)// retorno diferente de 0, foi adicionado com sucesso
                {
                    this.StatusMessage = string.Format("{0} Registro(s) adicionados(s): [Notas: {1}", result, nota.Titulo);
                }
                else
                {
                    string.Format("0 registro(s) adicionado(s)");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //Método de Listar todos os registros
        public List<ModelNota> Listar()
        {
            List<ModelNota> Lista = new List<ModelNota>();  //criação da lista para receber todos os Dados do BD
            try
            {
                Lista = conn.Table<ModelNota>().ToList();  //carrega a lista
                this.StatusMessage = "Listagem das Notas";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return Lista;

        }

        public void Alterar(ModelNota nota)
        {
            try
            {
                if (string.IsNullOrEmpty(nota.Titulo))  //caso esteja vazio o campo Titulo
                    throw new Exception("Titulo da nota não informado");

                if (string.IsNullOrEmpty(nota.Dados)) //caso esteja vazio o campo Dados
                    throw new Exception("Dados da nota não informados");

                if (nota.Id <= 0)
                    throw new Exception("Id da nota não informado");

                //atualiza todas as colunas da tabela do objeto que estou passando.
                int result = conn.Update(nota);
                StatusMessage = string.Format("{0} Registros alterados.", result);
            }
            catch (Exception ex)
            {
                throw new Exception(String.Format("Erro: {0}", ex.Message));
            }
        }

        public void Excluir(int id)
        {
            try
            {
                //recebe o id do regisro a ser deletado. se Id da table igual ao id, deleta
                int result = conn.Table<ModelNota>().Delete(r => r.Id == id);
                StatusMessage = string.Format("{0} Registros Deletados.", result);
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
        }

        //metodo que recebe apenas o titulo para localizar a nota
        public List<ModelNota> Localizar (string titulo)
        {
            List<ModelNota> lista = new List<ModelNota>();
            try
            {
                var resp = from p in conn.Table<ModelNota>() 
                           where p.Titulo.ToLower().Contains(titulo.ToLower()) 
                           select p;
                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            return lista;
        }

        //Mostrar para listar apenas os favoritos
        public List<ModelNota> ListarFavoritos()
        {
            List<ModelNota> lista = new List<ModelNota>();
            try
            {
                var resp = from p in conn.Table<ModelNota>() 
                           where p.Favorito == true 
                           select p;
                lista = resp.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Erro: {0}", ex.Message));
            }
            return lista;
        }
    }
}
