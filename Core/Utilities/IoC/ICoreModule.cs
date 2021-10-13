using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    //Tüm projelerimizde kullanabileceğimiz injectionları Core katmanına taşımalıyız.
    //Böylelikle sürekli injection yapmaktan kurtulmuş oluruz.
    //Hatırlarsak: Startup.cs içerisindeki aynı imzaya sahip başka bir metot var
    //public void ConfigureServices(IServiceCollection services)
    //ServiceCollection'ı biz vereceğiz. Yükleme işini o yapacak.
    public interface ICoreModule
    {
        //Genel bağımlılıkları yükleyecek.
        void Load(IServiceCollection serviceCollection);
    }
}
//ServiceCollection:using Microsoft.Extensions.DependencyInjection;