using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Linq;
using System.IO;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {
        public string GetData(string value)
        {
            return string.Format("You entered: {0}", value);
        }
        public class Item
        {
            public string[] web_pages { get; set; }
            public string name { get; set; }
            public string alpha_two_code { get; set; }
            public string state_province { get; set; }
            public string[] domains { get; set; }
            public string country { get; set; }
        }
        public int[] Validate()
        {
            string[] urls = { "https://git.io/vpg9V", "https://git.io/vpg95" };
            string schemaValid = @"{
                              'type' : 'object',
                              'properties' :
                                 {
                                   'web_pages': {
                                               'type': 'array',
                                               'items': {'type':['string' , 'null']} 
                                                },
                                   'name' : {'type':['string', 'null']},
                                   'alpha_two_code' : {'type':['string', 'null']},
                                   'state-province' : {'type':['string', 'null']},
                                   'domains' :  {
                                               'type': 'array',
                                               'items': {'type':['string', 'null']} 
                                                },
                                   'country' : {'type':['string', 'null']}
                                 } 
                              }";

            int k, i, CountObj = 0 , nullocc = 0 , exp = 0, ValidSchema = 0, InValidSchema = 0; ;
            int[] Obj = new int[5];
            for (k = 0; k < 2; k++)
            {
                string json = new System.Net.WebClient().DownloadString(urls[k]);
                JsonSchema schema = JsonSchema.Parse(schemaValid);
                List<Item> items = JsonConvert.DeserializeObject<List<Item>>(json);
                ValidSchema = 0;
                InValidSchema = 0;
                for (i = 0; items.Count > i; i++)
                {
                    Item it = new Item();
                    it = items.ElementAt(i);
                    string s = JsonConvert.SerializeObject(it);
                    
                   if (s.Contains("null") == true )
                   {
                       nullocc += 1;
                   }
                    try
                    {

                        JObject user = JObject.Parse(s);
                        CountObj += 1;
                        bool valid = user.IsValid(schema);
                        if (valid == true)
                        {
                            ValidSchema = ValidSchema + 1;
                        }
                        else
                        {
                            InValidSchema = InValidSchema + 1;
                        }
                    }
                    catch (Exception e)
                    {
                        exp += 1;
                        continue;
                    }
                    
                }
                Obj[k] = CountObj;
                CountObj = 0;

            }
            Obj[k] = nullocc;
            Obj[++k] = exp;
            if (InValidSchema != 0)
            {
                Obj[++k] = 1;
            }
            else
            {
                Obj[++k] = 0;
            }
                
            return Obj;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
