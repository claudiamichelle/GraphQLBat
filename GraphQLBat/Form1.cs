using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
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

            #region QUERY
            var gql = new UFGraphQLClient.GraphQLClient("https://deliver.urbanfox.asia/api/z/coe_project/2qi8lDa2gUAUIkKNnTznUAXJtkk/gql", this);

            var query =
            /* query for UID */
            //@"{courex_user_profile(uid:" + UID + "){user_uid user_full_name}}";

            /* query for startdate-enddate */
            @"{delivery_list : transaction_info_list (start_date:""" + startdate + "\"" + ",end_date:" + "\"" + enddate + "\"" + "){list {ref_no    bundle_id      driver_id: delivr_driver_id      create_date      pickup_time: pickup_date      pickup_postalcode: src_postcode      Pickup_Latitude: src_lat      Pickup_Longtitude: src_lng      delivery_date: delivr_date      delivery_time: delivr_date      delivery_type      delivery_postalcode: dst_postcode      delivery_latitude: dst_lat      delivery_longitude: dst_lng      service_time: service_type      weight      vol_w      vol_h      vol_l      vol_weight      volume: vol_w    pay      Bonus: pay_bonus}    }}";

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
                    writer.WriteField("Ref No");
                    writer.WriteField("Bundle ID");
                    writer.WriteField("Driver ID");
                    writer.WriteField("Create Date");
                    writer.WriteField("Pickup Time");
                    writer.WriteField("Pickup Postal Code");
                    writer.WriteField("Pickup Latitude");
                    writer.WriteField("Pickup Longtitude");
                    writer.WriteField("Delivery Date");
                    writer.WriteField("Delivery Time");
                    writer.WriteField("Delivery Type");
                    writer.WriteField("Delivery Postal Code");
                    writer.WriteField("Delivery Latitude");
                    writer.WriteField("Delivery Longtitude");
                    writer.WriteField("Service Time");
                    writer.WriteField("Weight");
                    writer.WriteField("vol_w");
                    writer.WriteField("vol_h");
                    writer.WriteField("vol_l");
                    writer.WriteField("vol_weight");
                    writer.WriteField("Volume");
                    writer.WriteField("Pay");
                    writer.WriteField("Bonus");
                    writer.NextRecord();

                    dtp_EndDate.Value = dtp_EndDate.Value.AddDays(1);

                    for (var i = 0; i < countRecord; i++)
                    {
                        dynamic expandoObj = new ExpandoObject();
                        if (dt[i].delivery_date.Value.Date == dtp_EndDate.Value.Date)
                        {
                            expandoObj.ref_no = Convert.ToString(dt[i].ref_no);
                            expandoObj.bundle_id = Convert.ToString(dt[i].bundle_id);
                            expandoObj.driver_id = Convert.ToString(dt[i].driver_id);
                            expandoObj.create_date = dt[i].create_date.Value.ToString("yyyy-MM-dd'T'HH:mm:ss");
                            expandoObj.pickup_time = "8:00:00";
                            expandoObj.pickup_postalcode = Convert.ToString(dt[i].pickup_postalcode);
                            expandoObj.Pickup_Latitude = Convert.ToString(dt[i].Pickup_Latitude);
                            expandoObj.Pickup_Longtitude = Convert.ToString(dt[i].Pickup_Longtitude);
                            expandoObj.delivery_date = dt[i].delivery_date.Value.ToString("yyyy-MM-dd");
                            expandoObj.delivery_time = dt[i].delivery_date.Value.ToString("HH:mm:ss");
                            expandoObj.delivery_type = Convert.ToString(dt[i].delivery_type);
                            expandoObj.delivery_postalcode = Convert.ToString(dt[i].delivery_postalcode);
                            expandoObj.delivery_latitude = Convert.ToString(dt[i].delivery_latitude);
                            expandoObj.delivery_longitude = Convert.ToString(dt[i].delivery_longitude);
                            expandoObj.service_time = 10;
                            expandoObj.weight = Convert.ToString(dt[i].weight);
                            expandoObj.vol_w = Convert.ToString(dt[i].vol_w);
                            expandoObj.vol_h = Convert.ToString(dt[i].vol_h);
                            expandoObj.vol_l = Convert.ToString(dt[i].vol_l);
                            expandoObj.vol_weight = Convert.ToString(dt[i].vol_weight);
                            double countVolume = dt[i].vol_w * dt[i].vol_h * dt[i].vol_l * 0.000001;
                            expandoObj.volume = Convert.ToString(countVolume);

                            double payment, totalvol;
                            totalvol = dt[i].vol_w + dt[i].vol_h + dt[i].vol_l;
                            if (totalvol < 80 || dt[i].vol_w < 5)
                            {
                                payment = 2.8;
                            }
                            else if (totalvol < 120 || dt[i].vol_w < 10)
                            {
                                payment = 5;
                            }
                            else if (totalvol < 160 || dt[i].vol_w < 30)
                            {
                                payment = 8;
                            }
                            else
                            {
                                payment = 12;
                            }
                            expandoObj.pay = Convert.ToString(payment);
                            expandoObj.Bonus = Convert.ToString(dt[i].Bonus);

                            writer.WriteField(expandoObj.ref_no);
                            writer.WriteField(expandoObj.bundle_id);
                            writer.WriteField(expandoObj.driver_id);
                            writer.WriteField(expandoObj.create_date);
                            writer.WriteField(expandoObj.pickup_time);
                            writer.WriteField(expandoObj.pickup_postalcode);
                            writer.WriteField(expandoObj.Pickup_Latitude);
                            writer.WriteField(expandoObj.Pickup_Longtitude);
                            writer.WriteField(expandoObj.delivery_date);
                            writer.WriteField(expandoObj.delivery_time);
                            writer.WriteField(expandoObj.delivery_type);
                            writer.WriteField(expandoObj.delivery_postalcode);
                            writer.WriteField(expandoObj.delivery_latitude);
                            writer.WriteField(expandoObj.delivery_longitude);
                            writer.WriteField(expandoObj.service_time);
                            writer.WriteField(expandoObj.weight);
                            writer.WriteField(expandoObj.vol_w);
                            writer.WriteField(expandoObj.vol_h);
                            writer.WriteField(expandoObj.vol_l);
                            writer.WriteField(expandoObj.vol_weight);
                            writer.WriteField(expandoObj.volume);
                            writer.WriteField(expandoObj.pay);
                            writer.WriteField(expandoObj.Bonus);
                            writer.NextRecord();
                            empObj.Add(expandoObj);
                    }
                        else
                    {
                        continue;
                    }
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

            //Console.WriteLine("...using System.Dynamic and casts");
            //Console.WriteLine();
            //Console.WriteLine(JsonToCsv(jsonData, ","));
            //Console.WriteLine();
            //Console.WriteLine();
            //Console.WriteLine("...using a provided StrongType with System.Reflection.");
            //Console.WriteLine();
            //Console.WriteLine(JsonToCsv<JsonData>(jsonData, ","));
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
            public string bundle_id { get; set; }
            public string driver_id { get; set; }
            public DateTime create_date { get; set; }
            public DateTime pickup_time { get; set; }
            public string pickup_postalcode { get; set; }
            public string Pickup_Latitude { get; set; }
            public string Pickup_Longtitude { get; set; }
            public DateTime delivery_date { get; set; }
            public DateTime delivery_time { get; set; }
            public string delivery_type { get; set; }
            public string delivery_postalcode { get; set; }
            public string delivery_latitude { get; set; }
            public string delivery_longitude { get; set; }
            public string service_time { get; set; }
            public double vol_w { get; set; }
            public double vol_h { get; set; }
            public double vol_l { get; set; }
            public double vol_weight { get; set; }
            public double volume { get; set; }
            public double pay { get; set; }
            public double Bonus { get; set; }
        }
        #endregion

        private void Btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
