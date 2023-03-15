using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard
{
    public partial class CommanDashboard:ITableView
    {
        public static int tableWidth = 150;
        public void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";
            int i = 1;
            foreach (string column in columns)
            {
                /*if (i++ ==4)
                    width = 30;*/
                if (columns.Length > 8)
                {
                    if (i == 9) width += 6;

                }
                else if (columns.Length > 2)
                {
                    if (i == 1) width = 8;
                    else if (i == 2) width = 16;
                    else if (i == 4) width += 22;
                    else if (i == 5) width = 16;

                }
                i++;
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}

