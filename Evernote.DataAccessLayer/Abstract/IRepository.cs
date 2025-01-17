﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Evernote.DataAccessLayer.Abstract
{
        // Irepository, RepositoryPattern'in içinde olan metod tanımlarının standartlandırılmış ve soyutlaştırılmış kavramı olarak çıkıyor.
        // Bu soyut InterFace'i ilgili klasörün altındaki repository'e implemente (vererek) ederek o Repository içindeki metodların içerisini doldurarak standart bir yapı elde ederiz.
    public interface IRepository<T>
    {
        List<T> List();

        IQueryable<T> ListQueryable();

        List<T> List(Expression<Func<T, bool>> where);

        int Insert(T obj);

        int Update(T obj);

        int Delete(T obj);

        int Save();

        T Find(Expression<Func<T, bool>> where);
    }
}
