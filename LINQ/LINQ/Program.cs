using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static LINQ.MyModel;

namespace LINQ
{
   

    class Program
    {

        static void Main(string[] args)
        {


            string fileName = "data.json";
            string jsonString = File.ReadAllText(fileName);

            var data = Newtonsoft.Json.JsonConvert.DeserializeObject<MyModel>(jsonString);

            var features = from allFeatures in data.features select allFeatures;

            
            var allneighborhoods = from neighborhood in features select neighborhood.properties.neighborhood; //LINQ query

            var neighborsWithNames = allneighborhoods.Where(neighbors => neighbors != ""); //LINQ method

            var properties = from property in features select property.properties;

            var notDuplicated = properties.GroupBy(x => x.neighborhood).Select(y => y.First());

            var notDuplicatedAndNotEmpty = properties.Where(property => property.neighborhood != "").GroupBy(x => x.neighborhood).Select(y => y.First());


           
            var rewiteNeighborsWithNames = from property in properties where property.neighborhood != "" select property.neighborhood;





            Console.WriteLine("Output all of the neighborhoods in this data list");
            foreach (var item in allneighborhoods)
            {
                Console.WriteLine(item);
            }



            //Console.WriteLine("Filter out all the neighborhoods that do not have any names ");

            //foreach (var item in neighborsWithNames)
            //{
            //    Console.WriteLine(item);
            //}




            //Console.WriteLine("Remove the duplicates ");

            //foreach (var item in notDuplicated)
            //{
            //    Console.WriteLine(item.neighborhood);
            //}



            //Console.WriteLine("Rewrite the queries from above and consolidate all into one single query ");

            //foreach (var item in notDuplicatedAndNotEmpty)
            //{
            //    Console.WriteLine(item.neighborhood);
            //}



            //Console.WriteLine("Rewrite at least one of these questions only using the opposing method ");

            //foreach (var item in rewiteNeighborsWithNames)
            //{
            //    Console.WriteLine(item);
            //}













        }
    }
}
