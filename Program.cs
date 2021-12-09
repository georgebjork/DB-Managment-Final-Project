using System;
using System.Collections.Generic;


namespace DB_Managment_Final_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            String select = "SELECT s.name ";
            String from = "FROM School s ";
            String where = "WHERE ";

            Database db = new Database();

            String command = "";
            Console.Write("Do you want to connect to the database(y/n): ");
            command = Console.ReadLine();
            if (command == "y")
            {
                db.connect();
            }

            Console.WriteLine("Welcome to the college finder! This application will help you find a college that is right for you!");
            Console.WriteLine();

            while (command != "stop")
            {

                Console.WriteLine("[0] Filter by State");
                Console.WriteLine("[1] Filter by major name");
                Console.WriteLine("[2] Filter by Degree name");
                Console.WriteLine("[3] Filter by EC");
                Console.WriteLine();


                Console.Write("Select an option: ");
                command = Console.ReadLine();
                Console.WriteLine();

                if (command == "0")
                {
                    while (command != "quit")
                    {
                        Console.WriteLine("Type quit to quit");
                        Console.Write("Enter a state abbeviation: ");
                        command = Console.ReadLine();
                        Console.WriteLine();

                        db.Execute("exec sortState " + "\'" + command + "\'");
                    }

                }
                else if (command == "1")
                {
                    while (command != "quit")
                    {
                        Console.WriteLine("Type quit to quit");
                        Console.Write("Enter the name of a major (ex: Computer Science): ");
                        command = Console.ReadLine();

                        db.Execute("exec schoolWithMajor " + "\'" + command + "\'");
                    }

                }
                else if (command == "2")
                {
                    while (command != "quit")
                    {
                        Console.WriteLine("Type quit to quit");
                        Console.Write("Enter the name of a degree (ex: Masters): ");
                        command = Console.ReadLine();

                        db.Execute("exec AllData_OnDegree " + "\'" + command + "\'" +  " 'Degree' " );
                    }
                }

                else if (command == "3")
                {

                }


                else
                {
                    Console.Write( command + " is not a valid command.");
                }

            }



        }




    }
}
