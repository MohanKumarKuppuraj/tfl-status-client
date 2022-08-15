using System;
using System.Collections.Generic;
using APIResponse;

namespace Utility{
	public interface IRoadStatusUtility{
		public ResponseData GetRoadDetails(String roadId);
	}
}