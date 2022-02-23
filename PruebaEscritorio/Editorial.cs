using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Editorial
    {
        private int id_editorial;
        private String nombre;
        private String nacionalidad;

        public Editorial()
        {

        }
        public Editorial(int id_editorial, String nombre, String nacionalidad)
        {
            this.id_editorial = id_editorial;
            this.nombre = nombre;
            this.nacionalidad = nacionalidad;
        }

        //--------------------------------------------
        public int getId_editorial()
        {
            return this.id_editorial;
        }
        public void setId_editorial(int id_editorial)
        {
            this.id_editorial = id_editorial;
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
        public String getNacionalidad()
        {
            return this.nacionalidad;
        }
        public void setNacionalidad(String nacionalidad)
        {
            this.nacionalidad = nacionalidad;
        }





    }
}
