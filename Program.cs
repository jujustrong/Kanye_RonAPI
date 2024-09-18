using System;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;

//Create an instance of a class called HttpClient, this is what actually makes the api call
var client = new HttpClient();  //makes a request to the internet

//Build an api url from where the api call comes from
// var kanyeURL = "https://api.kanye.rest";

//using the HttpClient instance
//Send a GET request to the url created above, this is going to us back a string of JSON
// var kayneResponseJson = client.GetStringAsync(kanyeURL).Result;

//Parse the json response we just got back into a JObject, we do this, so we can access certain parts of the json
//In this case we will be getting the value of "quote" which will give me the actual quote itself and not the whole body of json
// var kanyeQuote = JObject.Parse(kayneResponseJson).GetValue("quote").ToString();
// var kanyeQuote = JObject.Parse(kayneResponseJson)["quote"].ToString();

for (var i = 0; i < 6; i++)
{
    var kanyeURL = "https://api.kanye.rest";
    var kayneResponseJson = client.GetStringAsync(kanyeURL).Result;
    var kanyeQuote = JObject.Parse(kayneResponseJson)["quote"].ToString();
    Console.WriteLine($"Kanye: {kanyeQuote}...");
    Thread.Sleep(2000);

    var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";
    var ronResponseJson = client.GetStringAsync(ronURL).Result;
    var ronQuote = JArray.Parse(ronResponseJson);
    Console.WriteLine($"Ron: {ronQuote[0]}...");
    Console.WriteLine();
}