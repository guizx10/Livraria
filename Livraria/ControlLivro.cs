using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Livraria
{
    class ControlLivro
    {
        Livro model;//Conectar com a Pessoa model
        private int opcao;
        public ControlLivro()
        {
            model = new Livro();
            ModificarOpcao = 0;
        }

        public int ModificarOpcao
        {
            get { return opcao; }
            set { opcao = value; }
        }

        public void Menu()
        {
            Console.WriteLine("Menu - Livro" +
                              "\n1. Cadastrar Livro" +
                              "\n2. Consultar Livro" +
                              "\n3. Atualizar Quantidade" +
                              "\n4. Atualizar Preço" +
                              "\n5. Excluir");
            ModificarOpcao = Convert.ToInt32(Console.ReadLine());
        }//fim do Menu

        public void Operacao()
        {
            Menu();
            switch (ModificarOpcao)
            {
                case 1:
                    Console.WriteLine("Informe o codigo: ");
                    int codigo = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Informe o titulo: ");
                    string titulo = Console.ReadLine();

                    Console.WriteLine("Informe o autor: ");
                    string autor = Console.ReadLine();

                    Console.WriteLine("Informe a editora: ");
                    string editora = Console.ReadLine();

                    Console.WriteLine("Informe o genero do Livro: ");
                    string genero = Console.ReadLine();

                    Console.WriteLine("Informe um ISBN: ");
                    string isbn = Console.ReadLine();

                    Console.WriteLine("Informe a Quantidade de Pagina: ");
                    int quantidadePagina = Convert.ToInt32(Console.ReadLine());

                    model.Cadastrar(codigo, titulo, autor, editora, genero, isbn, quantidadePagina);

                    break;
            }
        }


    }//fim do Construtor


}
