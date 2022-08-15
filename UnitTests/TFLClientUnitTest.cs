using System;
using System.Collections.Generic;
using Xunit;
using APIResponse;
using APIRequest;
using Utility;
using Handler;
using System.IO;


namespace TFLClientTest {
	
	public class TFLClientUnitTest{

		IResponseHandler responseHandler = new ResponseHandler();
		[Fact(DisplayName="Given with positive results, it is expected to get results with key statusSeverity and statusSeverityDescription and message that has the sentence \"Road Status is Closure\" and \"Road Status Description is Closure\"")]
		public void Test_RoadStatus_ResponseHandler_Success_Result(){
			ResponseData response = responseHandler.RoadStatusResponseHandler("A10","[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a10\",\"displayName\":\"A10\",\"statusSeverity\":\"Closure\",\"statusSeverityDescription\":\"Closure\",\"bounds\":\"[[-0.08703,51.52719],[-0.04999,51.68256]]\",\"envelope\":\"[[-0.08703,51.52719],[-0.08703,51.68256],[-0.04999,51.68256],[-0.04999,51.52719],[-0.08703,51.52719]]\",\"url\":\"/Road/a10\"}]");
			Assert.Equal(response.results["statusSeverity"],"Closure");
			Assert.Equal(response.results["statusSeverityDescription"],"Closure");
			Assert.Contains("Road Status is Closure",response.message);
			Assert.Contains("Road Status Description is Closure",response.message);
		}

		[Fact]
		public void Test_RoadStatus_ResponseHandler_Failure_Result(){
			ResponseData response = responseHandler.RoadStatusResponseHandler("A100","[{\"$type\": \"Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities\",\"timestampUtc\": \"2022-08-15T13:36:24.4945317Z\",\"exceptionType\": \"EntityNotFoundException\",\"httpStatusCode\": 404,\"httpStatus\": \"NotFound\",\"relativeUri\": \"/Road/A100?app_id=53eb88e1ccb34f52bdb9f92c29a27cd8&app_key=6cfaa478b1984b8890159a305c24c3be\",\"message\": \"The following road id is not recognised: A100\"}]");
			Assert.Equal(response.results.ContainsKey("statusSeverity"),false);
			Assert.Equal(response.results.ContainsKey("statusSeverityDescription"),false);
			Assert.Contains("A100 is not a valid road",response.message);
		}

		[Fact]
		public void Test_RoadStatus_ResponseHandler_Empty_Result(){
			ResponseData response = responseHandler.RoadStatusResponseHandler("A100","");
			Assert.Equal(response.results.ContainsKey("statusSeverity"),false);
			Assert.Equal(response.results.ContainsKey("statusSeverityDescription"),false);
			Assert.Contains("Unable to connect the server, Server does not return any data",response.message);
		}

		[Fact]
		public void Test_RoadStatus_ResponseHandler_NULL_Result(){
			ResponseData response = responseHandler.RoadStatusResponseHandler("A100",null);
			Assert.Equal(response.results.ContainsKey("statusSeverity"),false);
			Assert.Equal(response.results.ContainsKey("statusSeverityDescription"),false);
			Assert.Contains("Unable to connect the server, Server does not return any data",response.message);
		}

		[Fact]
		public void Test_RoadStatus_ResponseHandler_RoadIdNotSupplied(){	
			ResponseData response = responseHandler.RoadStatusResponseHandler(null,"[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a10\",\"displayName\":\"A10\",\"statusSeverity\":\"Closure\",\"statusSeverityDescription\":\"Closure\",\"bounds\":\"[[-0.08703,51.52719],[-0.04999,51.68256]]\",\"envelope\":\"[[-0.08703,51.52719],[-0.08703,51.68256],[-0.04999,51.68256],[-0.04999,51.52719],[-0.08703,51.52719]]\",\"url\":\"/Road/a10\"}]");
			Assert.Equal(response.results.ContainsKey("statusSeverity"),false);
			Assert.Equal(response.results.ContainsKey("statusSeverityDescription"),false);
			Assert.Contains("Program not supplied with Road ID",response.message);
		}

	}
}