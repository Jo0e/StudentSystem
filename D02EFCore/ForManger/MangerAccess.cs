using P01_StudentSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01_StudentSystem.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace P01_StudentSystem.ForManger
{
    public class MangerAccess
    {

        DataManger DataForManger { get; set; }
        DataViewer DataViewer { get; set; }
        PresentStartPage PresentStartPage { get; set; }
        public void Actions()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\r\n                            __  __                          __  __              \r\n                           |  \\/  |__ _ _ _  __ _ ___ _ _  |  \\/  |___ _ _ _  _ \r\n                           | |\\/| / _` | ' \\/ _` / -_| '_| | |\\/| / -_| ' | || |\r\n                           |_|  |_\\__,_|_||_\\__, \\___|_|   |_|  |_\\___|_||_\\_,_|\r\n                                            |___/                               \r\n");
            Console.WriteLine($" \t\t\t\t   ╔════════════════════════════╗\r\n \t\t\t\t   ║\t\t\t        ║\r\n \t\t\t\t   ║    1 - To view Data        ║\r\n \t\t\t\t   ║    2 - To Add Data\t\t║\r\n  \t\t\t\t   ║    3 - Back to last menu   ║\r\n \t\t\t\t   ║ \t\t\t        ║\r\n\t\t\t\t   ╚════════════════════════════╝\r\n");

            Console.Write($"                                        ->Enter Your chose: ");
            Console.ResetColor();
            //Console.Write($"                                                ");
            string typeOfAction = Console.ReadLine();
            while (typeOfAction != "1" && typeOfAction != "2" && typeOfAction != "3")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->PLeas Enter One of Above: ");
                Console.ResetColor();
                typeOfAction = Console.ReadLine();
            }

            if (typeOfAction == "1")
            {
                //view data
                DataViewer = new DataViewer(new ApplicationDbContext());
                DataViewer.DataView();

            }
            else if (typeOfAction == "2")
            {
                //add data
                DataForManger = new DataManger(new ApplicationDbContext());
                DataForManger.AddData();

            }
            else if (typeOfAction == "3")
            {
                PresentStartPage = new PresentStartPage();
                Console.Clear();
                PresentStartPage.PresentStartPageCall();

            }

        }

    }
}
