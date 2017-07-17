/* Author : Aron Sajan Philip
 * 
 * Description
 * -------------------------
 * Class designed for collecting page information in the student module. All the page information in the student module is
 * stored in the PageInfo.Resx file. This class prepares a dictionary for PageInfo and stores it in memory as a Static memory
 * object and helps in faster retrieval of page URL thus facilitates in page redirection
 * */

using StudentEntity.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace StudentEntity.PageTraversal
{
    public static class TraverseManager
    {
       static Dictionary<PageData, string> PageDictionary = new Dictionary<PageData, string>();
        static TraverseManager()
        {
            BuildPageDictionary();
        }

        private static void BuildPageDictionary()
        {
            ResourceManager PageResource = new ResourceManager("StudentEntity.PageTraversal.PageInfo", Assembly.GetExecutingAssembly());
           ResourceSet Resources= PageResource.GetResourceSet(CultureInfo.CurrentCulture, true, true);
           foreach(DictionaryEntry ResourceEntry in Resources)
           {
               PageDictionary.Add((PageData)(Enum.Parse(Type.GetType("StudentEntity.PageTraversal.PageData"),ResourceEntry.Key.ToString(), false)), Convert.ToString(ResourceEntry.Value));
           }
        }
        public static string GetPage(PageData RequestedPage)
        {
            string AbsolutePagePath=string.Empty;
            if(PageDictionary.ContainsKey(RequestedPage))
            {
              string PagePath  = PageDictionary[RequestedPage];

              AbsolutePagePath = string.Format("{0}/{1}", Helper.GetConfigValue("URLRoot"), PagePath);
            }
            else
            {
                throw new Exception("Requested page not found exception");
            }
            return AbsolutePagePath;
        }

    }
}
