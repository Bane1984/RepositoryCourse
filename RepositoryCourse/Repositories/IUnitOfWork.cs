﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryCourse.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ICourse Courses { get; set; }
        IAutor Autors { get; set; }
        int Complete();
        void Start();
        void Commit();
        void Dispose();
    }
}
