using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyApp.Models
{
    public class Avaliacao
    {
        private float classificacao;
        private String comentario;
        private int idUtilizador;
        private int id;

        public Avaliacao(float classificacao, String comentario, int idUtilizador, int id)
        {
            this.classificacao = classificacao;
            this.comentario = comentario;
            this.idUtilizador = idUtilizador;
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

        public int IdUtilizador
        {
            get { return idUtilizador; }
            set { idUtilizador = value; }
        }
    }
}
