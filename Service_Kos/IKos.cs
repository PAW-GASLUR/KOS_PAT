using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Service_Kos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IKos
    {
        [OperationContract]
        string pemesanan(string IDPemesanan, string NamaCustomer, string NoTelepon, int JumlahPemesanan, string IDKos);//method proses input data

        [OperationContract]
        string editPemesanan(string IDPemesanan, string NamaCustomer, string No_telpon);

        [OperationContract]
        string deletePemesanan(string IDPemesanan);

        [OperationContract]
        List<CekKos> ReviewKos(); //nampilin data yang ada di database (select all) menampilkan isi dari yang ada contract

        [OperationContract]
        List<DetailKos> DetailKos();

        [OperationContract]
        List<Pemesanan> Pemesanan();
        string GetData(int value);

        //Login & Register
        [OperationContract]
        string Login(string username, string password);
        [OperationContract]
        string Register(string username, string password, string kategori);
        [OperationContract]
        string UpdateRegister(string username, string password, string kategori, int id);
        [OperationContract]
        string DeleteRegister(string username);
        [OperationContract]
        List<DataRegister> DataRegist();
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }


    [DataContract]
    public class CekKos //daftar lokasi nongrong
    {
        [DataMember]
        public string IDKos { get; set; } //variable dari public class

        [DataMember]
        public string NamaKos { get; set; }

        [DataMember]
        public string Alamat { get; set; }

        [DataMember]
        public string Deskripsi { get; set; }
    }

    [DataContract]
    public class DetailKos //menampilkan detail lokasi
    {
        [DataMember]
        public string IDKos { get; set; } //variable dari public class

        [DataMember]
        public string NamaKos { get; set; }

        [DataMember]
        public string Alamat { get; set; }

        [DataMember]
        public string Deskripsi { get; set; }

        [DataMember]
        public int JumlahKamar { get; set; }
    }


    [DataContract]
    public class Pemesanan //crate
    {
        [DataMember]
        public string IDPemesanan { get; set; } //variable dari public class

        [DataMember]
        public string NamaCustomer { get; set; } // method

        [DataMember]
        public string NoTelepon { get; set; }

        [DataMember]
        public int JumlahPemesanan { get; set; }

        [DataMember]
        public string Kos { get; set; }
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Service_Kos.ContractType".

}
