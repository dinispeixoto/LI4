using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyClassLibrary
{
    public class Produto
    {
        private int id;
        private String nome;
        private String descricao;
        private float preco;
        private int visitas;
        private List<Avaliacao> avalicacoes;
        private List<Tag> tags;

        public Produto(int id, String nome, String descricao, float preco, int visitas)
        {
            this.id = id;
            this.nome = nome;
            this.descricao = descricao;
            this.preco = preco;
            this.visitas = visitas;
            this.avalicacoes = new List<Avaliacao>();
            this.tags = new List<Tag>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public String Descricao
        {
            get { return descricao; }
            set { descricao = value; }
        }

        public float Preco
        {
            get { return preco; }
            set { preco = value; }
        }

        public bool MatchTags(List<Tag> tags) //novo
        {
            foreach(var tag in tags)
            {
                if (this.tags.Contains(tag)) return true;
            }
            return false;
        }

        public void AddAvaliacao(float classificacao, String comentario, int idUtilizador)
        {
            Avaliacao av = new Avaliacao(classificacao, comentario, idUtilizador, id);
            avalicacoes.Add(av);
        }

        public void AddTag(String tipo, String nome, int id)
        {
            Tag t = new Tag(tipo, nome, id);
            tags.Add(t);
        }

        public void RemoverTag(int idTag)
        {
            foreach(var tag in tags)
            {
                if (tag.Id == idTag) tags.Remove(tag);break;
            }
        }

        public List<Tag> GetListaTags()
        {
            return tags;
        }

        public List<Avaliacao> GetListaAvaliacao()
        {
            return avalicacoes;
        }
    }
}
