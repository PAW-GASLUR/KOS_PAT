using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service_Kos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Kos : IKos
    {
        string constring = "Data Source=DESKTOP-5L26KM2;Initial Catalog=KOS;Persist Security Info=True;User ID=sa; Password=musafak93";
        SqlConnection connection;
        SqlCommand com; //untuk mengoneksi database ke visual studio
        public List<DataRegister> DataRegist()
        {
            List<DataRegister> list = new List<DataRegister>();
            try
            {
                string sql = "select ID_login, Username, Password, Kategori from Login";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    DataRegister data = new DataRegister();
                    data.id = reader.GetInt32(0);
                    data.username = reader.GetString(1);
                    data.password = reader.GetString(2);
                    data.kategori = reader.GetString(3);
                    list.Add(data);
                }
                connection.Close();
            }
            catch (Exception e)
            {
                e.ToString();
            }
            return list;
        }

        public string deletePemesanan(string IDPemesanan)
        {
            string a = "gagal";
            try
            {
                string sql = "delete from dbo.Pemesanan where ID_reservasi = '" + IDPemesanan + "'";
                connection = new SqlConnection(constring); //fungsi konek ke database
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string DeleteRegister(string username)
        {
            try
            {
                int id = 0;
                string sql = "select ID_login from dbo.Login where Username = '" + username + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql, connection);
                connection.Open();
                SqlDataReader reader = com.ExecuteReader();
                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                }
                connection.Close();
                string sql2 = "delete from Login where ID_login" + id + "";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        public List<DetailKos> DetailKos()
        {
            List<DetailKos> LokasiFull = new List<DetailKos>(); //proses untuk mendeclare nama list yang telah dibuat dengan nama baru
            try
            {
                string sql = "select ID_Kos, Nama_Kos, Alamat, Deskripsi, Jumlah_Kamar from dbo.KOS"; //Declare query
                connection = new SqlConnection(constring); //fungsi koneks ke database
                com = new SqlCommand(sql, connection); //proses execute query
                connection.Open(); //membuka koneksi
                SqlDataReader reader = com.ExecuteReader(); //menampilkan data query
                while (reader.Read())
                {
                    //nama class
                    DetailKos data = new DetailKos(); //deklarasi data, mengambil 1persatu dari database

                    //bentuk array
                    data.IDKos = reader.GetString(0); //0 itu index, ada dikolom berapa di string sql diatas
                    data.NamaKos = reader.GetString(1);
                    data.Alamat = reader.GetString(2);
                    data.Deskripsi = reader.GetString(3);
                    data.JumlahKamar = reader.GetInt32(4);
                    LokasiFull.Add(data); //mengumpulkan data yang awalnya array
                }
                connection.Close(); //menutup akses ke database
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return LokasiFull;
        }

        public string editPemesanan(string IDPemesanan, string NamaCustomer, string No_telpon)
        {
            string a = "gagal";
            try
            {
                string sql = "update dbo.PEMESANAN set Nama_Customer = '" + NamaCustomer + "', No_Telp = '" + No_telpon + "'" +
                    "where ID_Reservasi = '" + IDPemesanan + "'";
                connection = new SqlConnection(constring); //fungsi konek database
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public string GetData(int value)
        {
            throw new NotImplementedException();
        }

        public string Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelepon, int JumlahPemesanan, string IDKos)
        {
            string a = "gagal";
            try
            {
                string sql = "insert into dbo.PEMESANAN values ('" + IDPemesanan + "','" + NamaCustomer + "','" + NoTelepon + "', " + JumlahPemesanan + ",'" + IDKos + "')";
                connection = new SqlConnection(constring); //fungsi konek ke database
                com = new SqlCommand(sql, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                string sql2 = "update dbo.KOS set Jumlah_Kamar = Jumlah_Kamar - " + JumlahPemesanan + " where ID_Kos = '" + IDKos + "'";
                com = new SqlCommand(sql2, connection); //untuk konek ke database
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
                a = "sukses";
            }
            catch (Exception es)
            {
                Console.WriteLine(es);
            }
            return a;
        }

        public List<Pemesanan> Pemesanan()
        {
            throw new NotImplementedException();
        }

        public string Register(string username, string password, string kategori)
        {
            throw new NotImplementedException();
        }

        public List<CekKos> ReviewKos()
        {
            throw new NotImplementedException();
        }

        public string UpdateRegister(string username, string password, string kategori, int id)
        {
            throw new NotImplementedException();
        }
    }
}
