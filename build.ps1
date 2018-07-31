nuget install nunit -outputdirectory packages
csc *.cs /r:packages\NUnit.3.10.1\lib\net45\nunit.framework.dll