using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants.Messages
{
    public static class AppMessages
    {
        public static string MaintenanceTime = "Sistem Bakımda.";
        public static string AuthorizationDenied = "Yetkiniz Yok";
        public static string SendEmail = "Mailinizi kontrol ediniz";
        public static string ChangePassword = "Şifreniz başarıyla değiştirildi";
        public static string NotChangePassword = "Şifre değiştirilemedi";
        public static string EmailConfirmed = "Hesabınız aktif edildi";
        public static string NotEmailConfirmed = "Hesabınız aktif edilmedi";
        public static string WrongCode = "Hatalı kod";
        public static string Reminding = "Girdiğiniz mail size ait olmalı";
        public static string MissingInformation = "Eksik bilgi girdiniz transfer gerçekleşmedi";
    }
}
