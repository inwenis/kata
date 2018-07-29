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

    function charToScore {
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
        param([string]$frame, [string]$nextFrame)

        $sum = charToScore $frame[0]

        if ($frame[1] -eq '-') {
            #do nothing
        } elseif (($frame[1] -eq ' ')) {
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
            $score += scoreForFrame $frames[$frameIndex] $frames[$frameIndex + 1]
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
