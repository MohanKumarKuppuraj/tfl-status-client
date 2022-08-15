using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Utility;
using APIRequest;
using APIResponse;
using Handler;

namespace Utility{
	public class RoadStatusUtility : IRoadStatusUtility{
		public IRequestUtility requestUtility = new RequestUtility();
		public IResponseHandler responseHandler = new ResponseHandler();
		IConfiguration Configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
		public ResponseData GetRoadDetails(String roadId){
			String response =	requestUtility.RequestAPI(new RequestOptions(){
				endPoint = Configuration["api_endPoint"],
				path = "Road/"+roadId,
				queryParameters = new Dictionary<String,String>(){
					{"app_id",Configuration["app_id"]},
					{"app_key",Configuration["app_key"]}
				}
			});
			ResponseData responseData= responseHandler.RoadStatusResponseHandler(roadId,response);
			return responseData;
		}

	}
}