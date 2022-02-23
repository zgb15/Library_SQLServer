using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria
{
    class Libro
    {
        private int id_libro;
        private int id_autor;
        private int id_editorial;
        private String titulo;
        private String isbn;
        private int num_paginas;

        public Libro()
        {

        }
        public Libro(int id_libro, int id_autor, int id_editorial, String titulo, String isbn, int num_paginas)
        {
            this.id_libro = id_libro;
            this.id_autor = id_autor;
            this.id_editorial = id_editorial;
            this.titulo = titulo;
            this.isbn = isbn;
            this.num_paginas = num_paginas;
        }

        //--------------------------------------------
        public int getId_libro()
        {
            return this.id_libro;
        }
        public void setId_libro(int id_libro)
        {
            this.id_libro = id_libro;
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
        public int getId_editorial()
        {
            return this.id_editorial;
        }
        public void setId_editorial(int id_editorial)
        {
            this.id_editorial = id_editorial;
        }

        //--------------------------------------------
        public String getTitulo()
        {
            return this.titulo;
        }
        public void setTitulo(String titulo)
        {
            this.titulo = titulo;
        }

        //--------------------------------------------
        public String getIsbn()
        {
            return this.isbn;
        }
        public void setIsbn(String isbn)
        {
            this.isbn = isbn;
        }

        //--------------------------------------------
        public int getNum_paginas()
        {
            return this.num_paginas;
        }
        public void setNum_paginas(int num_paginas)
        {
            this.num_paginas = num_paginas;
        }




    }
}
