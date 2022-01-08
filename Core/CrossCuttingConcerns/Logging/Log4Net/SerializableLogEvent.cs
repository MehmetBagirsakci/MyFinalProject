using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializableLogEvent
    {
        LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        //Loglama datasının içine ne koymak istiyorsak buraya onu yazıyoruz.
        //Ornegin loglanacak datanin icine User bilgisinide girebiliriz.

        public object Message => _loggingEvent.MessageObject;

    }
}
//Loglanacak datanin içinde ne olacaksa burada yazılır.

//LoggingEvent : using log4net.Core;