using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Efmap;
using Efmap.Helpers;
using SampArch.Infrastructure.EF;
using Efmap.Bootstrap;
using HibernatingRhinos.Profiler.Appender.EntityFramework;

namespace SampArch.Infrastructure.EF.Validate
{
    class Program
    {
        static void Main(string[] args)
        {
            EntityFrameworkProfiler.Initialize();

            //define the data class to use to do additional db shema setup
            EntityMapHelper.SetDbInitializer<SampArchContext>(new SampArchDbInitializer());
            
            //define the data class to use to initialize database through entity
            EntityMapHelper.SetEntityInitializer<SampArchContext>(new SampArchEntityInitializer());

            EntityMapHelper.Initialize<SampArchContext>().With<DropCreateAlways<SampArchContext>>();


            //that's all, you can now use it and directly get the default data as in the exemple
            using (SampArchContext db = new SampArchContext("SampArchConsoleTests"))
            {
                Console.WriteLine("Press enter so print sql initialization script");
                Console.ReadLine();
                Console.Clear();
                string sql = db.GetSqlCreationScript();
                Console.WriteLine(sql);
                Console.WriteLine("Press enter so print generated Edmx script");
                Console.ReadLine();
                Console.Clear();
                string edmx = db.GetGeneratedEdmx();
                Console.WriteLine(edmx);

                Console.WriteLine("Press enter to view default loaded data");
                Console.ReadLine();
                Console.Clear();

                
                Console.WriteLine("default roles : ");
                db.Roles.ToList().ForEach(i => Console.WriteLine(" - " + i.Name));
                Console.WriteLine();

                Console.WriteLine("default users : ");
                db.Users.ToList().ForEach(i => Console.WriteLine(" - " + i.Name));
                Console.WriteLine();
                
                Console.WriteLine("startup idea : ");
                db.Ideas.ToList().ForEach(i => {
                    Console.WriteLine(" - [Up:{0},Down:{1}] \"{2}\" by {3} ({4} comments)", i.Votes.Up, i.Votes.Down, i.Title, i.Author, i.Comments.Count);
                });
                Console.WriteLine();
                
                Console.WriteLine("introduction post : ");
                db.Posts.ToList().ForEach(i =>
                {
                    Console.WriteLine(" - \"{0}\" by {1} ({2} comments)", i.Title, i.Author, i.Comments.Count);
                });
                Console.WriteLine();


                
            }

            
            Console.Read();

        }
    }
}

