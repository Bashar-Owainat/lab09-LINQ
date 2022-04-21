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


         
            foreach (var item in data)
            {
               Console.WriteLine(item);
            }













        }
    }
}
