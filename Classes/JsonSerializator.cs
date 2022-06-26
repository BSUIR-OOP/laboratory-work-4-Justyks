using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Lab3.Interfaces;

namespace Lab3.Classes
{
    public class JsonSerializator : IJsonSerializator
    {
        public BrandsList Deserialize(string json)
        {
            BrandsList res = new BrandsList();
            json = Regex.Replace(json, "[]['\n\t,\":]", string.Empty);
            string[] stream = json.Split('{', '}');
            foreach (string s in stream)
            {
                if (!s.Equals(""))
                {
                    Dictionary<string, string> tokens = new Dictionary<string, string>();
                    string[] token = s.Split(' ');
                    for (int i = 0; i < token.Length; i += 2)
                    {
                        tokens.Add(token[i], token[i + 1]);
                    }
                    Type type = Type.GetType(tokens["type"]);
                    AutoBrands c = (AutoBrands)Activator.CreateInstance(type);
                    foreach (var f in type.GetProperties())
                    {
                        if (f.PropertyType.Equals(typeof(string)))
                        {
                            f.SetValue(c, tokens[f.Name]);
                        }
                        else
                        {
                            f.SetValue(c, int.Parse(tokens[f.Name]));
                        }
                    }
                    foreach (var f in type.GetFields())
                    {
                        if (f.FieldType.Equals(typeof(string)))
                        {
                            f.SetValue(c, tokens[f.Name]);
                        }
                        else
                        {
                            f.SetValue(c, int.Parse(tokens[f.Name]));
                        }
                    }
                    res.Add(c);
                }
            }
            return res;
        }

        public string Serialize(AutoBrands brands)
        {
            int cnt = 0;
            string res = "[";
            foreach (AutoBrands brand in brands)
            {
                cnt++;
                res += "\n\t{\n";
                Type type = brands.GetType();
                res += $"\t\t\"type\": \"{type.FullName}\",\n ";
                foreach (var f in type.GetFields())
                {
                    if (f.FieldType.Equals(typeof(string)))
                        res += $"\t\t\"{f.BrandName}\": \"{f.GetValue(brand)}\", \n";
                    else
                        res += $"\t\t\"{f.BrandName}\": {f.GetValue(brand)}, \n";
                }
                foreach (var f in type.GetProperties())
                {
                    if (f.PropertyType.Equals(typeof(string)))
                        res += $"\t\t\"{f.BrandName}\": \"{f.GetValue(brand)}\", \n";
                    else
                        res += $"\t\t\"{f.BrandName}\": {f.GetValue(brand)}, \n";
                }
                res = res.Remove(res.LastIndexOf(',')) + "\n";
                res += "\t},";
            }
            res = res.Remove(res.LastIndexOf(',')) + "\n";
            res += "]";
            return res;
        }

    }
}
