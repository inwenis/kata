import-module .\Get-BowlingScore.psm1 -Force

function test {
    param([int]$expected, [string]$testInput, [string]$message)
    $result = Get-BowlingScore $testInput
    if($result -eq $expected) {
        write-host "ok $message"
    } else {
        write-host "test failed : expected:$expected actual:$result  $message" -ForegroundColor red
    }
}

test -expected 10 -testInput "1-1-1-1-1-1-1-1-1-1-" -message "10 frames with score 1 should return 10"
#test 0 "0-0-0-0-0-0-0-0-0-0-" "10 frames with score 0 should return 0"
