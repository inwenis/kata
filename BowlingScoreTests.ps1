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
test 0 "0-0-0-0-0-0-0-0-0-0-" "10 frames with score 0 should return 0"
test 54 "1-2-3-4-5-6-7-8-9-9-" "score for frames without strikes and spares returns sum of pins in all frames"
test 55 "112-3-4-5-6-7-8-9-9-" "score for frames without strikes and spares returns sum of pins in all frames and pins from second try are counted also"
test 10 "2/0-0-0-0-0-0-0-0-0-" "a spare equals 10 pins in a frame"
test 10 "-/0-0-0-0-0-0-0-0-0-" "a spare equals 10 pins in a frame"
test 12 "-/1-0-0-0-0-0-0-0-0-" "spare bonus double pins from next roll"
