using Newtonsoft.Json;

namespace TestMediatR.Domain.Converters
{
    public static class Converter
    {
        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented);
        }
    }
}
