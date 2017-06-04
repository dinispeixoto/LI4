using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyApp.Models
{
    public class Avaliacao
    {
        private float classificacao;
        private String comentario;
        private int autor;
        private int id;

        public Avaliacao()
        {
        }

        public Avaliacao(float classificacao, String comentario, int autor, int id)
        {
            this.classificacao = classificacao;
            this.comentario = comentario;
            this.autor = autor;
            this.id = id;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public float Classificacao
        {
            get { return classificacao; }
            set { classificacao = value; }
        }

        public String Comentario
        {
            get { return comentario; }
            set { comentario = value; }
        }

        public int Autor
        {
            get { return autor; }
            set { autor = value; }
        }
    }
}
