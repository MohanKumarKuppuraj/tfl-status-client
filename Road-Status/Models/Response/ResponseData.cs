using System;
using System.Collections.Generic;

namespace APIResponse{
	public class ResponseData{
		public ResponseData(){
			this.statusCode = 0;
			this.message = "";
			this.hasError = false;
			this.results = new Dictionary<String,Object>(){};
		}

		public int statusCode {get;set;}
		public String message {get;set;}
		public bool hasError {get;set;}
		public Dictionary<String,Object> results {get;set;}
	}
}