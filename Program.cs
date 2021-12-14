using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace jsontest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AutoMapaRootResponse<List<List<RevGeoCodeResponse>>> response = JsonConvert.DeserializeObject<AutoMapaRootResponse<List<List<RevGeoCodeResponse>>>>(jsonstring,new RevGeoCodeResponseListConverter());
                Console.WriteLine("OK");
                Console.WriteLine(JsonConvert.SerializeObject(response));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc.ToString());
            }

        }

        const string jsonstring = @"{
	""result"": [
		{
			""status"": ""ERROR"",
			""message"": ""Unknown address""
		},
		[
			{
				""PlaceHasDuplicates"": false,
				""PlaceHasNamedStreets"": false,
				""PlaceHasUnNamedStreets"": true,
				""TheBiggestPlace"": false,
				""city"": ""Sudwa"",
				""community"": ""Olsztynek"",
				""community_terytId"": ""2814095"",
				""country"": ""PL"",
				""district"": ""olszty\\u0144ski"",
				""flat"": """",
				""house"": """",
				""house_full_match"": """",
				""house_geoId"": """",
				""loc"": {
					""x"": 20.263568,
					""y"": 53.58716
				},
				""pcode"": ""11-015"",
				""pcode_prefix_incompatibility"": false,
				""place_terytId"": ""0484593"",
				""place_type"": 10,
				""pna_match"": ""empty"",
				""population"": 157,
				""province"": ""warmi\\u0144sko-mazurskie"",
				""quality"": 6,
				""quarter"": """",
				""quarter_terytId"": """",
				""rect"": {
					""bottom"": 53.5906,
					""left"": 20.2423906,
					""right"": 20.276902,
					""top"": 53.58438
				},
				""result_type"": ""street"",
				""street"": ""Sudwa"",
				""street_terytId"": """",
				""street_uniqId"": ""484593.484593"",
				""city_population"": 157,
				""city_type"": 10,
				""city_nearto"": null,
				""x"": 20.263568,
				""y"": 53.58716,
				""map_link"": ""https:\\/\\/mapa.targeo.pl\\/Sudwa,lokalizacja_sXCFvud04rjcx84h8_SlwtdGSf1RI0OI0zra3aq-BUw,21"",
				""result_radius"": 1191.6329268255245
			}
		],
		[
			{
				""PlaceHasDuplicates"": false,
				""PlaceHasNamedStreets"": true,
				""PlaceHasUnNamedStreets"": false,
				""TheBiggestPlace"": false,
				""city"": ""Krak\\u00f3w"",
				""community"": ""Krak\\u00f3w"",
				""community_terytId"": ""1261011"",
				""country"": ""PL"",
				""district"": ""Krak\\u00f3w"",
				""flat"": """",
				""house"": """",
				""house_full_match"": """",
				""house_geoId"": """",
				""loc"": {
					""x"": 19.9276629,
					""y"": 50.06322
				},
				""pcode"": ""31-123"",
				""pcode_prefix_incompatibility"": false,
				""place_terytId"": ""0950463"",
				""place_type"": 1,
				""pna_match"": ""ok"",
				""population"": 759800,
				""province"": ""ma\\u0142opolskie"",
				""quality"": 7,
				""quarter"": ""Krak\\u00f3w-\\u015ar\\u00f3dmie\\u015bcie"",
				""quarter_terytId"": ""0951327"",
				""rect"": {
					""bottom"": 50.06402,
					""left"": 19.9237121,
					""right"": 19.9325142,
					""top"": 50.06226
				},
				""result_type"": ""street"",
				""street"": ""Krupnicza"",
				""street_terytId"": ""10035"",
				""street_uniqId"": ""950463.2956"",
				""city_population"": 759800,
				""city_type"": 1,
				""city_nearto"": null,
				""x"": 19.9276629,
				""y"": 50.06322,
				""map_link"": ""https:\\/\\/mapa.targeo.pl\\/Krak\\u00f3w,lokalizacja__JbbPvt_f7QDmJFPZQvUNnRFgSQLRDt9lXCZnR19fWw,21"",
				""result_radius"": 329.40577449564128
			}
		],
		{
			""status"": ""ERROR"",
			""message"": ""Unknown address""
		}
	]
}";
    }
   public class AutoMapaRootResponse<T>
    {
        public T Result { get; set; }
    }


    public class RevGeoCodeResponseListConverter : JsonConverter<List<RevGeoCodeResponse>>
{
    public override void WriteJson(JsonWriter writer, List<RevGeoCodeResponse> value, JsonSerializer serializer)
    {
       throw new NotImplementedException();
    }

    public override List<RevGeoCodeResponse> ReadJson(JsonReader reader, Type objectType, List<RevGeoCodeResponse> existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        
        var jo = serializer.Deserialize(reader);
        switch(jo){
            case JObject jobj: return null;
            case JArray jarr: return jarr.ToObject<List<RevGeoCodeResponse>>(); // nie dawać serializera bo się zapętli
        }

        return null;
    }
}


  
   public class RevGeoCodeResponse
    {
        public string country { get; set; }
        public string province { get; set; }
        public string district { get; set; }
        public string community { get; set; }
        public string city { get; set; }
        public string quarter { get; set; }
        public string pcode { get; set; }
        public string street { get; set; }
        public string house { get; set; }
    }
}
