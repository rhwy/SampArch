using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Utilities.ActionResults.CsvResult
{
    public class FluentCsvException : Exception
    {
        private string _message;
        private string _template;


        public enum ExceptionType
        {
            MethodChainingException,
            ArgumentNotMatchException,
            MemberSerializeException
        }

        public ExceptionType Type { get; private set; }

        public FluentCsvException(ExceptionType type, string message)
        {
            Type = type;
            SetMessageOnType(type, message);
        }
        private void SetMessageOnType(ExceptionType type, string message)
        {
            switch (type)
            {
                case ExceptionType.MethodChainingException:
                    _template = "You can not chain these methods : {0}";
                    break;
                case ExceptionType.ArgumentNotMatchException:
                    _template = "argument not match : {0}";
                    break;
                case ExceptionType.MemberSerializeException:
                    _template = "the colum member can not be serialized to string: {0}";
                    break;
                default:
                    _template = "{0}";
                    break;
            }
            _message = string.Format(_template, message);
        }

        public override string Message
        {
            get
            {
                return _message;
            }
        }
    }
}
