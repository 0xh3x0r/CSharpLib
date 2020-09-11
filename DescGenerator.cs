using System;
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

            if (targetPage.MetaKeywords == null) targetPage.MetaKeywords = "";
            int meta_length = targetPage.MetaKeywords.Length;
            if (meta_length > 0)
             words[0] = (targetPage.MetaKeywords[meta_length - 1] == ',') ? words[0] : words[0].Insert(0, ",")  ; // if the last keywords ends with ',' add word to start else add without starting ','
            words[0] += ",";
            oneline = words[0];
            int last_item_excluded = words.Length - 1;
            for (int i = 1; i < last_item_excluded; i++)
            {
                words[i] += ","; 
                oneline += words[i];
            }
            if(last_item_excluded != 0) oneline += words[words.Length-1]; // add last item too if its not the only word in the list


            targetPage.MetaKeywords += oneline;
        }



    }
}