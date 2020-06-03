using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Plugins.Interface
{
    public interface IStorage
    {
        ISecureStorage SecureStorage { get; }
    }
}
