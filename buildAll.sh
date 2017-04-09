#!/bin/bash
cd FootlooseFS.Models.NetCore
dotnet build
cd ..
cd FootlooseFS.DataPersistence.NetCore
dotnet build
cd ..
cd FootlooseFS.Service.NetCore
dotnet build
cd ..
cd FootlooseFS.Service.NetCore.Tests
dotnet build
cd ..
cd FootlooseFS.Web.Service.NetCore
dotnet build
cd ..
