﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace _DescGenerator
{



    public static class DescGenerator
    {

       
     
       
        public static void AppendMetaTags(Page targetPage, string[] words)
        {
            HtmlMeta metaTag = new HtmlMeta { Name = "keywords" };
            string oneline = ""; // Var to convert keywods into one line string
            words[0] = (targetPage.MetaDescription.Length > 0) ? words[0].Insert(0, ",") : words[0]; // if there are already keywords in descrtiption add ',' to first keyword
            words[0] += ",";
            oneline = words[0];
            int last_item_excluded = words.Length - 1;
            for (int i = 1; i < last_item_excluded; i++)
            {
                words[i] += ","; 
                oneline += words[i];
            }
            oneline += words[words.Length-1]; // add last item too 


            targetPage.MetaKeywords += oneline;
        }



    }
}