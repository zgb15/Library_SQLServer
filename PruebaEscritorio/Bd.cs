using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Collections;

namespace Libreria
{
    class Bd
    {
        private IDbConnection conexion = null;
        private IDbCommand comando = null;
        private IDataReader datos = null;
        private String cadenaConexion;
        private int id;
        bool conectado = false;

        private ArrayList listaAut = null;
        private ArrayList listaEditoriales = null;
        private ArrayList listaLibros = null;
        private ArrayList listaLib = null;

        // la dirección de la BD 
        public Bd()
        {
            cadenaConexion = "Data Source=LAPTOP-VDQDRL3P;" +
                "Initial Catalog=libreria;" +
                    "Integrated Security=True;";
            
            
            conexion = new SqlConnection(cadenaConexion);
            comando = conexion.CreateCommand();
        }

        // MÉTODOS DE AUTOR
            // dameAutor
            public int dameAutor()
            {
                try
                {
                    abrirConexion();
                    comando.CommandText = "SELECT * FROM Autor";
                    datos = comando.ExecuteReader();
                    while (datos.Read())
                    {
                        Console.WriteLine(datos[0] + "  " + datos[1].ToString());
                    }
                    datos.Close();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return this.id;
            }

            // dameIdAutor
            public int dameIdAutor(String nombre)
            {
                try
                {
                    abrirConexion();
                    String[] autor = nombre.Split(' ');
                    comando.CommandText = "SELECT ID_AUTOR FROM AUTOR WHERE NOMBRE_AUTOR LIKE '" + autor[0] + "%' " +
                        "AND APELLIDOS_AUTOR LIKE '%" + autor[autor.Length - 1] + "'";
                    datos = comando.ExecuteReader();
                    datos.Read();
                    id = Convert.ToInt32(datos[0]);
                    datos.Close();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return this.id;
            }

            // cargaAutores 
            public ArrayList cargaAutores()
            {
                listaAut = new ArrayList();
                Autor autor = null;
                Autor[] autorestemp;
                int cantidad;
                try
                {
                    abrirConexion();
                    comando.CommandText = "SELECT COUNT(*) FROM AUTOR";
                    datos = comando.ExecuteReader();
                    datos.Read();
                    cantidad = Convert.ToInt32(datos[0]);
                    datos.Close();
                    autorestemp = new Autor[cantidad];
                    int contador = 0;
                    comando.CommandText = "SELECT * FROM AUTOR";
                    datos = comando.ExecuteReader();
                    while (datos.Read())
                    {
                        String apellidosTemp = null;
                        String nacionalidadTemp = null;
                        DateTime fechaTemp = DateTime.Now.Date;
                        if (datos[2] != DBNull.Value) apellidosTemp = datos[2].ToString();
                        if (datos[3] != DBNull.Value) nacionalidadTemp = datos[3].ToString();
                        if (datos[4] != DBNull.Value) Convert.ToDateTime(datos[4]);
                        autor = new Autor(Convert.ToInt32(datos[0]), datos[1].ToString(), apellidosTemp,
                            nacionalidadTemp, fechaTemp);
                        contador++;
                        listaAut.Add(autor);
                    }
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return listaAut;
            }

            // método insertarAutor
            public int insertarAutor(Autor autor)
            {
                int resultado = 0;
                try
                {
                    abrirConexion();
                    comando.CommandText = comando.CommandText = "INSERT INTO Autor (id_autor,nombre,apellidos,nacionalidad,f_nacimiento)" +
                            "VALUES(@ID,@NOMBRE,@APELLIDOS,@NACIONALIDAD,@FECHA)";
                    comando.Parameters.Add(new SqlParameter("@ID", autor.getId_autor()));
                    comando.Parameters.Add(new SqlParameter("@NOMBRE", autor.getNombre()));
                    comando.Parameters.Add(new SqlParameter("@APELLIDOS", autor.getApellidos()));
                    comando.Parameters.Add(new SqlParameter("@NACIONALIDAD", autor.getNacionalidad()));
                    comando.Parameters.Add(new SqlParameter("@FECHA", autor.getF_nacimiento()));

                    resultado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

            // método modificarAutor
            public int modificarAutor(Autor autor, int numero)
            {
                int resultado = 0;
                try
                {
                    abrirConexion();
                    comando.CommandText = "UPDATE Autor SET nombre= @NOMBRE," +
                        "apellidos= @APELLIDOS, nacionalidad= @NACIONALIDAD" +
                        ", f_nacimiento= @FECHA WHERE id_autor= @ID";
                    //comando.Parameters.Add(new SqlParameter("@ID", autor.getId()));
                    comando.Parameters.Add(new SqlParameter("@ID", numero));
                    comando.Parameters.Add(new SqlParameter("@NOMBRE", autor.getNombre()));
                    comando.Parameters.Add(new SqlParameter("@APELLIDOS", autor.getApellidos()));
                    comando.Parameters.Add(new SqlParameter("@NACIONALIDAD", autor.getNacionalidad()));
                    comando.Parameters.Add(new SqlParameter("@FECHA", autor.getF_nacimiento()));
                    // System.IO.MemoryStream ms = new System.IO.MemoryStream();

                    resultado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

            // método eliminarAutor
            public int eliminarAutor(int numero)
            {
                int resutado = 0;
                try
                {
                    abrirConexion();
                    comando.CommandText = "DELETE FROM AUTOR WHERE ID_AUTOR= " + numero;
                    resutado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resutado;
            }


        // MÉTODOS DE LIBRO
            // dameIdNuevaLibro
            public int dameIdNuevaLibro()
            {
                try
                {
                    abrirConexion();
                    comando.CommandText = "SELECT MAX(ID_LIBROS) FROM LIBROS";
                    datos = comando.ExecuteReader();
                    datos.Read();
                    id = Convert.ToInt32(datos[0]) + 1;
                    datos.Close();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return this.id;
            }

            // método modificarLibro
            public int modificarLibro(Libro libro, int idLibro)
            {
                int resultado = 0;
                try
                {
                    abrirConexion();
                    comando.CommandText = "UPDATE Libro SET id_autor= @ID_AUTOR," +
                        "id_editorial= @ID_EDITORIAL, titulo= @TITULO, isbn= @ISBN" +
                        ", num_paginas= @NUM_PAGINAS WHERE id_libro= @ID";
                    comando.Parameters.Add(new SqlParameter("@ID", idLibro));
                    comando.Parameters.Add(new SqlParameter("@ID_AUTOR", libro.getId_autor()));
                    comando.Parameters.Add(new SqlParameter("@ID_EDITORIAL", libro.getId_editorial()));
                    comando.Parameters.Add(new SqlParameter("@TITULO", libro.getTitulo()));
                    comando.Parameters.Add(new SqlParameter("@ISBN", libro.getIsbn()));
                    comando.Parameters.Add(new SqlParameter("@NUM_PAGINAS", libro.getNum_paginas()));
                    // System.IO.MemoryStream ms = new System.IO.MemoryStream();

                resultado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

            // método eliminarLibro
            public int eliminarLibro(int numero)
            {
                int resutado = 0;
                try
                {
                    comando.CommandText = "DELETE FROM Libro WHERE id_libro= " + numero;
                    abrirConexion();
                    resutado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resutado;
            }

            // método insertarLibro
            public int insertarLibro(Libro libro)
            {
                int resultado = 0;
                try
                {
                    abrirConexion();
                    comando.CommandText = comando.CommandText = "INSERT INTO Libro (id_libro,id_autor,id_editorial,titulo,isbn,num_paginas)" +
                            "VALUES(@ID_LIBRO,@ID_AUTOR,@ID_EDITORIAL,@TITULO,@ISBN,@NUM_PAGINASu)";
                    comando.Parameters.Add(new SqlParameter("@ID_LIBRO", libro.getId_libro()));
                    comando.Parameters.Add(new SqlParameter("@ID_AUTOR", libro.getId_autor()));
                    comando.Parameters.Add(new SqlParameter("@ID_EDITORIAL", libro.getId_editorial()));
                    comando.Parameters.Add(new SqlParameter("@TITULO", libro.getTitulo()));
                    comando.Parameters.Add(new SqlParameter("@ISBN", libro.getIsbn()));
                    comando.Parameters.Add(new SqlParameter("@NUM_PAGINAS", libro.getNum_paginas()));


                    resultado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

            // método para buscar el ID de la editorial
            public int searchEditorial(String nombreEditorial)
            {
                int resultado = 0;
                int id_editorial;
                try
                {
                    abrirConexion();
                    comando.CommandText = comando.CommandText = "SELECT id_editorial FROM Editorial WHERE nombre= @NOMBRE_EDITORIAL"; 
                    comando.Parameters.Add(new SqlParameter("@NOMBRE_EDITORIAL", nombreEditorial));


                    resultado = comando.ExecuteNonQuery();
                    cerrarConexion();

                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

            // método para buscar el ID del autor
            public int searchAutor(String nombreAutor)
            {
                int resultado = 0;
                int id_autor;
                try
                {
                    abrirConexion();
                    comando.CommandText = comando.CommandText = "SELECT id_autor FROM Autor WHERE nombre= @NOMBRE_AUTOR";
                    comando.Parameters.Add(new SqlParameter("@NOMBRE_AUTOR", nombreAutor));


                    resultado = comando.ExecuteNonQuery();
                    cerrarConexion();

                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

            // cargaLibros 
            public ArrayList cargaLibros()
            {
                listaLib = new ArrayList();
                Libro libro = null;
                Libro[] librostemp;
                int cantidad;
                try
                {
                    abrirConexion();
                    comando.CommandText = "SELECT COUNT(*) FROM Libro";
                    datos = comando.ExecuteReader();
                    datos.Read();
                    cantidad = Convert.ToInt32(datos[0]);
                    datos.Close();
                    librostemp = new Libro[cantidad];
                    int contador = 0;
                    comando.CommandText = "SELECT * FROM Libro";
                    datos = comando.ExecuteReader();
                    while (datos.Read())
                    {
                        String isbnTemp = null;
                       
                        if (datos[4] != DBNull.Value) isbnTemp = datos[4].ToString();
                        libro = new Libro(Convert.ToInt32(datos[0]), Convert.ToInt32(datos[1]), Convert.ToInt32(datos[2]), datos[3].ToString(), isbnTemp, Convert.ToInt32(datos[5]));
                        contador++;
                        listaLib.Add(libro);
                    }
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return listaLib;
            }



        // MÉTODOS DE EDITORIAL
            // dameIdNuevaEditorial
            public int dameIdNuevaEditorial()
            {
                try
                {
                    abrirConexion();
                    comando.CommandText = "SELECT MAX(ID_EDITORIAL) FROM EDITORIAL";
                    datos = comando.ExecuteReader();
                    datos.Read();
                    id = Convert.ToInt32(datos[0]) + 1;
                    datos.Close();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return this.id;
            }
        
            // dameIdEditorial
            public int dameIdEditorial(String nombre)
            {
                try
                {
                    abrirConexion();
                    comando.CommandText = "SELECT ID_EDITORIAL FROM EDITORIAL WHERE NOMBRE_EDITORIAL='" + nombre + "'";
                    datos = comando.ExecuteReader();
                    datos.Read();
                    id = Convert.ToInt32(datos[0]);
                    datos.Close();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return this.id;
            }
        
            // método cargaEditoriales
            public ArrayList cargaEditoriales()
            {
                listaEditoriales = new ArrayList();
                Editorial editorial = null;
                Editorial[] editorialestemp;
                int cantidad;
                try
                {
                    abrirConexion();
                    comando.CommandText = "SELECT COUNT(*) FROM Editorial";
                    datos = comando.ExecuteReader();
                    datos.Read();
                    cantidad = Convert.ToInt32(datos[0]);
                    datos.Close();
                    editorialestemp = new Editorial[cantidad];
                    int contador = 0;
                    comando.CommandText = "SELECT * FROM Editorial";
                    datos = comando.ExecuteReader();
                    while (datos.Read())
                    {
                        String nacionalidadTemp = null;
                        
                        if (datos[2] != DBNull.Value) nacionalidadTemp = datos[2].ToString();
                        editorial = new Editorial(Convert.ToInt32(datos[0]), datos[1].ToString(),
                            nacionalidadTemp);
                        contador++;
                        listaEditoriales.Add(editorial);
                    }
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return listaEditoriales;
            }

            // método insertarEditorial
            public int insertarEditorial(Editorial editorial)
            {
                int resultado = 0;
                try
                {
                    abrirConexion();
                    comando.CommandText = comando.CommandText = "INSERT INTO Editorial (id_editorial,nombre," +
                        "nacionalidad) VALUES(@ID,@NOMBRE,@NACIONALIDAD)";
                    comando.Parameters.Add(new SqlParameter("@ID", editorial.getId_editorial()));
                    comando.Parameters.Add(new SqlParameter("@NOMBRE", editorial.getNombre()));

                    if (editorial.getNacionalidad() != null)
                    {
                        comando.Parameters.Add(new SqlParameter("@NACIONALIDAD", editorial.getNacionalidad()));
                    }
                    else
                    {
                        comando.Parameters.Add(new SqlParameter("@NACIONALIDAD", DBNull.Value));
                    }
                    resultado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

            // método modificarEditorial
            public int modificarEditorial(Editorial editorial, int posicion)
            {
                int resultado;
                try
                {
                    abrirConexion();
                    comando.CommandText = "UPDATE EDITORIAL SET NOMBRE= @NOMBRE," +
                        " NACIONALIDAD= @NACIONALIDAD WHERE ID_EDITORIAL= " + posicion;
                    comando.Parameters.Add(new SqlParameter("@NOMBRE", editorial.getNombre()));
                    if (editorial.getNacionalidad() != null)
                    {
                        comando.Parameters.Add(new SqlParameter("@NACIONALIDAD", editorial.getNacionalidad()));
                    }
                    else
                    {
                        comando.Parameters.Add(new SqlParameter("@NACIONALIDAD", DBNull.Value));
                    }
                    resultado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resultado;
            }

        
            // método eliminarEditorial
            public int eliminarEditorial(int idusuario)
            {
                int resutado = 0;
                try
                {
                    comando.CommandText = "DELETE FROM EDITORIAL WHERE ID_EDITORIAL= " + idusuario;
                    abrirConexion();
                    resutado = comando.ExecuteNonQuery();
                    cerrarConexion();
                }
                finally
                {
                    if (datos != null)
                    {
                        datos.Close();
                    }
                    if (conexion != null)
                    {
                        cerrarConexion();
                    }
                }
                return resutado;
            }

        
        // MÉTODOS PARA ABRIR Y CERRAR LA CONEXIÓN CON LA BASE DE DATOS
            // abrir conexión
            public void abrirConexion()
            {
                if (!conectado)
                {
                    conexion.Open();
                    Console.WriteLine("Me he conectado");
                    conectado = true;
                }
            }

            // cerrar conexión
            public void cerrarConexion()
            {
                if (conectado)
                {
                    conexion.Close();
                    Console.WriteLine("Me he desconectado");
                    conectado = false;
                }
            }
    }
}