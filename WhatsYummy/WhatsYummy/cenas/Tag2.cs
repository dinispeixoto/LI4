using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyClassLibrary
{
    public class Tag2 
    {
        private String tipo;
        private String nome;
        private int id;

        public Tag2(String tipo, String nome, int id)
        {
            this.tipo = tipo;
            this.nome = nome;
            this.id = id;
        }

        public String Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }
}
