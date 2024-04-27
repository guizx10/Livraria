using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria
{
    class Livro
    {
        private int codigo;
        private string titulo;
        private string autor;
        private string editora;
        private string genero;
        private string isbn;
        private int quantidadePagina;
        private string situacao;
        private int preco;

        public Livro()
        {
            ModificarCodigo = 0;
            ModificarTitulo = "";
            ModificarAutor = "";
            ModificarEditora = "";
            ModificarGenero = "";
            ModificarIsbn = "";
            ModificarQuantidadePagina = 0;
            ModificarSituacao = "";
            ModificarPreco = 0;

        }//fim do construtor 

        public int ModificarCodigo
        {
            get { return codigo; }
            set { this.codigo = value; }
        }

        public string ModificarTitulo
        {
            get { return titulo; }
            set { this.titulo = value; }
        }

        public string ModificarAutor
        {
            get { return autor; }
            set { this.autor = value; }
        }

        public string ModificarEditora
        {
            get { return editora; }
            set { this.editora = value; }
        }

        public string ModificarGenero
        {
            get { return genero; }
            set { this.genero = value; }
        }

        public string ModificarIsbn
        {
            get { return isbn; }
            set { this.isbn = value; }
        }

        public int ModificarQuantidadePagina
        {
            get { return quantidadePagina; }
            set { this.quantidadePagina = value; }
        }

        public int ModificarPreco
        {
            get { return preco; }
            set { this.preco = value; }
        }

        public string ModificarSituacao
        {
            get { return situacao; }
            set { this.situacao = value; }
        }


        public void Cadastrar(int codigo, string titulo, string autor, string editora,
                          string genero, string isbn, int quantidadePagina)
        {
            ModificarCodigo = 0;
            ModificarTitulo = "";
            ModificarAutor = "";
            ModificarEditora = "";
            ModificarGenero = "";
            ModificarIsbn = "";
            ModificarQuantidadePagina = 0;
            ModificarSituacao = "";
            ModificarSituacao = "Ativo";
            ModificarPreco = 0;

        }//fim do método

        public string ConsultaLivro(int codigo)
        {


            string consulta = "";

            if (ModificarCodigo == codigo)
            {
                consulta = "\n Codigo: " + ModificarCodigo +
                           "\n Titulo: " + ModificarTitulo +
                           "\n Autor: " + ModificarAutor +
                           "\n Editora: " + ModificarEditora +
                           "\n Isbn: " + ModificarIsbn +
                           "\n Preço: " + ModificarPreco;
            }
            else
            {
                consulta = "Livro não consta na Livraria ! ";
            }
            return consulta;
        }

        public void AtualizarCodigo(int codigo, string Titulo)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarTitulo = titulo;
            }
        }

        public void AtualizarAutor(int codigo, string autor)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarAutor = autor;
            }
        }

        public void AtualizarEditora(int codigo, string editora)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarEditora = editora;
            }
        }

        public void AtualizarIsbn(int codigo, string isbn)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarIsbn = isbn;
            }
        }

        public void AtualizarQuantidadePagina(int codigo, int quantidadePagina)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarQuantidadePagina = quantidadePagina;
            }
        }

        public void AtualizarPreco(int codigo, int preco)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarPreco = preco;
            }
        }

        public void Excluir(int codigo)
        {
            if (ModificarCodigo == codigo)
            {
                ModificarSituacao = "Inativo";
            }
        }//fim do método
    }
}