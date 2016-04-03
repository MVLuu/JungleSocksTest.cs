I. Summary
------------
A package that contains code to run automated UI and service (incomplete) tests against Jungle Socks web page (https://jungle-socks.herokuapp.com/).


II. Design
------------
The solution is written in C# with Visual Studio. The UI tests are separated by a UI driver project and a UI test project. The service tests are separated by web wrappers for the target endpoint(s) and a service test project. The tests are written to handles the expected behaviors and building of the tests data. The web wrapper and UI driver modal projects handles the web calls and UI interactions.


III. Requirements
------------
1. Microsoft Windows operating system.
2. Visual Studio (https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx)
3. Internet connection to download the Nuget packages (Selenium and Chrome drivers).


IV. Execution
------------
There are three ways to run the code after updating the nuget packages and compiling the code.
1. In Visual Studio and run directly through the unit test (recommended).
2. Reference the DLL and run the test.
3. Run the TestRunner.exe console application.

V. Versions
------------
1. (2/12) - Inital sample UI test completed and basic scenario working. 
TODO: 
    a. Work on service wrappers and basic scenario for service test.
    b. Write more tests based on test methodologies (boundary, fuzz, security, etc.).

Thank you,
Michael Luu
