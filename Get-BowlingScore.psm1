function Get-BowlingScore {
    param([string]$framesAsText)

    [int]$score = 0

    $frames = @()
    for ($i = 0; $i -lt 20; $i+=2) {
        $frames += @($framesAsText.substring($i, 2))
    }

    if ($framesAsText[19] -eq "/") {
        $frames += @($framesAsText.substring(20, 1) + " ")
    } elseif ($framesAsText[18] -eq "X") {
        $frames += @($framesAsText.substring(20, 2))
    }

    function symbolToPinsDown { # aka. how many pins down
        param([char]$symbol)
        if ($symbol -eq '-') {
            return 0
        } elseif ($symbol -eq 'X') {
            return 10
        }
        else {
            return [int][string]$symbol
        }
    }
    function scoreForFrame {
        param([string]$frame, [string]$nextFrame, [string]$nextNextFrame)

        if ($frame -match "[0-9-]{2}") {
            $sum += symbolToPinsDown $frame[0]
            $sum += symbolToPinsDown $frame[1]
        } elseif ($frame -match "[0-9-]/") {
            $sum += 10
            if ($null -ne $nextFrame) {
                $sum += symbolToPinsDown $nextFrame[0]
            } else {
                # nextFrame is null -> no bonus
            }
        } elseif ($frame -match "X ") {
            $sum += 10
            if ($nextFrame -match "[0-9-]{2}") {
                $sum += symbolToPinsDown $nextFrame[0]
                $sum += symbolToPinsDown $nextFrame[1]
            } elseif ($nextFrame -match "[0-9-]/") {
                $sum += 10
            } elseif ($nextFrame -match "X ") {
                $sum += 10
                $sum += symbolToPinsDown $nextNextFrame[0]
            } else {
                throw "this shoudl not happen"
            }
        } else {
            throw "this shoudl not happen"
        }
        return $sum
    }

    foreach ($frameIndex in @(0..7)) {
        $score += scoreForFrame $frames[$frameIndex] $frames[$frameIndex + 1] $frames[$frameIndex + 2]
    }
    $score += scoreForFrame $frames[8] $frames[9] $null
    if($frames.Length -eq 11) {
        $score += scoreForFrame $frames[9] $frames[10] $null
    } else {
        $score += scoreForFrame $frames[9] $null $null
    }

    return $score
}
