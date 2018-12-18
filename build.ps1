if(-not(Test-Path "packages\nunit*")) { nuget install nunit -outputdirectory packages }
if(-not(Test-Path "packages\nunit.console*")) { nuget install nunit.console -outputdirectory packages }

if(-not(Test-Path "out")) {
    mkdir "out"
}

csc Program.cs /t:library /out:out\kata02.karate.chop.dll
csc Tests.cs /t:library /r:packages\NUnit.3.11.0\lib\net45\nunit.framework.dll,out\kata02.karate.chop.dll /out:out\Tests.dll

copy packages\NUnit.3.11.0\lib\net45\nunit.framework.dll out\nunit.framework.dll