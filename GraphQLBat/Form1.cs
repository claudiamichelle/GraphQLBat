using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UFGraphQLClient;

namespace GraphQLBat
{
    public partial class Form1 : Form
    {
        private DataGridView dataGridView1 = new DataGridView();
        private BindingSource bindingSource1 = new BindingSource();

        public static string UID;
        public static string startdate;
        public static string enddate;


        public Form1()
        {
            InitializeComponent();
        }

        public string GetJSONData() //return dictFrontEndTrimmed
        {
            #region FORMAT INPUT 
            // Display the date as "2019-04-20T23:50:48+08".  
            //Convert.ToDateTime("yyyy-MM-dd'T'HH:mm:ssZzz");
            dtp_StartDate.Format = DateTimePickerFormat.Custom;
            dtp_EndDate.Format = DateTimePickerFormat.Custom;
            dtp_StartDate.CustomFormat = "yyyy-MM-dd'T'08:00:00'+08'";
            dtp_EndDate.CustomFormat = "yyyy-MM-dd'T'23:59:59'+08'";
            startdate = dtp_StartDate.Text.ToString();
            enddate = dtp_EndDate.Text.ToString();
            #endregion

            #region TEST PRINT
            //Console.WriteLine("UID : " + UID);
            //Console.WriteLine("Start Date : " + startdate);
            //Console.WriteLine("End Date : " + enddate);
            #endregion

            #region QUERY
            var gql = new UFGraphQLClient.GraphQLClient("https://deliver.urbanfox.asia/api/z/coe_project/2qi8lDa2gUAUIkKNnTznUAXJtkk/gql", this);

            var query =
            /* query for UID */
            //@"{courex_user_profile(uid:" + UID + "){user_uid user_full_name}}";

            /* query for startdate-enddate */
            @"{delivery_list : transaction_info_list (start_date:""" + startdate + "\"" + ",end_date:" + "\"" + enddate + "\"" + "){list {ref_no create_date  delivr_date pickup_date delivr_driver_id pickup_driver_id pickup_id dst_postcode dst_bundle_name dst_lat dst_lng src_postcode src_bundle_name src_lat src_lng dst_addr vol_w vol_h vol_l vol_weight weight pay_category pay_bonus pay}}}";
            //@"{delivery_list : transaction_info_list (start_date:""" + startdate + "\"" + ",end_date:" + "\"" + enddate + "\"" + "){list {ref_no create_date}}}";

            Console.WriteLine(query);

            #endregion

            #region EXECUTE QUERY
            var dict = gql.Execute(query);
            #endregion

            #region TEST PRINT JSON

            //Console.WriteLine(JSONformatted);
            string dictFrontTrimmed = dict.Replace("{\"data\":{\"delivery_list\":{\"list\":", "");
            string dictFrontEndTrimmed = dictFrontTrimmed.Remove(dictFrontTrimmed.Length - 3);
            Console.WriteLine(dictFrontEndTrimmed);
            #endregion

            var dt = jsonStringToTable(dictFrontEndTrimmed);
            gridViewTest.DataSource = dt;
            return dictFrontEndTrimmed;
        }

        private void Btn_JSONtoCSV_Click(object sender, EventArgs e)
        {
            // Populate the data source
            bindingSource1.DataSource = GetJSONData();

            #region BIND DATATABLE to GRIDVIEW
            // Initialize the DataGridView.
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.AutoSize = true;
            dataGridView1.DataSource = bindingSource1;
            #endregion

            //TestJsonToCsv(); //TO PRINT THE RESULT ON CONSOLE

            var empObj = new List<ExpandoObject>();
            var dt = jsonStringToTable(GetJSONData());
            var countRecord = dt.Count;

            //Create new SafeFileDialog instance
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "csv";

            //Display dialog and see if OK button was pressed
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //To save to defined path in config file
                /* StreamWriter CsvfileWriter = new StreamWriter(@"C:\test CSV result\testfile.csv");  */

                //Save file to file name specified to SafeFileDialog
                StreamWriter CsvfileWriter = new StreamWriter(sfd.FileName);
                using (var writer = new CsvHelper.CsvWriter(CsvfileWriter))
                {
                    writer.WriteField("ref_no");
                    writer.WriteField("create_date");
                    writer.WriteField("delivr_date");
                    writer.WriteField("pickup_date");
                    writer.WriteField("delivr_driver_id");
                    writer.WriteField("pickup_driver_id");
                    writer.WriteField("pickup_id");
                    writer.WriteField("dst_postcode");
                    writer.WriteField("dst_bundle_name");
                    writer.WriteField("dst_lat");
                    writer.WriteField("dst_lng");
                    writer.WriteField("src_postcode");
                    writer.WriteField("src_bundle_name");
                    writer.WriteField("src_lat");
                    writer.WriteField("src_lng");
                    writer.WriteField("dst_addr");
                    writer.WriteField("vol_w");
                    writer.WriteField("vol_h");
                    writer.WriteField("vol_l");
                    writer.WriteField("vol_weight");
                    writer.WriteField("weight");
                    writer.WriteField("pay_category");
                    writer.WriteField("pay_bonus");
                    writer.WriteField("pay");
                    writer.NextRecord();

                    for (var i = 0; i < countRecord; i++)
                    {
                        dynamic expandoObj = new ExpandoObject();
                        expandoObj.ref_no = Convert.ToString(dt[i].ref_no);
                        expandoObj.create_date = Convert.ToString(dt[i].create_date);
                        expandoObj.delivr_date = Convert.ToString(dt[i].delivr_date);
                        expandoObj.pickup_date = Convert.ToString(dt[i].pickup_date);
                        expandoObj.delivr_driver_id = Convert.ToString(dt[i].delivr_driver_id);
                        expandoObj.pickup_driver_id = Convert.ToString(dt[i].pickup_driver_id);
                        expandoObj.pickup_id = Convert.ToString(dt[i].pickup_id);
                        expandoObj.dst_postcode = Convert.ToString(dt[i].dst_postcode);
                        expandoObj.dst_bundle_name = Convert.ToString(dt[i].dst_bundle_name);
                        expandoObj.dst_lat = Convert.ToString(dt[i].dst_lat);
                        expandoObj.dst_lng = Convert.ToString(dt[i].dst_lng);
                        expandoObj.src_postcode = Convert.ToString(dt[i].src_postcode);
                        expandoObj.src_bundle_name = Convert.ToString(dt[i].src_bundle_name);
                        expandoObj.src_lat = Convert.ToString(dt[i].src_lat);
                        expandoObj.src_lng = Convert.ToString(dt[i].src_lng);
                        expandoObj.dst_addr = Convert.ToString(dt[i].dst_addr);
                        expandoObj.vol_w = Convert.ToString(dt[i].vol_w);
                        expandoObj.vol_h = Convert.ToString(dt[i].vol_h);
                        expandoObj.vol_l = Convert.ToString(dt[i].vol_l);
                        expandoObj.vol_weight = Convert.ToString(dt[i].vol_weight);
                        expandoObj.weight = Convert.ToString(dt[i].weight);
                        expandoObj.pay_category = Convert.ToString(dt[i].pay_category);
                        expandoObj.pay_bonus = Convert.ToString(dt[i].pay_bonus);
                        expandoObj.pay = Convert.ToString(dt[i].pay);

                        writer.WriteField(expandoObj.ref_no);
                        writer.WriteField(expandoObj.create_date);
                        writer.WriteField(expandoObj.delivr_date);
                        writer.WriteField(expandoObj.pickup_date);
                        writer.WriteField(expandoObj.delivr_driver_id);
                        writer.WriteField(expandoObj.pickup_driver_id);
                        writer.WriteField(expandoObj.pickup_id);
                        writer.WriteField(expandoObj.dst_postcode);
                        writer.WriteField(expandoObj.dst_bundle_name);
                        writer.WriteField(expandoObj.dst_lat);
                        writer.WriteField(expandoObj.dst_lng);
                        writer.WriteField(expandoObj.src_bundle_name);
                        writer.WriteField(expandoObj.src_lat);
                        writer.WriteField(expandoObj.src_lng);
                        writer.WriteField(expandoObj.dst_addr);
                        writer.WriteField(expandoObj.vol_w);
                        writer.WriteField(expandoObj.vol_h);
                        writer.WriteField(expandoObj.vol_l);
                        writer.WriteField(expandoObj.vol_weight);
                        writer.WriteField(expandoObj.weight);
                        writer.WriteField(expandoObj.pay_category);
                        writer.WriteField(expandoObj.pay_bonus);
                        writer.WriteField(expandoObj.pay);
                        writer.NextRecord();
                        empObj.Add(expandoObj);
                    }
                }
                Console.WriteLine("Total Records: " + countRecord);
                lbl_totalrec.Text = "Total Records: " + countRecord;
            }
            #region MESSAGE BOX - NOTIFIED CSV SAVED
            string message = Path.GetDirectoryName(sfd.FileName);

            string title = "JSON to CSV";
            MessageBox.Show(message, title);
            #endregion
        }

        #region JSON STRING to TABLE
        public void TestJsonToCsv()
        {
            string jsonData = GetJSONData();

            Console.WriteLine("...using System.Dynamic and casts");
            Console.WriteLine();
            Console.WriteLine(JsonToCsv(jsonData, ","));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("...using a provided StrongType with System.Reflection.");
            Console.WriteLine();
            Console.WriteLine(JsonToCsv<JsonData>(jsonData, ","));
        }
        static private string JsonToCsv(string jsonContent, string delimiter)
        {
            var data = jsonStringToTable(jsonContent);
            var headers = ((IEnumerable<dynamic>)((IEnumerable<dynamic>)data).First()).Select((prop) => prop.Name).ToArray();
            var csvList = new List<string>
            {
                string.Join(delimiter, headers.Select((prop) => string.Format(@"""{0}""", prop)).ToArray())
            };

            var lines = ((IEnumerable<dynamic>)data)
                .Select(row => row)
                .Cast<IEnumerable<dynamic>>()
                .Select((instance) => string.Join(delimiter, instance.Select((v) => string.Format(@"""{0}""", v.Value))))
                .ToArray();

            csvList.AddRange(lines);
            return string.Join(Environment.NewLine, csvList);
        }
        static private string JsonToCsv<T>(string jsonContent, string delimiter) where T : class
        {
            var data = jsonStringToTable<T>(jsonContent);

            var properties = data.First().GetType().GetProperties();

            var lines = string.Join(Environment.NewLine,
                string.Join(delimiter, properties.Select((propInfo) => string.Format(@"""{0}""", propInfo.Name))),
                string.Join(Environment.NewLine, data.Select((row) => string.Join(delimiter, properties.Select((propInfo) => string.Format(@"""{0}""", propInfo.GetValue(row)))))));

            return lines;
        }

        static private dynamic jsonStringToTable(string jsonContent)
        {
            var json = jsonContent.Split(new[] { '!' }).Last();
            return JsonConvert.DeserializeObject<dynamic>(json);
        }

        static private IEnumerable<T> jsonStringToTable<T>(string jsonContent) where T : class
        {
            var json = jsonContent.Split(new[] { '!' }).Last();
            return JsonConvert.DeserializeObject<IEnumerable<T>>(json);
        }

        public class JsonData
        {
            public string ref_no { get; set; }
            public DateTime create_date { get; set; }
            public DateTime delivr_date { get; set; }
            public DateTime pickup_date { get; set; }
            public string delivr_driver_id { get; set; }
            public string pickup_driver_id { get; set; }
            public string pickup_id { get; set; }
            public string dst_postcode { get; set; }
            public string dst_bundle_name { get; set; }
            public string dst_lat { get; set; }
            public string dst_lng { get; set; }
            public string src_postcode { get; set; }
            public string src_bundle_name { get; set; }
            public string src_lat { get; set; }
            public string src_lng { get; set; }
            public string dst_addr { get; set; }
            public double vol_w { get; set; }
            public double vol_h { get; set; }
            public double vol_l { get; set; }
            public double vol_weight { get; set; }
            public double weight { get; set; }
            public string pay_category { get; set; }
            public double pay_bonus { get; set; }
            public double pay { get; set; }
        }
        #endregion

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
