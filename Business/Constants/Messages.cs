using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Yeni araba eklendi";
        public static string CarNameInvalid= "Araç ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string CarListed = "Araçlar listelendi";

        public static string CarDeleted = "Araç Silindi";

        public static string CarUpdated = "Araç bilgileri güncellendi";
        public static string BrandAdded;

        public static string BrandDeleted ="Marka silindi";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandListed = "Markalar listelendi";
        public static string ColorUpdated = "REnk güncellendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ModelDeleted = "Model silindi";
        public static string ModelUpdated = "Model güncellendi.";
        public static string ModelListed = "Modeller listelendi";

        public static string ColorAdded = "Yeni renk eklendi";

        public static string CarImageCountOfCarError { get; internal set; }
        public static SerializationInfo AuthorizationDenied { get; internal set; }
    }
}
