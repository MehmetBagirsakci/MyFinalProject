﻿using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //Çıplak Class Kalmasın.
    //Eğerki bir class herhangi bir inheritance veya interface implementasyonu
    //almıyorsa anlaki ilerde problem yaşama ihtimalin yüksek.
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
