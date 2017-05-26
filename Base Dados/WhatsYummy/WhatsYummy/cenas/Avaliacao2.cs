using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyClassLibrary
{
    public class Avaliacao2
    {
        private float classificacao;
        private String comentario;
        private int idUtilizador;
        private int id;

        public Avaliacao2(float classificacao, String comentario, int idUtilizador, int id)
        {
            this.classificacao = classificacao;
            this.comentario = comentario;
            this.idUtilizador = idUtilizador;
            this.id = id;
        }
    }
}
