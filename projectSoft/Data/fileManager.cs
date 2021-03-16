using System.Collections.Generic;
using System.IO;

/*
https://www.newtonsoft.com/json/help/html/SerializingJSON.htm
dotnet add projectSoft.csproj package Newtonsoft.Json
*/
using Newtonsoft.Json;

namespace projectSoft.Data
{
    public class FilesManager<T>
    {
        public static IEnumerable<T> LoadJson(string file)
        {
            List<T> items = new List<T>();
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                items = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return items;
        }

		public static void SaveJson(List<T> _data,string file)
		{
			string json = JsonConvert.SerializeObject(_data.ToArray());
			File.WriteAllText(file,json);
		}
	}
}