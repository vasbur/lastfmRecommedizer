using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lastfmRecommedizer.WebServer
{
    static class Error404Page
    {
        static public string getPage()
        {
            StreamReader st = new StreamReader("C:\\GIT\\GoodProjects\\lastfmRecommedizer\\lastfmRecommedizer\\lastfmRecommedizer\\WebServer\\error404.html");
            string result = "";
            while (!st.EndOfStream)
                result += st.ReadLine();

            return result;
        }
    }
}
