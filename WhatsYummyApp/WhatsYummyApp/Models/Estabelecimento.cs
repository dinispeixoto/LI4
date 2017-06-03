using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WhatsYummyApp.Models
{
    public class Estabelecimento
    {
        private int id;
        private String descricao;
        private String nome;
        private String localidade;
        private String codigoPostal;
        private String rua;
        private int proprietario;
        private int estado;
        private readonly Horario[] horario = new Horario[7];
        private readonly Dictionary<int, Produto> menu = new Dictionary<int, Produto>();
        private int numProdutos = 0;

        public Estabelecimento()
        {

        }

        public Estabelecimento(int id, String descricao, String nome, String localidade, String codigoPostal, String rua, int proprietario, int estado)
        {
            this.id = id;
            this.descricao = descricao;
            this.nome = nome;
            this.localidade = localidade;
            this.codigoPostal = codigoPostal;
            this.rua = rua;
            this.proprietario = proprietario;
            this.estado = estado;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public String Localidade
        {
            get { return localidade; }
            set { localidade = value; }
        }

        public String CodigoPostal
        {
            get { return codigoPostal; }
            set { codigoPostal = value; }
        }

        public String Rua
        {
            get { return rua; }
            set { rua = value; }
        }

        public int Proprietario
        {
            get { return proprietario; }
            set { proprietario = value; }
        }

        public int Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        public void AdicionarProduto(String nome, String descricao, float preco)
        {
            Produto p = new Produto(numProdutos,nome,descricao,preco,0);
            menu.Add(numProdutos, p);
            numProdutos++;
        }

        public void RemoverProduto(int id)
        {
            menu.Remove(id);
        }

        public Produto ConsultarProduto(int idProduto)
        {
            //if (menu.TryGetValue(idProduto, out Produto test)) return test;
            //else 
            return menu[idProduto];
        }

        public bool CheckHorario(DateTime hora, int dia)
        {
            if (horario[dia].Equals(hora)) return true;
            else return false;
        }

        public bool CheckProrietario(int idUtilizador)
        {
            return proprietario == idUtilizador;
        }

        public List<Produto> PedirProduto(List<Tag> tags)
        {
            List<Produto> produtos = new List<Produto>();
            foreach (var p in menu)
            {
                if (p.Value.MatchTags(tags)) produtos.Add(p.Value);
            }

            return produtos;
        }

        public void EditarProduto(int idProduto, String nome, String descricao, float preco)
        {
            if (menu.ContainsKey(idProduto))
            {
                menu[idProduto].Nome = nome;
                menu[idProduto].Descricao = descricao;
                menu[idProduto].Preco = preco;
            }
        }

        public void Validar()
        {
            this.estado = 1;
        }
    }
}
