using Newtonsoft.Json.Linq;

namespace ATTA.Utils.Models
{
    public class LinkPicker
    {
        public LinkPicker(string json)
        {
            if(!string.IsNullOrEmpty(json))
            {
                JToken jToken = JToken.Parse(json);

                Id = (int)jToken["id"];
                Name = (string)jToken["name"];
                Url = (string)jToken["url"];
                Target = (string)jToken["target"];
            }
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Target { get; set; }
    }
}
