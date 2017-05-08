This project is a port of service API feature of FootlooseFinancialServices .NET project to .NET Core on Linux.
Essentially this project is a Web API written in .NET Core 1.1 using a SQLite3 database. Other technologies that are 
utilized are Entity Framework for .NET Core and JWT (JSON Web tokens).


# How to build on Ubuntu Linux

## Install git (if necessary)

sudo apt install git

## Install .NET Core

Follow the instructions here: https://www.microsoft.com/net/core#linuxubuntu

## Download from github, build, test, and run

git clone https://github.com/pcarrasco23/FootlooseFinancialServiceNetCore

cd FootlooseFinancialServicesNetCore

./buildAll.sh

./testAll.sh

./runApi.sh

By default the web service will listen on port 5000

## Testing the API over HTTP

The API consists of the following methods:
/Login
/api/register
/api/accounts
/api/contactinfo
/api/changepassword

To test any of these methods of the service open another temrinal window and install curl:

sudo apt-get install curl

Then run the following curl command to test the Login (the demo user is avenere and the password is Avenere1!):

curl -H "Content-Type: application/x-www-form-urlencoded" -X POST -d 
'userName=avenere&password=Avenere1!' http://localhost:5000/Login

The API will respond with a JWT (JSON Web Token)

{
  "access_token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhdmVuZXJlIiwianRpIjoiM2VmZWM2YmYtYTA4Yy00MTllLTllMTAtMTVmMzc4YzdmNDM2IiwiaWF0IjotNjIxMzU1OTY4MDAsIlVzZXJOYW1lIjoiYXZlbmVyZSIsImV4cCI6MTQ5NDMxMTg2NH0.dUTv1dVqcqROYRzSuSG5SMXUuTZ6igFA2FK7GzF-RCI",
  "expires_in": 1000
}

The /api/accounts method requires a valid, non-expired JWT from the Login. 
To test the method run the following command:

curl -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInRI6IkpXVCJ9.eyJzdWIiOiJhdmVuZXJlIiwianRpIjoiM2VmZWM2YmYtYTA4Yy00MTllLTllMTAtMTVmMzc4YzdmNDM2IiwiaWF0IjotNjIxMzU1OTY4MDAsIlVzZXJOYW1lIjoiYXZlbmVyZSIsImV4cCI6MTQ5NDMxMTg2NH0.dUTv1dVqcqROYRzSuSG5SMXUuTZ6igFA2FK7GzF-RCI" -X GET http://localhost:5000/api/accounts

Replace the ciphertext in the command with the access_token value that you received in the Login output.
The output from the command wil be JSON containing the user's account and transaction information.


