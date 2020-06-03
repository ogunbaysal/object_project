using System;
using System.Collections.Generic;
using System.Text;

namespace mobile.Models.Enums
{
    public class StorageKeys
    {
        public string Value { get; set; }
        private StorageKeys(string value)
        {
            Value = value;
        }
        public static StorageKeys ACCESS_TOKEN { get { return new StorageKeys("access_token"); } }
        public static StorageKeys BASKET { get { return new StorageKeys("basket"); } }
    }
}
