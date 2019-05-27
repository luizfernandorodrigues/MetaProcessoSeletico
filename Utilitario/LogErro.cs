using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Utilitario
{
    public static class LogErro
    {
        public static void GravaLog(string mensagem)
        {
            try
            {
                StreamWriter sw = null;
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\log.txt", true);
                sw.WriteLine(DateTime.Now.ToString() + ": " + mensagem);
                sw.Flush();
                sw.Close();
            }
            catch (Exception ex)
            {
                GravaLog(ex.Message);
            }
        }
    }
}
