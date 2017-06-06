using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitySearch;
using System.IO;

namespace AXACodingEx
{
    public class CityResultImplementation : ICityResult
    {
        public ICollection<string> NextLetters { get; set; }

        public ICollection<string> NextCities { get; set; }

        public CityResultImplementation()
        {
            NextLetters = new List<string>();
            NextCities = new List<string>();
        }
    }

    public class CityFinderImplementation : ICityFinder
    {
        public CityTree Cities { get; set; }

        public CityFinderImplementation()
        {
            Cities = LoadCitiesList();
        }

        public ICityResult Search(string searchString)
        {
            CityResultImplementation searchResult = new CityResultImplementation();

            searchResult.NextCities = (Cities.FindWordList(searchString));
            searchResult.NextLetters = Cities.FindAllPossibleNextChars(searchString);

            return searchResult;
        }

        public static CityTree LoadCitiesList()
        {
            CityTree cities = new CityTree();
            string filename = @"C:\Users\Blue\Documents\Visual Studio 2015\Projects\AXACodingEx\world-cities.csv";

            string[] linesInFile = File.ReadAllLines(filename);
            string[] CityNames = new string[0];

            for (int i = 0; i < linesInFile.Length; i++)
            {
                string currentLine1 = linesInFile[i];
                CityNames = currentLine1.Split(',');

                cities.Insert(CityNames[0]);
            }
            return cities;
        }
    }

}
