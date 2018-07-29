function Get-BowlingScore {
    param([string]$frames)

    [int]$score = 0

    $frames2 = @()
    for ($i = 0; $i -lt 20; $i+=2) {
        $frames2 += @($frames.substring($i, 2))
    }

    if($frames.Length -gt 20) {
        $frames2 += @($frames.substring(20, 1) + " ")
    }

    function charToScore {
        param([char]$score)
        if ($score[0] -eq '-') {
            return 0
        } 
        else {
            return [int][string]$score
        }
    }
    function scoreForFrame {
        param([string]$frame, [string]$nextFrame)

        $sum = charToScore $frame[0]

        if ($frame[1] -eq '-') {
            #do nothing
        } elseif (($frame[1] -eq '/')) {
            $sum = 10
            if($null -eq $nextFrame) {
                #no bonus
            } else {
                $sum += charToScore $nextFrame[0]
            }
        }
        else {
            $sum += [int][string]$frame[1]
        }
        return $sum
    }

    foreach ($frameIndex in @(0..9)) {
        if($frameIndex -lt 9) {
            $score += scoreForFrame $frames2[$frameIndex] $frames2[$frameIndex + 1]
        } else {
            if($frames2.Length -eq 11) {
                $score += scoreForFrame $frames2[$frameIndex] $frames2[$frameIndex + 1]
            }
            else {
                $score += scoreForFrame $frames2[$frameIndex] $null
            }
        }
    }

    return $score
}
