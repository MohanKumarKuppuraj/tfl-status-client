# PROJECT BUILD and EXECUTION

-use the command "dotnet restore" to restore the dependencies

-use the command "dotnet build" to build the project 

-dotnet publish -c Release --output ./Release

-run "Release/RoadStatus.exe" {roadid} from the project root folder to run the client after build. {roadid} is your run time parameter

-echo %errorlevel% to see the Error Level of the client after run.


# CONFIGURATION
    
	
	Default configuration will be 
		{"app_id":"53eb88e1ccb34f52bdb9f92c29a27cd8",
		"app_key":"6cfaa478b1984b8890159a305c24c3be",
		"api_endpoint":"https://api.tfl.gov.uk/"}
	 which is loaded inside the program	


	-App id, App Key and API End Point can be overwritten by placing an appsettings.json in the same directory as that of RoadStatus.exe client



