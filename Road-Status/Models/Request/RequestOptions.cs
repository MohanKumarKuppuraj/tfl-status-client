using System;
using System.Collections;
using System.Collections.Generic;

namespace APIRequest{
	public class RequestOptions{
		public String endPoint {get;set;}
		public String path {get;set;}
		public String method {get;set;}
		public Dictionary<String,String> headers {get;set;}
		public Dictionary<String,String> formData {get;set;}
		public Dictionary<String,String> queryParameters {get;set;}
		public String body {get;set;}
	}
}