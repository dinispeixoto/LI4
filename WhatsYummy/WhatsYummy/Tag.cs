using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyClassLibrary
{
    public class Tag 
    {
        private String tipo;
        private String nome;
        private int id;

        public Tag(String tipo, String nome, int id)
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

        public override bool Equals(Object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Tag p = (Tag)obj;
            return (tipo == p.Tipo) && (nome == p.Nome) && (id == p.Id);
        }
    }
}
