

using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoWebApi
{
	public class CsvOutputFormatter : TextOutputFormatter
	{
		public CsvOutputFormatter()
		{
			SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
			SupportedEncodings.Add(Encoding.UTF8);
			SupportedEncodings.Add(Encoding.Unicode);
		}

		protected override bool CanWriteType(Type type)
		{
			if (typeof(Employee).IsAssignableFrom(type)
				|| typeof(IEnumerable<Employee>).IsAssignableFrom(type))
			{
				return base.CanWriteType(type);
			}
			return false;
		}

		public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
		{
			var response = context.HttpContext.Response;
			var buffer = new StringBuilder();

			if ((IEnumerable<Employee>)context.Object is IEnumerable<Employee>)
			{
				foreach (var employee in (IEnumerable<Employee>)context.Object)
				{
					FormatCsv(buffer, employee);
				}
			}
			else
			{
				FormatCsv(buffer, (Employee)context.Object);
			}

			using (var writer = context.WriterFactory(response.Body, selectedEncoding))
			{
				return writer.WriteAsync(buffer.ToString());
			}
		}

		private static void FormatCsv(StringBuilder buffer, Employee employee)
		{
			
				buffer.AppendLine($"{employee.Id},\"{employee.Name},\"{employee.Gender},\"{employee.Dept}\"");
		
		}
	}
}
