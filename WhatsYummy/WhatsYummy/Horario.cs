using System;
using System.Collections.Generic;
using System.Text;

namespace WhatsYummyClassLibrary
{
    public class Horario
    {
        private DateTime horaAbertura;
        private DateTime horaFecho;
        private int dia;

        public Horario(DateTime horaAbertura, DateTime horaFecho, int dia)
        {
            this.horaAbertura = horaAbertura;
            this.horaFecho = horaFecho;
            this.dia = dia;
        }
    }
}
