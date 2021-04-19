using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi.";
        public static string CarNameCharacterLimit = "Araba eklenmedi. Araba ismi minimum 2 karakter olmalıdır.";
        public static string CarCostGreaterThanZero = "Araba eklenmedi. Araba günlük fiyatı 0'dan büyük olmalıdır.";
        public static string CarDeleted = "Araba silindi.";
        public static string CarUpdated = "Araba güncellendi.";
        public static string CarGetAll = "Arabalar listelendi.";

        public static string MaintenanceTime = "Bakım zamanı.";


        public static string BrandAdded = "Marka eklendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";
        public static string BrandGetAll = "Markalar listelendi.";


        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi.";
        public static string ColorUpdated = "Renk güncellendi.";
        public static string ColorGetAll = "Renkler listelendi.";


        public static string RentalAdded = "Araba kiralandı.";
        public static string RentalAddedError = "Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string RentalDeleted = "Araba kiralanması silindi.";
        public static string RentalDeletedError = "Arabanın silinebilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string RentalUpdated = "Araba kiralanması güncellendi.";
        public static string RentalUpdatedError = "Arabanın güncellenebilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string RentalGetAll = "Kiralanan arabalar listelendi.";


        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerGetAll = "Müşteriler listelendi.";


        public static string UserAdded = "Kullanıcı eklendi.";
        public static string UserDeleted = "Kullanıcı silindi.";
        public static string UserUpdated = "Kullanıcı güncellendi.";
        public static string UserGetAll = "Kullanıcılar listelendi.";
        public static string UserRentals = "Kullancının kiraladığı araçlar.";

        public static string CarImageAdded = "Arabaya ait resim eklendi";
        public static string CarImageDeleted = "Arabaya ait resim silindi.";
        public static string CarImageUpdated = "Arabaya ait resim güncellendi.";
        public static string CarImageGetAll = "Arabaya ait tüm resimler.";

        public static string CarImageLimitExceeded = "Arabaya ait resim sınırı.";


        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Başarılı giriş";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string AccessTokenCreated = "Token oluşturuldu";

        public static string NotCustomerFindexPoint= "Müşteri findeks puanı 0-1900 arasında olmalıdır.";

        public static string CustomerScoreIsInsufficient = "Müşteri findeks puanı yetersiz.";

        public static string RentalControlSucces = "Belirtilen tarihler arası kiralama için uygundur.";
        public static string RentalControlError = "Belirtilen tarihler arası araç başkası tarafından kiralanmıştır.";

        public static string ThereIsACreditCard = "Kredi kartı bilgileri sistemde bulunmaktadır.";

        public static string AddUserAsCustomerError = "Kullanıcı başarıı ile müşteri olarak eklendi.";
        public static string AddUserAsCustomerSuccess = "Kullanıcı müşteri olarak eklenemedi.";
    }
}
