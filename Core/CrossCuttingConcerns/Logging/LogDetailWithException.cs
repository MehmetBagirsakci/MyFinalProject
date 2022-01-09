using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging
{
    public class LogDetailWithException : LogDetail
    {
        public string ExceptionMessage { get; set; }
    }
}

//Burayı ayırma sebebimiz SOLID'in Liskovs Subtitution prensibi.
//Aslında nesneler birbirine benziyor diyor diye birbirinin yerine kullanılmaz.

//Aslında ExceptionMessage propertysi LogDetail.cs içerisine yazılabilirdi
//Neden yazmadık.
//Çünkü LogDetail.cs hem normal çalışan metotlar için kullanılabilecekti.
//Hemde hata veren metotlar için kullanılabilecekti.
//İyide her operasyonda hata Exception olmayacak ki.
//Ben niye gidip Log tablosunda her kayıt için bir Exception alanı oluşturup içine NULL değeri gireyim ki
