using DataOperations.DBEngine;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CSOutreach.UI
{
    public class MenuRender
    {
        private static string DynamicMenuString;
        public static string DynamicMenu
        {
            get
            {
                return DynamicMenuString;
            }
        }
        public static List<MenuElement> DynamicMenuItems
        {
            get
            {
                List<MenuElement> MenuItems = new List<MenuElement>();
                DBManager DbManager = new DBManager();
                DataSet MenuRaw = DbManager.ExecuteReadSP("ListAllMenuItems");
                foreach(DataRow Row in MenuRaw.Tables[0].Rows)
                {
                    MenuElement MnuElement = new MenuElement();
                    MnuElement.MenuName = Row[1].ToString();
                    MnuElement.MenuURL = Row[2].ToString();
                    MenuItems.Add(MnuElement);
                }
                return MenuItems;
            }
        }

        public static void RenderDynamicMenu()
        {

            DynamicMenuString = "<li class=\"dropdown\">" +
                   "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\">Activities<span class=\"caret\"></span></a>" +
                   "<ul class=\"dropdown-menu\" role=\"menu\">";
            foreach(MenuElement Element in DynamicMenuItems)
            {
                DynamicMenuString += "<li><a href=\"" + Element.MenuURL + "\">" + Element.MenuName + "</a></li>";
            }
            DynamicMenuString += "</ul></li>";

        }
    }
}