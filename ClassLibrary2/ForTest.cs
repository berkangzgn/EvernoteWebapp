﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.BusinessLayer
{
    public class ForTest
    {
        public ForTest()
        {
            DataAccessLayer.DatabaseContext db = new DataAccessLayer.DatabaseContext();
                // Database tablo çağırarak oluşturmak için;
            //db.Users.ToList
            
             db.Database.CreateIfNotExists();
        }
    }
}
