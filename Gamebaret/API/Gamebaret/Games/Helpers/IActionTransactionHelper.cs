﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace Games.Helpers
{
    public interface IActionTransactionHelper
    {
        void BeginTransaction();
        void EndTransaction(ActionExecutedContext filterContext);
        void CloseSession();
    }
}
