# CombiCon

 A gyroscopic/artificially intelligent passcode system that can allow a user to login with their password created in 3d space or with a 'knock pattern' that will count the amount of times the controller has changed direction in the user's hand (e.g. forward/back).

## !! - Prerequisites

- In order to build and run - install visual studio's recommended NuGet packages (upon loading the .sln)
- You will also need to use 'https://github.com/signal11/hidapi' - build and extract the .dll file then move that into System32 to be used at runtime with CombiCon
- Windows users will need to ensure that CombiCon is built and run with a 32bit cpu - otherwise you will get an error thrown from the old hidapi you build in the previous step.
- The code is designed to also be integrated with the Twilio API - either remove the functionality to tie in a link to your own Twilio account inside the 'MessageSender.cs' class.
