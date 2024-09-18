using P01_StudentSystem.Data;
using P01_StudentSystem.ForManger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem
{
    public class PresentStartPage
    {
        MangerAccess MangerAccess { get; set; }
        StudentAccess StudentAccess { get; set; }

        public void WelcomeBanner()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"\t\t╔════════════════════════════════════════════════════════════════════╗\r\n\t\t║___██╗____██╗███████╗██╗______██████╗_██████╗_███╗___███╗███████╗___║\r\n\t\t║___██║____██║██╔════╝██║_____██╔════╝██╔═══██╗████╗_████║██╔════╝___║\r\n\t\t║___██║_█╗_██║█████╗__██║_____██║_____██║___██║██╔████╔██║█████╗_____║\r\n\t\t║___██║███╗██║██╔══╝__██║_____██║_____██║___██║██║╚██╔╝██║██╔══╝_____║\r\n\t\t║___╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║_╚═╝_██║███████╗___║\r\n\t\t║____╚══╝╚══╝_╚══════╝╚══════╝_╚═════╝_╚═════╝_╚═╝_____╚═╝╚══════╝___║\r\n\t\t║____________________________________________________________________║\r\n\t\t╚════════════════════════════════════════════════════════════════════╝");
            Console.ResetColor();
        }
        public void PresentStartPageCall()
        {
            #region inm
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            //Console.WriteLine($"\t\t╔════════════════════════════════════════════════════════════════════╗\r\n\t\t║___██╗____██╗███████╗██╗______██████╗_██████╗_███╗___███╗███████╗___║\r\n\t\t║___██║____██║██╔════╝██║_____██╔════╝██╔═══██╗████╗_████║██╔════╝___║\r\n\t\t║___██║_█╗_██║█████╗__██║_____██║_____██║___██║██╔████╔██║█████╗_____║\r\n\t\t║___██║███╗██║██╔══╝__██║_____██║_____██║___██║██║╚██╔╝██║██╔══╝_____║\r\n\t\t║___╚███╔███╔╝███████╗███████╗╚██████╗╚██████╔╝██║_╚═╝_██║███████╗___║\r\n\t\t║____╚══╝╚══╝_╚══════╝╚══════╝_╚═════╝_╚═════╝_╚═╝_____╚═╝╚══════╝___║\r\n\t\t║____________________________________________________________________║\r\n\t\t╚════════════════════════════════════════════════════════════════════╝");
            Console.WriteLine($"\r\n                              __  __      _        __  __              \r\n                             |  \\/  |__ _(_)_ _   |  \\/  |___ _ _ _  _ \r\n                             | |\\/| / _` | | ' \\  | |\\/| / -_| ' | || |\r\n                             |_|  |_\\__,_|_|_||_| |_|  |_\\___|_||_\\_,_|\r\n                                                                       \r\n");
            Console.WriteLine($" \t\t\t\t   ╔════════════════════════════╗\r\n \t\t\t\t   ║\t\t\t        ║\r\n \t\t\t\t   ║    1 - You are a Manager   ║\r\n \t\t\t\t   ║    2 - You are a Student   ║\r\n  \t\t\t\t   ║    3 - Exit                ║\r\n \t\t\t\t   ║ \t\t\t        ║\r\n\t\t\t\t   ╚════════════════════════════╝\r\n");
            Console.Write($"                                        ->Enter Your chose: ");
            Console.ResetColor();
            //Console.Write($"                                                ");
            string typeOfUser = Console.ReadLine();
            while ( typeOfUser !="1" && typeOfUser !="2" && typeOfUser != "3")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"                                        ->PLeas Enter One of Above: ");
                Console.ResetColor();
                typeOfUser = Console.ReadLine();

            }
            #endregion
            if (typeOfUser == "1")
            {
                MangerAccess = new MangerAccess();
                MangerAccess.Actions();
            }
            else if (typeOfUser == "2") 
            {
                StudentAccess = new StudentAccess();
                StudentAccess.Verifying();

            }
            else if (typeOfUser == "3") { }
            
        }
    }
}
