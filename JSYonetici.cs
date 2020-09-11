using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _2
{


    public class JSYonetici
    {

      static    string jslexStart = "<script type=\"text/javascript\">";
       static   string jslexEnd = "</script>";


        public static string YonlendirmeFunc(string Param1)
        {
       string YonlendirFunc = @"

                        function yonlendir() 
                        { 
                             var url='"+Param1+ @"'
                           var sonuc=setTimeout(function() { window.location=url }, 5000);

                        }                                    
";
            return YonlendirFunc;

        }

        
     
        public static string yonlendir = @"
            function yonlendir(x)
        { 
                window.location=x;
                return 0;
        }

";




        public static bool ScriptKaydet(string Script,Page Sayfa)
        {

            string jstoExecute = jslexStart + Script + jslexEnd;
            Sayfa.Page.ClientScript.RegisterClientScriptBlock(Sayfa.GetType(), "mb2", jstoExecute, false);
            return true;
        }

        public static void Auto_ScriptKaydet(string Script,Page Sayfa)
        {

            string jstoExecute = jslexStart + Script + jslexEnd;
            Sayfa.Page.ClientScript.RegisterStartupScript(Sayfa.GetType(), "mb2", jstoExecute, false);



        }

        public static void ScriptCalistir(string Function,Page Sayfa)
        {

            Sayfa.Page.ClientScript.RegisterStartupScript(Sayfa.GetType(),"mb2",Function, true);
          
        }



    }
}