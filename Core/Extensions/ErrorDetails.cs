using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
    public class ErrorDetails
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

//Sistem bir hata verdiğinde Kullanıcıların hatalarımızı açık olarak görmesini istemeyiz.
//Hata durumunda kullancılara sistemimiz hakkında bilgi vermemeliyiz.
//Eğer hatalarımızı detaylı bir şekilde gösterirsek kullanıcı bizim hatalarımızdan yararlanarak, sistemimizi hacklemeye girişebilir.

//Aslında biz bir Middleware yazacağız. Bu sınıfa Middleware de ihtiyacımız olacak.

//I M P R O V M E N T - İ Y İ L E Ş T İ R M E
//public int InfoCode { get; set; } Kendimize özel bir info kodu oluşturup, hangi kodun hangi exceptiona karşılık geldiğini buraya ekleyebiliriz.
//Kullanıcı bizi arayıp 18207 nolu hatayı alıyorum. Bu hata neden oluştu diyebilir.
