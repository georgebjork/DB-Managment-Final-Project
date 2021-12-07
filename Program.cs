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
            if(command == "y"){
                db.connect();
            }
            
            Console.WriteLine("Welcome to the college finder! This application will help you find a college that is right for you!");
            Console.WriteLine();

            //display a list of filter 
                //state
                //tuitition 
                //etc

            Console.WriteLine("[0] Filter by State");
            Console.WriteLine("[1] Filter by major name");
            Console.WriteLine("[2] Filter by Degree name");
            Console.WriteLine("[3] Filter by EC");
            Console.WriteLine();

            Console.Write("Select an option: ");
            command = Console.ReadLine();

            if(command == "0"){
                Console.Write("Enter a state abbeviation: ");
                command = Console.ReadLine();

                from = from + ", Address a ";
                where = where + "a.state = \'" + command + "\'" + " AND s.id = a.school_id ";
            }

            String q = select + from + where;

            db.Execute(q);

        } 


            
            
    }
}
