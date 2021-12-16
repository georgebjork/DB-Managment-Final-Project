using System;
using System.Data.OleDb;
using System.Collections.Generic;

namespace DB_Managment_Final_Project
{

    public class Database
    {

        //This is the string to connect to our DB
        public String connectionString = "Provider=sqloledb;Data Source=cs1;Initial Catalog=CollegeFinder;User Id=gbjork23x;Password=2255110;";

        public OleDbCommand cmd = new OleDbCommand();

         //Hold all of the queries
        List<String> queries = new List<String>();
        
        public Database(){}

       
        //Class functions

        //This will connect to the database using a pre written connection string
        //LOCAL DB: Provider=sqloledb;Data Source=DESKTOP-3RTEE05\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=SSPI;
        public bool connect()
        {
            try
            {
                //This will connect to the database
                this.cmd.Connection = new OleDbConnection(this.connectionString);
                this.cmd.Connection.Open();
                Console.WriteLine("Huzzah! Connection has been established!");
                //Once connection has been made, lets add all the queries to the queries list
                addQueries();
            }
            //Catch if it cannot connect
            catch(Exception ex)
            {
                Console.WriteLine("Oops, cannot connect to the database, check your connection string. Error: " + ex.Message /*+ ex.StackTrace*/);
                return false;
            }
            
            return true;
        }

        public void addQueries(){
            //Add all queries
            queries.Add("This is a query");
        }

        //This will take in a command via a string and execute it
        public void Execute(String command)
        {
            cmd.CommandText = command;
            //Execute 
            OleDbDataReader rdr = cmd.ExecuteReader();
            Console.WriteLine("Q: " + command);
            Console.WriteLine();
            //print, we give it 5 for 5 rows 
            print(rdr, 5);
        }

        /*
            This function will take in a reader, an index and a string.
            The purpose of this function is to do datatype conversion since we dont know 
            which datasets will be which datatypes. It will convert datatypes by using the string 
            to recognize if it is a short, int, string, datatime etc. Once converted it, it will be 
            ouputted to the terminal
        */

        //Datatype is the string name of the type, the i is used for grapping the piece of data at the right column, and rdr reads it 
        public void outPut(string dataType, int i, OleDbDataReader rdr)
        {
            //This will convert to datetime
            if(dataType == "DBTYPE_DBTIMESTAMP"){
                DateTime str = rdr.GetDateTime(i);
                Console.Write(str + " | ");
            } 

            //This will convert to an int 
            else if(dataType == "DBTYPE_I4" ){
                int str = rdr.GetInt32(i);
                Console.Write(str + " | ");
            }


            //This will do a short
            else if(dataType == "DBTYPE_I2"){
                short str = rdr.GetInt16(i);
                Console.Write(str + " | ");
            }

            //This will do a float
            else if(dataType == "DBTYPE_NUMERIC" || dataType == "DBTYPE_CY"){
                decimal str = rdr.GetDecimal(i);
                Console.Write(str + " | ");
            }

            //Anything else can just be a string
            else{
                string str = rdr.GetString(i);
                str = truncate(str);
                Console.Write(str + " | ");
            }
        }

        /*
        This function will take in the reader and the amount of rows we want to print off
        It will then first go through and print off the column names
        Then it will go through each tuple and print them off and do some basic formatting
        */
        public void print(OleDbDataReader rdr, int amount)
        {
            try
            {   

                //First print of the column names 
                for(int j = 0; j < rdr.FieldCount; j++)
                {
                    Console.Write(rdr.GetName(j) + " | ");
                }
                Console.WriteLine();
                Console.WriteLine();


                //this will output data rows and how many rows will get outputted using an inline if statment
                for (int cOrders = 0; (rdr.Read() == true && (amount == -1 || cOrders < 5)) ? true : false ; cOrders++)
                {
                    Console.Write(cOrders.ToString() + ". | ");

                    for(int i = 0; i < rdr.FieldCount; i++)
                    {   
                        //if not a null, then we want to output the funciton
                        string dataType = (rdr.IsDBNull(i) == false) ? rdr.GetDataTypeName(i) : null;
                        //This is a helper function since differnt datatypes need to be set to C# types 
                        outPut(dataType, i, rdr);
                    }

                    Console.WriteLine();
                } 
            } 
            //Catch if it cannot output
            catch(Exception ex)
            {
                Console.WriteLine("Oops, error: " + ex.Message + ex.StackTrace);
            }

            //Close the reader now that we are done with it
            rdr.Close();
            Console.WriteLine();
        }

        //This will truncate a string to be a max of 26 charecters 
        public String truncate(String str)
        {
            int max = 20;
            if(str.Length >= max)
            {
                str = str.Substring(0, max);
            }
            return str;
        }
    }
    
}