using System;
using System.Collections.Generic;
using APIResponse;
using Newtonsoft.Json;

namespace Handler{

	public class ResponseHandler: IResponseHandler{
		public ResponseData RoadStatusResponseHandler(String roadId,String apiResponseStr ){
			ResponseData response = new ResponseData();
			//Error First Approach
			List<Dictionary<String,Object>> apiResponse = new List<Dictionary<String,Object>>();
			try{
				apiResponse = JsonConvert.DeserializeObject<List<Dictionary<String,Object>>>(apiResponseStr);
			}catch(JsonSerializationException exListDict){
					try{
						Dictionary<String,Object> apiResponseObj = JsonConvert.DeserializeObject<Dictionary<String,Object>>(apiResponseStr);
						apiResponse.Add(apiResponseObj);
					}catch(JsonSerializationException exDict){
						apiResponse = null;
					}
			}catch(ArgumentNullException nullPointerException)
			{
				apiResponse = null;
			}
			if(apiResponse == null){
				response.message += "Unable to connect the server, Server does not return any data"+ Environment.NewLine;
			}else if(roadId == null || roadId.Trim().Equals("")){
				response.message += "Program not supplied with Road ID"+ Environment.NewLine;
			}else if(apiResponse.Count >0){
				if(apiResponse[0]!=null){
					if(apiResponse[0].Keys.Count>0 && apiResponse[0].ContainsKey("httpStatusCode")){
						switch(apiResponse[0]["httpStatusCode"].ToString()){
							case "404":
								response.statusCode = 1;
								response.message +=  roadId+" is not a valid road"+ Environment.NewLine;
							break;
							default:
								response.statusCode = 1;
								response.message +=  "Unhandled code for status code "+ apiResponse[0]["httpStatusCode"].ToString()  + Environment.NewLine;
							break;
						}
					}else if(apiResponse[0].Keys.Count>0 && apiResponse[0].ContainsKey("displayName")){
						response.message += "The status of the "+ apiResponse[0]["displayName"]+" is as follows"+ Environment.NewLine;
						if(apiResponse[0].ContainsKey("statusSeverity")){
							response.message += "Road Status is " + apiResponse[0]["statusSeverity"] + Environment.NewLine;
						}
						if(apiResponse[0].ContainsKey("statusSeverityDescription")){
							response.message += "Road Status Description is "+ apiResponse[0]["statusSeverityDescription"]+ Environment.NewLine;
						}
						response.results = apiResponse[0];
					}else{
						response.message += "Server does not return data"+ Environment.NewLine;
					}
				}else{
					response.message += "Server does not return data"+ Environment.NewLine;
				}
			}else{
				response.message += "Server does not return data"+ Environment.NewLine;
			}

			return response;
		}
	}
}