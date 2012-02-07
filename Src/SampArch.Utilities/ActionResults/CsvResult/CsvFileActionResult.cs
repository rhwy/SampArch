using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SampArch.Utilities.ActionResults.CsvResult
{
    using System.Web;

    public class CsvFileActionResult<T> : ActionResult
	{
		public string Content { get; set; }
		public Encoding ContentEncoding { get; set; }
		public string FileName { get; set; }
		public string Separator { get; set; }
		private IEnumerable<T> m_source;
		private Func<T, object>[] m_columns;
		
        public CsvFileActionResult(IEnumerable<T> source)
		{
			m_source = source;
			m_columns = new Func<T, object>[] { };
			Separator = ";";
		}

        public CsvFileActionResult(FluentCsvViewModel<T> viewModel)
        {
            m_source = viewModel.GetSource;
            Content = viewModel.Content;
        }

        //private void FillContent()
        //{
        //    if (null == m_source)
        //    {
        //        return;
        //    }

        //    if (null == m_columns)
        //    {
        //        return;
        //    }

        //    StringBuilder sb = new StringBuilder();
        //    foreach (var row in m_source)
        //    {
        //        foreach (var col in m_columns)
        //        {
        //            sb.AppendFormat("{0}{1}",col(row),Separator);
        //        }
        //        sb.Append(Environment.NewLine);
        //    }
        //    Content = sb.ToString();
        //}

        //public void MapColumns(params Func<T,object>[]  cols )
        //{
        //    m_columns = cols.ToArray();
        //}

        //public void AddHeader(params string[] fullHeader)
        //{
        //    Header = string.Join(Separator,fullHeader) + Environment.NewLine;
        //}

		public override void ExecuteResult(ControllerContext context)
		{
			if (null == context)
			{
				throw new ArgumentNullException("context");
			}

			if (null == Content)
			{
				Content = string.Empty;
			}

			if (null == FileName)
			{
				FileName = "export.csv";
			}
			if (ContentEncoding == null)
			{
				ContentEncoding = Encoding.Default;
			}

			

			HttpResponseBase response = context.HttpContext.Response;
			response.Clear();
			response.ContentType = "text/csv";
			response.AddHeader(
				"Content-Disposition",
				String.Format("attachment; filename={0}", FileName));
			response.Write(Content);
			response.Flush();
		}
	}
}
