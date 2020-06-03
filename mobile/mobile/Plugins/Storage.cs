using mobile.Plugins.Interface;
using Plugin.SecureStorage;
using Plugin.SecureStorage.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Plugins
{
    public class Storage : IStorage
    {
        public ISecureStorage SecureStorage => CrossSecureStorage.Current;
    }
}
