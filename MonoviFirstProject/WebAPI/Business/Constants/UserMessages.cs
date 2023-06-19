using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class UserMessages
    {
        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserUpdated = "Kullanıcı Güncellendi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string UserFound = "Kullanıcı bulundu";
        public static string UsersList = "Kullanıcıların bilgileri listelendi";
        public static string OneUsersList = "Kullanıcı bilgileri listelendi";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserRegistered = "Kayıt oldunuz";
        public static string PasswordError = "Şifre hatalı";

        public static string SuccesfulLogin = "Sisteme giriş başarılı";
        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";
        public static string AccessTokenNotCreated = "Access token oluşturulamadı";
        public static string AuthorizationDenied = "Yetkiniz yok!";

        public static string MailAvailable = "Mail uygun";
    }
}
