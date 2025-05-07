using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using ExcelDataReader;

public class ExcelReaderHelper
{
    public static List<Dictionary<string, string>> ReadExcelData1(string filePath, string sheetName)
    {
        //Ensures that the application can read different character encodings, especially for older Excel formats (.xls).
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        // dataList is the varibale to stored list of dictionaries
        var dataList = new List<Dictionary<string, string>>();

        //Opens the Excel file in read - only mode to prevent accidental modification
        //Using the 'using' statement ensures that the Dispose() method is automatically called when the code block exits for each session.
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            //Reading streamed content
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                //Loading data into DataTable and Converts Excel content into a dataset.
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    //ExcelDataTableConfiguration this class will trying to return data set that returns first row as column header
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true // Ensure the first row is used as column headers
                    }
                });

                //Extracts data from the required Excel sheet.
                DataTable table = result.Tables[sheetName];

                //Loops through all rows and columns, storing data in a Dictionary<string, string>.
                //Trims unnecessary spaces from keys and values.
                foreach (DataRow row in table.Rows)
                {
                    var dataRow = new Dictionary<string, string>();
                    foreach (DataColumn col in table.Columns)
                    {
                        dataRow[col.ColumnName.Trim()] = row[col].ToString().Trim(); // Trim spaces
                    }
                    dataList.Add(dataRow);
                }
            }
        }
        // Returns the list of dictionaries, where each dictionary represents a row from Excel.
        return dataList;
    }


    public static List<Dictionary<string, string>> ReadExcelData(string filePath, string sheetName, int headerRowIndex, int dataStartRowIndex)
    {
        //Ensures that the application can read different character encodings, especially for older Excel formats (.xls).
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

        // dataList is the varibale to stored list of dictionaries where Keys are column header and Values are corresponding cell value
        var dataList = new List<Dictionary<string, string>>();

        //Opens the Excel file in read - only mode to prevent accidental modification
        //Using the 'using' statement ensures that the Dispose() method is automatically called when the code block exits for each session.
        using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
        {
            //Reading streamed content
            using (var reader = ExcelReaderFactory.CreateReader(stream))
            {
                //Loading data into DataTable and Converts Excel content into a dataset.
                var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    //ExcelDataSetConfiguration allows us to customize the conversion process.
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = false //ensures that the first row is not automatically treated as a header.
                        //This is important because the header row might not always be the first row, and we want to dynamically select it.

                    }
                });
                //Extracts data from the required Excel sheet.
                DataTable table = result.Tables[sheetName];

                // **Extract headers dynamically from the specified header row**
                var headers = new List<string>();
                foreach (DataColumn col in table.Columns)
                {
                    headers.Add(table.Rows[headerRowIndex][col].ToString().Trim());
                }

                // **Iterate through data starting from the specified row**
                for (int i = dataStartRowIndex; i < table.Rows.Count; i++)
                {
                    var dataRow = new Dictionary<string, string>();
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        dataRow[headers[j]] = table.Rows[i][j].ToString().Trim();
                    }
                    dataList.Add(dataRow);
                }
            }
        }
        // Returns the list of dictionaries, where each dictionary represents a row from Excel
        return dataList;
    }

    //dataList

    //[

    //  { "Username": "sa", "Password": "Symtr4x!" },
    //  { "Username": "Kshete", "Password": "kshete@symtrax.in" },

    //]


}
