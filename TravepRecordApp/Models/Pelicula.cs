using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;


namespace TravepRecordApp.Models
{
    public class Pelicula
    {
        private int id;
        private string titulo;
        private int volumen;

        public Pelicula(){}
        public Pelicula(int ID, string Titulo, int Volumen) {
            this.id = ID;
            this.titulo = Titulo;
            this.volumen = Volumen;
        }
        public int ID {
            get { return this.id; }
            set { this.id = value; }
        }
        public string Titulo {
            get { return this.titulo; }
            set { this.titulo = value; }
        }
        public int Volumen {
            get { return this.volumen; }
            set { this.volumen = value; }
        }
    }
}
