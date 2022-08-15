using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Utility;
using APIRequest;
using APIResponse;
using Handler;
using System.IO;
using System.Text;

namespace Utility{
	public class RoadStatusUtility : IRoadStatusUtility{
		public IRequestUtility requestUtility = new RequestUtility();
		public IResponseHandler responseHandler = new ResponseHandler();
		IConfiguration Configuration = new ConfigurationBuilder().AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes("{\"app_id\":\"53eb88e1ccb34f52bdb9f92c29a27cd8\",\"app_key\":\"6cfaa478b1984b8890159a305c24c3be\",\"api_endpoint\":\"https://api.tfl.gov.uk/\"}"))).AddJsonFile("appsettings.json",true).Build();
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