using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace SpecFlowProject.Utils
{
    public class TableExtensions
    {
        public static List<Dictionary<string, string>> ToListOfDictionaries(Table table)
        {
            //Here, an empty list of dictionaries is created to store the transformed rows of the table.
            var listOfDictionaries = new List<Dictionary<string, string>>();

            //This loop goes through each row of the table.Each row contains the data for all columns of that row.
            foreach (var row in table.Rows)
            {
                //This will create new dictionary for each row
                var dictionary = new Dictionary<string, string>();

                //This loop iterates over each column header of the table.The headers are used as keys for the dictionary.
                foreach (var header in table.Header)
                {
                    //For each header, the corresponding cell value in the current row is fetched (row[header]).
                    dictionary[header] = row[header]; //{ "Username": "testuser1", "Password": "pass123" }.
                }

                //Once the dictionary for the current row is fully populated, it is added to the listOfDictionaries.
                listOfDictionaries.Add(dictionary);
            }

            return listOfDictionaries;
        }


        



    }
}
