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
		public IRequestUtility requestUtility;
		public IResponseHandler responseHandler;

		public RoadStatusUtility(){
			this.requestUtility = new RequestUtility();
			this.responseHandler = new ResponseHandler();
		}

		/*
			Constructor to pass mocked Request Utility Object
		*/
		public RoadStatusUtility(IRequestUtility _requestUtility){
			this.requestUtility = _requestUtility;
			this.responseHandler = new ResponseHandler();
		}

		IConfiguration Configuration = new ConfigurationBuilder().AddJsonStream(new MemoryStream(Encoding.ASCII.GetBytes("{\"app_id\":\"53eb88e1ccb34f52bdb9f92c29a27cd8\",\"app_key\":\"6cfaa478b1984b8890159a305c24c3be\",\"api_endpoint\":\"https://api.tfl.gov.uk/\"}"))).AddJsonFile("appsettings.json",true).Build();
		
		/// <summary>
		/// Function to Get Road Status Details
		/// </summary>
		/// <param name="roadId">Road Id supplied from client args</param>
		/// <returns>
		/// Returns ResponseData of a defined format
		/// </returns>
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