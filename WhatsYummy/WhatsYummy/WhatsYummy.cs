using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WhatsYummyClassLibrary
{
    class WhatsYummy
    {
        private int totalUtilizadores;
        private int totalEstabelecimentos;
        private int totalProdutos;
        private int totalAvaliacoes;
        private int totalTags;
        private Dictionary<int, Utilizador> utilizadores;
        private Dictionary<int, Estabelecimento> estabelecimentos;
        private Dictionary<int, Tag> tags;
        private Utilizador utilizador;

        public WhatsYummy()
        {
            this.totalUtilizadores = 0;
            this.totalEstabelecimentos = 0;
            this.totalProdutos = 0;
            this.totalAvaliacoes = 0;
            this.totalTags = 0;
            this.utilizadores = new Dictionary<int, Utilizador>();
            this.estabelecimentos = new Dictionary<int, Estabelecimento>();
            this.tags = new Dictionary<int, Tag>();
            this.utilizador = null;
        }

        public void RegistarUtilizador(String email, String dataNascimento, String nome, String password, String username, String foto, bool admin)
        {
            Utilizador u = new Utilizador(email, dataNascimento, nome, password, username, foto, totalUtilizadores, admin);
            utilizadores.Add(totalUtilizadores, u);
            totalUtilizadores++;
            Console.WriteLine("Utilizador registado!");
        }

        public void AdicionarEstabelecimento(String descricao, String nome, String localidade, String codigoPostal, String rua, int proprietario, int estado)
        {
            Estabelecimento e = new Estabelecimento(totalEstabelecimentos, descricao, nome, localidade, codigoPostal, rua, proprietario, estado);
            estabelecimentos.Add(totalEstabelecimentos, e);
            totalEstabelecimentos++;
        }

        public void RemoverEstabelecimento(int id)
        {
            estabelecimentos.Remove(id);
            totalEstabelecimentos--;
        }

        public List<Produto> PedirProduto(int idUtilizador, List<Tag> tags)
        {
            List<Produto> prods = new List<Produto>();
            foreach( var par in estabelecimentos)
            {
                List<Produto> l = par.Value.PedirProduto(tags);
                prods.AddRange(l);
            }
            return prods;
        }

        public List<Tag> ListaTotalTags()
        {
            return tags.Values.ToList();
        }

        public void EditarPerfil(int id, String email, String dataNascimento, String nome, String password, String foto, bool admin)
        {
            utilizadores[id].Email = email;
            utilizadores[id].DataNascimento = dataNascimento;
            utilizadores[id].Nome = nome;
            utilizadores[id].Password = password;
            utilizadores[id].Foto = foto;
            utilizadores[id].Admin = admin;
        }

        public void EditarPreferencias(int id, List<Tag> tags)
        {
            utilizadores[id].AddPreferencias(tags);
        }

        public bool CheckAdmin(int idUtilizador)
        {
            return utilizadores[idUtilizador].CheckAdmin();
        }

        public void AdicionarTag(int id, String tipo, String nome)
        {
            Tag t = new Tag(tipo, nome, id);
            tags.Add(id, t);
            totalTags++;
        }

        public void ValidarEstabelecimento(int idEstabelecimento)
        {
            estabelecimentos[idEstabelecimento].Validar();
        }

        public Estabelecimento ConsultarEstabelecimento(int idEstabelecimento)
        {
            return estabelecimentos[idEstabelecimento];
        }

        public List<Estabelecimento> ListaEstabelecimentos(int idUtilizador)
        {
            List<Estabelecimento> l = new List<Estabelecimento>();
            foreach (var par in estabelecimentos)
            {
                Estabelecimento e = par.Value;
                if (e.Proprietario == idUtilizador) l.Add(e);
            }
            return l;
        }

        public List<Produto> FazerPedido(List<Tag> tags)
        {
            List<Produto> prods = new List<Produto>();
            foreach (var par in estabelecimentos)
            {
                prods.AddRange(par.Value.PedirProduto(tags));
            }
            return prods;
        }

        public Produto PedirSuguestao(int idUtilizador)
        {
            List<Tag> prefs = utilizadores[idUtilizador].GetListaPreferencias();
            List<Produto> prods = FazerPedido(prefs);
            Random rnd = new Random();
            int r = rnd.Next(prods.Count);
            return prods[r];
        }

        public Produto GeraSugestaoDiaria(int idUtilizador)
        {
            return PedirSuguestao(idUtilizador);
        }

        public Utilizador IniciarSessao(String username, String password)
        {
            foreach (var par in utilizadores)
            {
                Utilizador ut = par.Value;
                if (ut.Username == username && ut.Password == password) utilizador = ut; Console.WriteLine("Sessao iniciada!"); return ut;
            }
            return null;
        }

        public void TerminarSessao(int idUtilizador)
        {
            if (utilizador.Id == idUtilizador) utilizador = null;
            Console.WriteLine("Sessao terminada!");
        }

        public List<Produto> ConsultarFavoritos(int idUtilizador)
        {
            return utilizadores[idUtilizador].GetListaFavoritos();
        }

        public List<Produto> ConsultarVisitasRecentes(int idUtilizador)
        {
            return utilizadores[idUtilizador].GetListaVisitas();
        }

        public Produto ConsultarProduto(int idEstabelecimento, int idProduto)
        {
            return estabelecimentos[idEstabelecimento].ConsultarProduto(idProduto);
        }

        public void AdicionarProduto(int idEstabelecimento, int idProduto, String nome, String descricao, float preco)
        {
            estabelecimentos[idEstabelecimento].AdicionarProduto(idProduto, nome, descricao, preco);
            totalProdutos++;
        }

        public void RemoverProduto(int idEstabelecimento, int idProduto)
        {
            estabelecimentos[idEstabelecimento].RemoverProduto(idProduto);
            totalProdutos--;
        }

        public void EditarProduto(int idEstabelecimento, int idProduto, String nome, String descricao, float preco)
        {
            estabelecimentos[idEstabelecimento].EditarProduto(idProduto, nome, descricao, preco);
        }

        public void AdicionarAvaliacao(int idEstabelecimento, int idProduto, float classificacao, String comentario, int idUtilizador)
        {
            estabelecimentos[idEstabelecimento].ConsultarProduto(idProduto).AddAvaliacao(classificacao, comentario, idUtilizador);
            totalAvaliacoes++;
        }
    }
}
