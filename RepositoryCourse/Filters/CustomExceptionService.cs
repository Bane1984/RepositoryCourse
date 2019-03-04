using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryCourse.Filters
{
    public class CustomExceptionService
    {
        public void ThrowItemNotFoundIzuzetak()
        {
            throw new ItemNotFoundIzuzetak("Testni izuzetak!");
        }
    }

    public class ItemNotFoundIzuzetak : Exception
    {
        public ItemNotFoundIzuzetak(string message) : base(message)
        {
        }

        public ItemNotFoundIzuzetak(string message, Exception ex) : base(message, ex)
        {
        }
    }
}
