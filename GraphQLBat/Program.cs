using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UFGraphQLClient;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows.Forms;

namespace GraphQLBat
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.Run(new Form1());
        }


    }

    public class JsonResult
    {
        public int testId { get; set; }
        public string testName { get; set; }
        public int minScore { get; set; }
        public int score { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
    }
    public class ClientsList
    {
        public ClientsList(string firstname, string lastname, DateTime dob, string email)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.Dob = dob;
            this.Email = email;
        }

        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public DateTime Dob { set; get; }

    }
}
