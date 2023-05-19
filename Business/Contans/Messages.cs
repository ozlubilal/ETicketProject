using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contans
{
    public class Messages
    {
        public static string AddedSuccess="Ekleme işlemi başarılı";

        public static string DeletedSuccess = "Silme işlemi başarılı";

        public static string UpdatedSuccess = "Güncelleme işlemi başarılı";

        public static string AccesTokenCreated = "Token bağlantı işlemi başarılı";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string UserSuccesfulLogin = "Giriş İşlemi başarılı";

        public static string PasswordError = "Hatalı parola";

        public static string UserRegistered = "Kayıt işlemi başarılı";

        public static string UserAlreadyExists = "Bu email adresinde kullanıcı zaten kayıtlı";

        public static string BusTypeNameAlreadyExists = "Bu isimde otobüs türü vardır";

        public static string GenderNameAlreadyExist = "Bu isimde cinsiyet vardır";

        public static string CityNameAlreadyExists = "Bu isimde şehir vardır";

        public static string OperationClaimNameNameAlreadyExist = "Bu isimde yetki adı vardır";

        public static string TownNameAlreadyExists = "Bu isimde ilçe adı vardır";

        public static string TripStateAlreadyExists = "Bu isimde  adı vardır";

        public static string UserIdAlreadyExists = "Bu kullanıcı tanımlı yetkilendirme vardır";

        internal static string customerAlreadyExistsByIdenityNumber = "Bu Tc kimlik numarasına ait müşteri  vardır";
        internal static string userUpdated = "Kullanıcı güncellendi";
    }
}
