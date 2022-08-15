using Xunit;
using Moq;
using Handler;
using APIRequest;
using APIResponse;
using Utility;
using System;
using System.Linq;

namespace TFLFeatureClientTest{

public class TFLFeatureTest{
	Mock<IRequestUtility> _requestUtility;
	String roadId;
	public TFLFeatureTest(){
		this._requestUtility = new Mock<IRequestUtility>();
		this._requestUtility.Setup(s=>s.RequestAPI(It.IsAny<RequestOptions>())).Returns((RequestOptions param)=>{
				if(param.path == "Road/A10"){
					return "[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a10\",\"displayName\":\"A10\",\"statusSeverity\":\"Closure\",\"statusSeverityDescription\":\"Closure\",\"bounds\":\"[[-0.08703,51.52719],[-0.04999,51.68256]]\",\"envelope\":\"[[-0.08703,51.52719],[-0.08703,51.68256],[-0.04999,51.68256],[-0.04999,51.52719],[-0.08703,51.52719]]\",\"url\":\"/Road/a10\"}]";
				}else if(param.path == "Road/A11"){
					return "[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a11\",\"displayName\":\"A11\",\"statusSeverity\":\"Good\",\"statusSeverityDescription\":\"No Exceptional Delays\",\"bounds\":\"[[-0.08703,51.52719],[-0.04999,51.68256]]\",\"envelope\":\"[[-0.08703,51.52719],[-0.08703,51.68256],[-0.04999,51.68256],[-0.04999,51.52719],[-0.08703,51.52719]]\",\"url\":\"/Road/a11\"}]";
				}
				else if(param.path == "Road/A12"){
					return "[{\"$type\":\"Tfl.Api.Presentation.Entities.RoadCorridor, Tfl.Api.Presentation.Entities\",\"id\":\"a11\",\"displayName\":\"A11\",\"statusSeverity\":\"Good\",\"statusSeverityDescription\":\"No Exceptional Delays\",\"bounds\":\"[[-0.08703,51.52719],[-0.04999,51.68256]]\",\"envelope\":\"[[-0.08703,51.52719],[-0.08703,51.68256],[-0.04999,51.68256],[-0.04999,51.52719],[-0.08703,51.52719]]\",\"url\":\"/Road/a11\"}]";
				}else{
					return "{\"$type\": \"Tfl.Api.Presentation.Entities.ApiError, Tfl.Api.Presentation.Entities\",\"timestampUtc\": \"2022-08-15T13:36:24.4945317Z\",\"exceptionType\": \"EntityNotFoundException\",\"httpStatusCode\": 404,\"httpStatus\": \"NotFound\",\"relativeUri\": \"/Road/road?app_id=53eb88e1ccb34f52bdb9f92c29a27cd8&app_key=6cfaa478b1984b8890159a305c24c3be\",\"message\": \"The following road id is not recognised: road\"}";
				}

				return "";
			});
	}

	public void ProvidingValidId(){
		this.roadId = "A10";
	}

	public void TestValidRoadId(){
		IRoadStatusUtility roadStatusUtility = new RoadStatusUtility(this._requestUtility.Object);
		ResponseData roadStatusResponseData =  roadStatusUtility.GetRoadDetails(this.roadId);
        Assert.Contains("Road Status is Closure",roadStatusResponseData.message); 
	}


}

}