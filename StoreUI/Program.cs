using System;

namespace StoreUI
{
  public class Program
    {
 
        static void Main(string[] args)
        {
            MenuFactory.GetMenu("manager").Start();
        }

    }
}
