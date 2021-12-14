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
                Console.WriteLine("[4] Sort by Student Population");
                Console.WriteLine("[5] Sort by Tutition");
                Console.WriteLine("[6] Search by School Name");
                Console.WriteLine("[7] Get all data");


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

                        if(command != "quit"){
                            db.Execute("exec sortState " + "\'" + command + "\'");
                        }
                    }

                }
                else if (command == "1")
                {
                    while (command != "quit")
                    {
                        Console.WriteLine("Type quit to quit");
                        Console.Write("Enter the name of a major (ex: Computer Science): ");
                        command = Console.ReadLine();
                        
                        if(command != "quit"){
                            db.Execute("exec schoolWithMajor " + "\'" + command + "\'");
                        }
                    }

                }
                else if (command == "2")
                {
                    while (command != "quit")
                    {
                        Console.WriteLine("Type quit to quit");
                        Console.Write("Enter the name of a degree (ex: Masters): ");
                        command = Console.ReadLine();

                        if(command != "quit"){
                            db.Execute("exec AllData_OnDegree " + "\'" + command + "\'" );
                        }
                    }
                }

                else if (command == "3")
                {
                        //schoolWithExtracurricular
                    while (command != "quit")
                    {
                        Console.WriteLine("Type quit to quit");
                        Console.Write("Enter the name of an Extracurricular (ex: Football): ");
                        command = Console.ReadLine();
                        
                        if(command != "quit"){
                            db.Execute("exec schoolWithExtracurricular " + "\'" + command + "\'");
                        }
                    }
                }
                else if (command == "4")
                {
                   db.Execute("exec Tuition_ascOrder");
                }
                else if (command == "5")
                {
                    db.Execute("exec StudentPopulation_ascOrder");
                }
                else if (command == "6")
                {
                        //schoolWithExtracurricular
                    while (command != "quit")
                    {
                        Console.WriteLine("Type quit to quit");
                        Console.Write("Enter the name of a School (ex: Whitworth University): ");
                        command = Console.ReadLine();

                        if(command != "quit"){
                            db.Execute("exec schoolName " + "\'" + command + "\'");
                        }
                    }
                }
                else if (command == "7")
                {
                    db.Execute("exec allData");
                }


                else
                {
                    Console.WriteLine( command + " is not a valid command.");
                    Console.WriteLine();
                    command = "";
                }

            }



        }




    }
}
