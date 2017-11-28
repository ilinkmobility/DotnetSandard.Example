# DotnetSandard.Example

# Adding Xamarin.UITest to a Solution

REQUREMNETS : 

In order to run Xamarin.UITests with Visual Studio, the following dependencies must be met:

 1.NUnit 2.6.x – Xamarin.UITest is not compatible with NUnit 3.x.
 2.A Test Runner for Visual Studio – A 3rd party test runner, such 
   as the NUnit Test Adapter for NUnit 2 or Resharper from Jetbrains,
   is required for Visual Studio to be able to run the NUnit tests. 
   The NUnit3TestAdapter is not compatible with Xamarin.UITest.
 3.Android SDK – Only if testing Android apps. Windows requires that the 
   ANDROID_HOME  environment variable is set with the path to the Android SDK.
 4.Java Developers Kit – Only if testing Android apps.
 
 STEPS :
 
  1.ADDING UI TEST PROJECT TO A SOLUTION :
  
    The first step is to add a new project to the solution. Start Visual Studio 
	and open the solution. Right click on the solution in Solution Explorer and 
	select Add > New Project. From the New Project dialog that appears, 
	select Visual C# > Test in the left hand tree view. 
	This will display the all of the testing templates in the middle panel. 
	Select the UI Test App that is appropriate for your solution.
	Give the project a name and click the OK button. 
	The template will create a new project that includes the NUnit,
	NUnit Visual Studio Test Adapter, and Xamarin.UITest libraries from NuGet.
	
  2.ASSOCIATE THE MOBILE APP PROJECTS WITH THE UI TEST PROJECT :  
  
    The next step is to establish the association between the UITest project and the mobile apps.
	Right click on the References folder in the UITest project and select Add References... from the context menu. 
	Select the mobile app projects from the Reference Manager dialog that appears.
	Click Ok and observe that the UITest project now has references to the mobile app projects.
	
  3.ADDING XAMARIN TEST CLOUD AGENT TO THE MOBILE APP PROJECT : 
  
    The Xamarin Test Cloud Agent is an special embedded HTTP server that allows UITests to interact with the iOS/Android user interface.
	The Test Cloud Agent is added to the iOS/Android project via NuGet.In Visual Studio, right click on the iOS/Android project,
	and select Manage NuGet Packages from the context menu. Search for Xamarin Test Cloud Agent in the NuGet Package Manager and click OK to install that package.
	
  4.INITIALIZING THE XAMARIN TEST CLOUD AGENT (only for iOS project):
  
    After adding the Xamarin Test Cloud Agent to the iOS project, it is necessary to initialize the Xamarin Test Cloud Agent 
	when the iOS project starts up. Edit the AppDelegate class and add the following snippet to the FinishedLaunching method:

      // Newer version of Visual Studio for Mac and Visual Studio provide the
      // ENABLE_TEST_CLOUD compiler directive in the Debug configuration,
      // but not the Release configuration.
         #if ENABLE_TEST_CLOUD
         Xamarin.Calabash.Start();
         #endif
		 
    The Xamarin Test Cloud Agent must not be present in a release build of a Xamarin.iOS application; 
	its presence is grounds for the app to be rejected by Apple.By surrounding the initialization code 
	in a conditional compile statement,the Xamarin linker will strip the Xamarin Test Cloud Agent from 
	Release builds, but not Debug builds.
	
 5.CREATING ACCOUNT IN XAMARIN TEST CLOUD :
 
   Inorder to test the mobile app project in the xamarin test cloud,we need to sign up for a 30 days free trial,from the website(https://www.xamarin.com/test-cloud).
   Click on "Get started for free" button availableon the right side of the page.It gets redirected to app centre(https://appcenter.ms/apps).
  
 6.ADDING NEW APP IN APP CENTRE :
   
   Click on Add new -> Add new app and type in the Name and description for the app ,select the OS and Platform that the app runs on.Click Add new app.
   It gets redirected to the page with left panel containing the options for Build,Test,distribute.
   
 7.CONFIGURING : 
 
   Click on Test from the left panel and click on "start testing your app" button.
   
    - SELECT DEVICES : Select the devices for which the tests have to be performed.Click "Select {no. of devices} device" to go to the next step.
	- CONFIGURE : Select the Test Series,System Language and select the Test framework as Xamarin.UITest and click "Next" to proceed to the next step. 
	- SUBMIT :  Follow the instructions given in the Pre-requisites and running tests sub headings.
	    Note : PathToFile.apk/PathToFile.ipa - The path to an apk/ipa file that gets created after the building the Android/iOS mobile app Project.
		       build-dir <arg> - Path to the directory with the built test assemblies (projectpath\UITestproject\bin\Release).
	    

 8.RUNNING TESTS :
 
   Copy the app centre command that has the PathToFile.apk/PathToFilr.ipa and build-dir <arg> configured and run it from the NuGet packages directory using command prompt.
   
 9.RESULT : 
   
   After series of steps(Preparing,validating,creating,uploading) , the tests start to run and after its done, the results and screenshots can be viewed from the app centre website.
   
 
 
   
   
 
 
 
   
	
	
			  