using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        public class Address
        {
            public Address() { }
            public string street { get; set; }
            public string suite { get; set; }
        }

        public class User
        {
            public User()
            {

            }
            public string id { get; set; }
            public string name { get; set; }
            public string username { get; set; }
            public Address address { get; set; }

        }



        static void Main(string[] args)
        {

            var hoje = DateTime.Now.AddHours(6);
            var formatada = hoje.ToString("yyyy-MM-dd");
            var formatada2 = hoje.ToString("s");
            int teste = 1;

            // POC 1: serialize deserialize
            //var userMary = new User() { id = "12", name = "Mary", username = "mary123" };
            //string userMaryToJson = JsonConvert.SerializeObject(userMary, Formatting.Indented);


            //string johnJson = @"{
            //    'id': '3',
            //    'name': 'John',
            //    'username': 'jdoe',
            //    'address': {
            //                'street':'Kulas Light'
            //                }
            //    }";
            //var userJohn = JsonConvert.DeserializeObject<User>(johnJson);


            //Console.WriteLine("END...");
            //var input = Console.ReadKey();



            //////////////////////////////////////////////////////////
            //// SUCCESS
            //WebRequest request = WebRequest.Create(@"https://jsonplaceholder.typicode.com/users");
            //request.Method = "GET";

            //// Get the response.  
            //WebResponse response = request.GetResponse();
            //// Display the status.  
            //Console.WriteLine(((HttpWebResponse)response).StatusCode);
            //// Get the stream containing content returned by the server.  
            //var dataStream = response.GetResponseStream();
            //// Open the stream using a StreamReader for easy access.  
            //StreamReader reader = new StreamReader(dataStream);
            //// Read the content.  
            //string responseFromServer = reader.ReadToEnd();
            //// Display the content.  
            //Console.WriteLine(responseFromServer);
            //// Clean up the streams.  
            //reader.Close();
            //dataStream.Close();
            //response.Close();

            //var userResponse = JsonConvert.DeserializeObject<List<User>>(responseFromServer);


            //Console.WriteLine("END...");
            //var input = Console.ReadKey();

            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////
            // ERROR
            //WebRequest request = WebRequest.Create(@"https://jsonplaceholder.typicode.com/usersERROR");
            WebRequest request = WebRequest.Create(@"https://jsonplaceholder.typicode.com/users");
            request.Method = "GET";

            // Get the response.  
            WebResponse response = null;
            StreamReader reader = null;
            Stream dataStream = null;

            try
            {
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                //Log error
                var message = ex.Message;
            }
            finally
            {
             
            }

            if (((HttpWebResponse)response).StatusCode != HttpStatusCode.OK)
            {
                //ERROR happened.
            }
            // Display the status.  
            Console.WriteLine(((HttpWebResponse)response).StatusCode);

            // Get the stream containing content returned by the server.  
            dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.  
            reader = new StreamReader(dataStream);
            // Read the content.  
            string responseFromServer = reader.ReadToEnd();
            // Display the content.  
            Console.WriteLine(responseFromServer);
            // Clean up the streams.  
            reader.Close();
            dataStream.Close();
            response.Close();

            var userResponse = JsonConvert.DeserializeObject<List<User>>(responseFromServer);


            Console.WriteLine("END...");
            var input = Console.ReadKey();


        }
    }
}
