using System;
using System.Net.Mime;
using APIRequest;
using RestSharp;
using System.Collections.Generic;

namespace Utility{

	public class RequestUtility : IRequestUtility{
		public Dictionary<String,RestSharp.Method> methods = new Dictionary<String,RestSharp.Method>(){
			{"",Method.Get},
			{"GET",Method.Get},
			{"POST",Method.Post},
			{"PUT",Method.Put},
			{"PATCH",Method.Patch},
			{"DELETE",Method.Delete}
		};

		public String RequestAPI(RequestOptions requestOptions){
			try{
			RestClient restClient = new RestClient(requestOptions.endPoint);
			RestRequest restRequest = new RestRequest(requestOptions.path, methods[requestOptions.method == null ? "GET": requestOptions.method.Trim().ToUpper()] );
			
			if(requestOptions.headers!=null){
				foreach(String s in requestOptions.headers.Keys){
					restRequest.AddHeader(s,requestOptions.headers[s]);
				}
			}

			if(requestOptions.formData!=null){
				foreach(String s in requestOptions.formData.Keys){
					restRequest.AddParameter(s,requestOptions.formData[s]);
				}
			}

			if(requestOptions.queryParameters!=null){
				foreach(String s in requestOptions.queryParameters.Keys){
					restRequest.AddQueryParameter(s,requestOptions.queryParameters[s]);
				}
			}
			
			if(requestOptions.body!=null){
				restRequest.AddStringBody(requestOptions.body,"application/json");
			}

			var restSharpResponse = restClient.Execute(restRequest);
			return restSharpResponse.Content;
			}catch(Exception ex){

			}
			return "";
		}

	}
}