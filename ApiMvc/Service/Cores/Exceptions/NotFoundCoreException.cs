﻿namespace ApiMvc.Service.Cores.Exceptions
{
    public class NotFoundCoreException : Exception
    {
        public NotFoundCoreException(string message) : base(message){ }
    }
}
