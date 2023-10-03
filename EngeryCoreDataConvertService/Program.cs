using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace EngeryCoreDataConvertService
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            HostFactory.Run(x =>
            {
                x.Service<SearchClass>(s =>
                {
                    s.ConstructUsing(name => new SearchClass());
                    _ = s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });

                //Windowsサービスの設定
                x.RunAsLocalSystem();
                x.SetDescription("This is EngeryCoreDataConvertService");
                x.SetDisplayName("aa_EngeryCoreDataConvertService");
                x.SetServiceName("aa_EngeryCoreDataConvertService");
            });
        }
    }
}
