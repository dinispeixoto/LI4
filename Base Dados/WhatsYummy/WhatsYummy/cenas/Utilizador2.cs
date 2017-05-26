using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyClassLibrary
{
    public class Utilizador2
    {
        private String email;
        private String dataNascimento;
        private String nome;
        private String password;
        private String username;
        private String foto;
        private int id;
        private bool admin;
        private List<Tag2> preferencias;
        private List<Produto2> visitas;
        private List<Produto2> favoritos;

        public Utilizador2(String email, String dataNascimento, String nome, String password, String username, String foto, int id, bool admin)
        {
            this.email = email;
            this.dataNascimento = dataNascimento;
            this.nome = nome;
            this.password = password;
            this.username = username;
            this.foto = foto;
            this.id = id;
            this.admin = admin;
            this.preferencias = new List<Tag2>();
            this.visitas = new List<Produto2>();
            this.favoritos = new List<Produto2>();
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public String Username
        {
            get { return username; }
            set { username = value; }
        }

        public String Email
        {
            get { return email; }
            set { email = value; }
        }

        public String DataNascimento
        {
            get { return dataNascimento; }
            set { dataNascimento = value; }
        }

        public String Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public String Password
        {
            get { return password; }
            set { password = value; }
        }

        public String Foto
        {
            get { return foto; }
            set { foto = value; }
        }

        public bool Admin
        {
            get { return admin; }
            set { admin = value; }
        }

        public void AddFavorito(Produto2 p)
        {
            favoritos.Add(p);
        }

        public void AddVisita(Produto2 p)
        {
            visitas.Add(p);
        }

        public void RemoverFavorito(int idProduto)
        {
            foreach (var produto in favoritos)
            {
                if (produto.Id == idProduto) favoritos.Remove(produto); break;
            }
        }

        public void AddPreferencias(List<Tag2> tags)
        {
            foreach (var tag in tags)
            {
                if (!(preferencias.Contains(tag))) preferencias.Add(tag);
            }
        }

        public void RemovePreferencias(List<Tag2> tags)
        {
            foreach (var tag in tags)
            {
                if (preferencias.Contains(tag)) preferencias.Remove(tag);
            }
        }

        public bool CheckAdmin()
        {
            return admin;
        }

        public List<Tag2> GetListaPreferencias()
        {
            return preferencias;
        }

        public List<Produto2> GetListaVisitas()
        {
            return visitas;
        }

        public List<Produto2> GetListaFavoritos()
        {
            return favoritos;
        }
    }
}
