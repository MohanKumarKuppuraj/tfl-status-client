using System;
using System.Collections.Generic;
using APIResponse;

namespace Handler{
	public interface IResponseHandler{
		public ResponseData RoadStatusResponseHandler(String roadId,String apiResponseStr);
	}
}