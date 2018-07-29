import-module .\Get-BowlingScore.psm1 -Force

function test {
    param($expected, $input, $message)
    $result = Get-BowlingScore $input
    if($result -eq 10) {
        write-host "ok"
    } else {
        write-host "test failed : expected:$expected actual:$result  $message" -ForegroundColor red
    }
}

test 10 "1-1-1-1-1-1-1-1-1-1-" "10 frames with score 1 should return 10"