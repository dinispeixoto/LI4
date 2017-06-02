using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyApp.Models
{
    public class Utilizador : IdentityUser
    {
        private String dataNascimento;
        private String nome;
        private String password;
        private String foto;
        private int id;
        private bool admin;
        private List<Tag> preferencias;
        private List<Produto> visitas;
        private List<Produto> favoritos;

        public Utilizador()
        {
            this.preferencias = new List<Tag>();
            this.visitas = new List<Produto>();
            this.favoritos = new List<Produto>();
        }

        public Utilizador(String email, String dataNascimento, String nome, String password, String username, String foto, int id, bool admin)
        {
            this.Email = email;
            this.dataNascimento = dataNascimento;
            this.nome = nome;
            this.password = password;
            this.foto = foto;
            this.id = id;
            this.admin = admin;
            this.preferencias = new List<Tag>();
            this.visitas = new List<Produto>();
            this.favoritos = new List<Produto>();
            this.UserName = username;
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public void AddFavorito(Produto p)
        {
            favoritos.Add(p);
        }

        public void AddVisita(Produto p)
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

        public void AddPreferencias(List<Tag> tags)
        {
            foreach (var tag in tags)
            {
                if (!(preferencias.Contains(tag))) preferencias.Add(tag);
            }
        }

        public void RemovePreferencias(List<Tag> tags)
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

        public List<Tag> GetListaPreferencias()
        {
            return preferencias;
        }

        public List<Produto> GetListaVisitas()
        {
            return visitas;
        }

        public List<Produto> GetListaFavoritos()
        {
            return favoritos;
        }
    }
}