using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SampArch.Utilities.ActionResults.CsvResult
{
    public class FluentCsvViewModel<T>
    {
        public string Content
        {
            get
            {
                string result = string.Empty;
                if (HasColumnHeader)
                    result += _processedHeader + Environment.NewLine;
                result += _processedRows;
                return result;
            }
        }
        private IEnumerable<T> _source;
        public IEnumerable<T> GetSource
        {
            get
            {
                return _source;
            }
        }
        private string _separator;
        private string _processedRows = string.Empty;
        private string _processedHeader = string.Empty;

        public bool HasColumnHeader { get; set; }
        private Dictionary<Guid, Func<T, object>> _mappings;
        private Dictionary<Guid, string> _headers;

        private Guid? LastId;

        public FluentCsvViewModel(IEnumerable<T> enumerableSource, string separator)
        {
            _source = enumerableSource;
            _mappings = new Dictionary<Guid, Func<T, object>>();
            _headers = new Dictionary<Guid, string>();
            _separator = separator;
            HasColumnHeader = false;
        }
        public FluentCsvViewModel(IEnumerable<T> enumerableSource)
            : this(enumerableSource, ";")
        {

        }

        public FluentCsvViewModel<T> IncludeColumnHeaders(bool value)
        {
            HasColumnHeader = value;
            return this;
        }
        public FluentCsvViewModel<T> WithSeparator(string separator)
        {
            _separator = separator;
            return this;
        }
        public FluentCsvViewModel<T> Map(Func<T, object> columnDef)
        {
            Guid id = Guid.NewGuid();
            _mappings.Add(id, columnDef);
            _headers.Add(id, string.Empty);
            LastId = id;
            return this;
        }
        public FluentCsvViewModel<T> WithHeader(string label)
        {
            if (null == LastId)
            {
                throw new FluentCsvException(
                    FluentCsvException.ExceptionType.MethodChainingException,
                    "WithHeader must follow Map method");
            }
            Guid validId = (Guid)LastId;
            _headers[validId] = label;
            LastId = null;
            return this;
        }

        public void Build()
        {
            ProcessContentRows();
            if (HasColumnHeader)
                ProcessHeader();

        }

        public CsvFileActionResult<T> ToActionResult(string filename)
        {
            if (string.IsNullOrEmpty(_processedRows))
                Build();

            CsvFileActionResult<T> result = new CsvFileActionResult<T>(this);
            
            result.FileName = filename;
            return result;
        }


        private void ProcessHeader()
        {
            _processedHeader = string.Join(_separator, _headers.Values.ToArray());
        }

        private void ProcessContentRows()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var row in _source)
            {
                foreach (var map in _mappings.Values)
                {
                    sb.AppendFormat("{0}{1}", map(row), _separator);
                }
                sb.Append(Environment.NewLine);
            }
            _processedRows = sb.ToString();
        }
    }
}
