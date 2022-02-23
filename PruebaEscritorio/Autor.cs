using System;
using System.Collections.Generic;
using System.Text;

namespace Libreria
{
    class Autor
    {
        private int id_autor;
        private String nombre;
        private String apellidos;
        private String nacionalidad;
        private DateTime f_nacimiento;

        public Autor()
        {

        }
        public Autor(int id_autor, String nombre, String apellidos, String nacionalidad, DateTime f_nacimiento)
        {
            this.id_autor = id_autor;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.nacionalidad = nacionalidad;
            this.f_nacimiento = f_nacimiento;
        }

        //--------------------------------------------
        public int getId_autor()
        {
            return this.id_autor;
        }
        public void setId_autor(int id_autor)
        {
            this.id_autor = id_autor;
        }

        //--------------------------------------------
        public String getNombre()
        {
            return this.nombre;
        }
        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        //--------------------------------------------
        public String getApellidos()
        {
            return this.apellidos;
        }
        public void setApellidos(String apellidos)
        {
            this.apellidos = apellidos;
        }

        //--------------------------------------------
        public String getNacionalidad()
        {
            return this.nacionalidad;
        }
        public void setNacionalidad(String nacionalidad)
        {
            this.nacionalidad = nacionalidad;
        }

        //--------------------------------------------
        public DateTime getF_nacimiento()
        {
            return this.f_nacimiento;
        }
        public void setTitulo(DateTime f_nacimiento)
        {
            this.f_nacimiento = f_nacimiento;
        }


    }
}
