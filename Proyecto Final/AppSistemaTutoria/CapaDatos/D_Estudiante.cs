using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using CapaEntidades;
using ImageMagick;

namespace CapaDatos
{
    public class D_Estudiante
    {
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);

        public DataTable MostrarRegistros(string CodEscuelaP)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if ((byte[])Fila["Perfil2"] == null)
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public DataTable MostrarEstudiantesSinTutor(string CodEscuelaP, int Filas)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuMostrarEstudiantesSinTutor", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Filas", Filas);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        public DataTable BuscarRegistro(string CodeEstudiante)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEstudiante", CodeEstudiante);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if ((byte[])Fila["Perfil2"] == null)
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public DataTable BuscarRegistros(string CodEscuelaP, string Texto)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantes", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);

            foreach (DataRow Fila in Resultado.Rows)
            {
                if ((byte[])Fila["Perfil2"] == null)
                {
                    string fullImagePath = System.IO.Path.Combine(Application.StartupPath, @"../../Iconos/Perfil Estudiante.png");
                    using (MemoryStream MemoriaPerfil = new MemoryStream())
                    {
                        Image.FromFile(fullImagePath).Save(MemoriaPerfil, ImageFormat.Bmp);
                        Fila["Perfil2"] = MemoriaPerfil.ToArray();
                    }
                }
                using (MagickImage PerfilNuevo = new MagickImage((byte[])Fila["Perfil2"]))
                {
                    PerfilNuevo.Resize(20, 0);
                    Fila["Perfil2"] = PerfilNuevo.ToByteArray();
                }
            }

            return Resultado;
        }

        public DataTable BuscarEstudiantesSinTutor(string CodEscuelaP, string Texto, int Filas)
        {
            DataTable Resultado = new DataTable();
            SqlCommand Comando = new SqlCommand("spuBuscarEstudiantesSinTutor", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Comando.Parameters.AddWithValue("@CodEscuelaP", CodEscuelaP);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            Comando.Parameters.AddWithValue("@Filas", Filas);
            SqlDataAdapter Data = new SqlDataAdapter(Comando);
            Data.Fill(Resultado);
            return Resultado;
        }

        public void InsertarRegistro(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuInsertarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Estudiante.Perfil);
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Estudiante.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Estudiante.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            Comando.Parameters.AddWithValue("@Email", Estudiante.Email);
            Comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Estudiante.Telefono);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Estudiante.CodEscuelaP);
            Comando.Parameters.AddWithValue("@PersonaReferencia", Estudiante.PersonaReferencia);
            Comando.Parameters.AddWithValue("@TelefonoReferencia", Estudiante.TelefonoReferencia);
            Comando.Parameters.AddWithValue("@InformacionPersonal", Estudiante.InformacionPersonal);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void ModificarRegistro(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuActualizarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@Perfil", Estudiante.Perfil);
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.Parameters.AddWithValue("@APaterno", Estudiante.APaterno);
            Comando.Parameters.AddWithValue("@AMaterno", Estudiante.AMaterno);
            Comando.Parameters.AddWithValue("@Nombre", Estudiante.Nombre);
            Comando.Parameters.AddWithValue("@Email", Estudiante.Email);
            Comando.Parameters.AddWithValue("@Direccion", Estudiante.Direccion);
            Comando.Parameters.AddWithValue("@Telefono", Estudiante.Telefono);
            Comando.Parameters.AddWithValue("@CodEscuelaP", Estudiante.CodEscuelaP);
            Comando.Parameters.AddWithValue("@PersonaReferencia", Estudiante.PersonaReferencia);
            Comando.Parameters.AddWithValue("@TelefonoReferencia", Estudiante.TelefonoReferencia);
            Comando.Parameters.AddWithValue("@InformacionPersonal", Estudiante.InformacionPersonal);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void EliminarRegistro(E_Estudiante Estudiante)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarEstudiante", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEstudiante", Estudiante.CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void AsignarTutor(string CodEstudiante, string CodDocente)
        {
            SqlCommand Comando = new SqlCommand("spuAsignarTutor", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEstudiante", CodEstudiante);
            Comando.Parameters.AddWithValue("@CodDocente", CodDocente);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }

        public void EliminarTutor(string CodEstudiante)
        {
            SqlCommand Comando = new SqlCommand("spuEliminarTutor", Conectar)
            {
                CommandType = CommandType.StoredProcedure
            };

            Conectar.Open();
            Comando.Parameters.AddWithValue("@CodEstudiante", CodEstudiante);
            Comando.ExecuteNonQuery();
            Conectar.Close();
        }
    }
}
