using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SampArch.Utilities
{
    public class HttpRequestSingleton<T>
    {
        private const string KEY = "RequestSingleton";
        private static readonly object _syncRoot = new object();

        private static string _keyRequestType
        {
            get
            {
                return KEY + typeof(T).Name;
            }
        }
        private T _value;
        private bool _isSet;

        public T Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                _isSet = true;
            }
        }
        public bool IsSet
        {
            get
            {
                return _isSet;
            }
        }
        public static HttpRequestSingleton<T> Instance
        {
            get
            {
                lock (_syncRoot)
                {
                    if (HttpContext.Current.Items[_keyRequestType] == null)
                    {
                        HttpContext.Current.Items[_keyRequestType] = new HttpRequestSingleton<T>();
                    }
                }
                return HttpContext.Current.Items[_keyRequestType] as HttpRequestSingleton<T>;
            }
        }

        private HttpRequestSingleton()
        {
        }
    }
}
