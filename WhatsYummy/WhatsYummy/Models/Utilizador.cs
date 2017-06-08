using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace WhatsYummy.Models
{
    //[Table("Utilizador")]
    public class Utilizador
    {
        //[Key]
        //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		public String Email { get; set; }
        public String DataNascimento { get; set; }
        public String Nome { get; set; }
        public String Password { get; set; }
        public String Username { get; set; }
        public String Foto { get; set; }
        public int Admin { get; set; }

        public virtual ICollection<Preferencia> Preferencias { get; set; }
        public virtual ICollection<Avaliacao> Visitas { get; set; }
        public virtual ICollection<UtilizadorProduto> Favoritos { get; set; }

        public Utilizador()
        {
        }
    }

	public class CreateModel
	{
		[Required]
		[Display(Name = "Nome")]
		public string Nome { get; set; }

		[Required]
		[Display(Name = "Username")]
		public string Username { get; set; }

		[Display(Name = "Data de nascimento")]
		//[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public String DataNascimento { get; set; }

		[Display(Name = "Foto")]
		public string Foto { get; set; }

		[Required]
		[EmailAddress]
		[Display(Name = "E-mail")]
		public string Email { get; set; }

		[Required]
		[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirmar password")]
		[Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
		public string ConfirmPassword { get; set; }
	}

	public class LoginModel
	{
		[Required]
		[Display(Name = "Nome de Utilizador")]
		public string UserName { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

		[Display(Name = "Lembrar-me mais tarde.")]
		public bool RememberMe { get; set; }
	}
}
