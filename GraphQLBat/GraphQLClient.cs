using System;
using RestSharp;
using System.Net;
using System.Dynamic;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using GraphQLBat;

namespace UFGraphQLClient
{
    public class GraphQLClient
    {
        private RestClient _client;
        public GraphQLClient(string GraphQLApiUrl, Form1 f1)
        {
            _client = new RestClient(GraphQLApiUrl);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }

        public dynamic Execute(string query, object variables = null)
        {
            int timeout = 0;
            var request = new RestRequest("/", Method.POST);
            request.Timeout = timeout;

            request.AddJsonBody(new
            {
                query = query,
                RequestFormat = DataFormat.Json,
                variables = variables
            });

            IRestResponse response = _client.Execute(request);
            var content = response.Content; // raw content as string

            //Console.WriteLine(response.Content);
            //Console.ReadKey();
            return content;

            // return JObject.Parse(_client.Execute(request).Content);

        }

    }


}