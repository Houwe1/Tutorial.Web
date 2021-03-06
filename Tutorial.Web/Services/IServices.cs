﻿using System.Collections.Generic;
using Tutorial.Web.Model;

namespace Tutorial.Web.Services
{
    public interface IServices<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T newModel);
    }
}
