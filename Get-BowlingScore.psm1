function Get-BowlingScore {
    param([string]$framesAsText)

    [int]$score = 0

    $frames = @()
    for ($i = 0; $i -lt 20; $i+=2) {
        $frames += @($framesAsText.substring($i, 2))
    }

    if($framesAsText.Length -gt 20) {
        $frames += @($framesAsText.substring(20, 1) + " ")
    }

    function charToScore { # aka. how many pins down
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
            $sum += charToScore $frame[0]
            $sum += charToScore $frame[1]
        } elseif ($frame -match "[0-9-]/") {
            $sum += 10
            if ($null -ne $nextFrame) {
                $sum += charToScore $nextFrame[0]
            } else {
                # nextFrame is null -> no bonus
            }
        } elseif ($frame -match "X ") {
            $sum += 10
            if ($nextFrame -match "[0-9-]/") {
                $sum += 10
            } elseif ($nextFrame -match "X ") {
                $sum += 10
            } else {
                $sum += charToScore $nextFrame[0]
                $sum += charToScore $nextFrame[1]
            }
        } else {
            throw "this shoudl not happen"
        }
        return $sum
    }

    foreach ($frameIndex in @(0..9)) {
        if($frameIndex -lt 8) {
            $score += scoreForFrame $frames[$frameIndex] $frames[$frameIndex + 1] $frames[$frameIndex + 2]
        } elseif ($frameIndex -eq 8) {

            $score += scoreForFrame $frames[$frameIndex] $frames[$frameIndex + 1] $frames[$frameIndex + 2]
        } else {


            if($frames.Length -eq 11) {
                $score += scoreForFrame $frames[$frameIndex] $frames[$frameIndex + 1]
            }
            else {
                $score += scoreForFrame $frames[$frameIndex] $null
            }
        }
    }

    return $score
}
