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
