using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppBDNotas.Model
{

    [Table("Anotacoes")] //Nome da tabela do banco de dados
    public class ModelNota
    {
        //propriedades da tabela Anotações (Campos)
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [NotNull]
        public String Titulo { get; set; }
        [NotNull]
        public String Dados { get; set; }
        [NotNull]
        public Boolean Favorito { get; set; }

        //Metodo construto da classe, inicialização dos registros
        public ModelNota()
        {
            this.Id = 0;
            this.Dados = "";
            this.Favorito = false;
            this.Titulo = "";
                        }

    }
}
