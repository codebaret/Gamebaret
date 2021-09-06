using System;
using System.Collections.Generic;
using System.Text;

namespace Games.Data.Access.DataAccessLayer
{
    public interface ITransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
