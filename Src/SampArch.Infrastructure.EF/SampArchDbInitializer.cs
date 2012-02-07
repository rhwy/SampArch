using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Efmap.Bootstrap;
using System.Reflection;
using System.IO;

namespace SampArch.Infrastructure.EF
{
    public class SampArchDbInitializer : DbInitializer
    {
        public SampArchDbInitializer()
        {
            this.AddCommand(GetAspNetSqlMemberShipFromResources());
        }

        public string GetAspNetSqlMemberShipFromResources()
        {
            string result = string.Empty;

            Assembly asm = this.GetType().Assembly;
            string assemblyName = asm.GetName().Name;
            using (Stream stream = asm.GetManifestResourceStream(assemblyName+".aspnetSqlMembership.sql"))
            using (StreamReader reader = new StreamReader(stream))
            {
                result = reader.ReadToEnd();
            }

            result = result.Replace("{{dbname}}", InfrastructureConfiguration.DB_NAME);
            return result;
        }
    }
}
