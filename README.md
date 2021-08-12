# Flight Simulator App
The app transfers data to the plane using the flight simulator.
In addition, there is a dashboard that displays the flight info and joystick.
The code use MVVM design pattren. we use .NET framework to create this WPF app. 

## How To Use:
1.Install flight fear

2.Open flight gear setting and put in the bottom text box in "Additional Setting" the current commend:

> --generic=socket,in,10,127.0.0.1,5400,tcp,playback_small
> 
> --fdm=null

3.Press "fly"

4.Open the app while flight gear loading

5.Load the csv and xml files.
if exist,the app load by deafult the files:
> C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\playback_small.xml

> C:\\Program Files\\FlightGear 2020.3.6\\data\\Protocol\\reg_flight.csv

  In addition the app save automatic the XML and CSV files in :
> C:\\Program Files\\FlightGear 2020.3.6  
  
  make sure you change it if Flight Gear is saved in another location.

enjoy!
## info
UML
https://lucid.app/lucidchart/invitations/accept/inv_d6f00fa3-8681-463b-8a9e-89ccf457eae4?viewport_loc=125%2C2%2C1278%2C668%2C0_0
