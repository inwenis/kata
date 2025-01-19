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
test 0  "0-0-0-0-0-0-0-0-0-0-" "10 frames with score 0 should return 0"
test 54 "1-2-3-4-5-6-7-8-9-9-" "score for frames without strikes and spares returns sum of pins in all frames"
test 55 "112-3-4-5-6-7-8-9-9-" "score for frames without strikes and spares returns sum of pins in all frames and pins from second try are counted also"
test 10 "2/0-0-0-0-0-0-0-0-0-" "a spare equals 10 pins in a frame"
test 10 "-/--0-0-0-0-0-0-0-0-" "a spare equals 10 pins in a frame"
test 12 "-/1-0-0-0-0-0-0-0-0-" "spare bonus double pins from next roll"
test 11 "0-0-0-0-0-0-0-0-0-0/1" "spare in last frames gives a bonus roll"
test 10 "X0-0-0-0-0-0-0-0-0-" "X is a strike and counts as 10 pins"
test 12 "X1-0-0-0-0-0-0-0-0-" "bonus for strike is double pins from next roll"
test 13 "X1-1-0-0-0-0-0-0-0-" "bonus for strike is double pins from next roll and the roll after it"
test 30 "X1/0-0-0-0-0-0-0-0-" "mixing strike and spare should work"
test 30 "XX0-0-0-0-0-0-0-0-" "strike after a strike"
test 33 "XX1-0-0-0-0-0-0-0-" "after a strike next 2 rolls are in 2 frames"
test 13 "0-0-0-0-0-0-0-0-0-X12" "2 extra rolls for a strike"
test 30 "0-0-0-0-0-0-0-0-0-XXX" "2 extra rolls for a strike"
test 32 "0-0-0-0-0-0-0-0-XX1-" "if you scrore a strike in 8th and 9th frame, the bonus for 8th frames comes frome the extra roll"
test 300 "XXXXXXXXXXXX"
test 90  "9-9-9-9-9-9-9-9-9-9-"
test 150 "5/5/5/5/5/5/5/5/5/5/5"