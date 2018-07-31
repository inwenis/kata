if(-not(Test-Path "packages\nunit*")) {
    nuget install nunit -outputdirectory packages
}

if(-not(Test-Path "out")) {
    mkdir "out"
}

csc Game.cs /t:library /out:out\Game.dll
csc GameTests.cs /t:library /r:packages\NUnit.3.10.1\lib\net45\nunit.framework.dll,out\Game.dll /out:out\GameTests.dll