using System.Reflection.Metadata;

namespace CSVImporter
{
    public class Importer
    {
        /// <summary>
        /// Import CSV data to 2D List pole
        /// </summary>
        /// <param name="path">Path of CSV File</param>
        /// <param name="separator">Separator between values</param>
        /// <param name="skip">Skip first x rows (do not load)</param>
        /// <returns></returns>
        public static List<List<string>> ImportCSV(string path, string separator, int skip = 0)
        {
            List<List<string>> Collumns = new List<List<string>>(); //Initialize Lists Object
            int RowsCount = 0; //Counting number of Rows

            foreach (string row in File.ReadAllLines(path)) //Read Lines of CSV file
            {
                RowsCount++;    //Count Row

                if (skip < RowsCount && row.Contains(separator) && row != "")   //test for skipping specified rows for skip or skip empty rows and if missing separator in row
                {
                    List<string> Collumn = row.Split(separator).ToList();    //Splitting CSV Line

                    if (Collumns.Count < Collumn.Count)    //Test if sufficient number of collumns 
                    {
                        int collumnsRequest = Collumn.Count - Collumns.Count;  //Count missing collumns

                        while (collumnsRequest > 0) //loop for add missing collumns
                        {
                            Collumns.Add(new List<string>(RowsCount - skip));   //Add collumn to collumns with specified number of elements
                            collumnsRequest--;  //subtraction added collumn
                        }
                    }

                    foreach (string data in Collumn)    //loop for moving data to position
                    {
                        Collumns[Collumn.IndexOf(data)].Add(data);  //Adding data to position
                    }

                    if (Collumns.Count > Collumn.Count) //test if new Row is not shorter when previous
                    {
                        int missingnumber = Collumns.Count - Collumn.Count; //count missing collumns

                        while(missingnumber > 0)    //loop for adding empty strings to collumns in shorter row
                        {
                            Collumns[Collumn.Count + missingnumber].Add("");    //adding empty strings to collumns in shorter row
                            missingnumber--;    //subtraction number of missing collumns data
                        }
                    }
                }
            }

            return Collumns;    //return Imported Data
        }






























    }
}