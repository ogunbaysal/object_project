using System;
using System.Collections.Generic;
using System.Text;

namespace client.Api.Core
{
    class MessageException : Exception
    {
        public MessageException(string message) : base(message)
        { }
    }
}
