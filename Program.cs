using ProjektarbeteSQL.Data;
using ProjektarbeteSQL.Models;

namespace ProjektarbeteSQL
{
    public class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.Start();

            using SchoolContext db = new SchoolContext();
        }
    }
}