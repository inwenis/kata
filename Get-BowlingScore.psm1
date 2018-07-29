function Get-BowlingScore {
    param([string]$frames)

    [int]$score = 0

    $frames2 = @()
    for ($i = 0; $i -lt $frames.Length; $i+=2) {
        $frames2 += @($frames.substring($i, 2))
    }

    function scoreForFrame {
        param([string]$frame, [string]$nextFrame)
        if ($frame[0] -eq '-') {
            #do nothing
        } 
        else {
            $sum += [int][string]$frame[0]
        }

        if ($frame[1] -eq '-') {
            #do nothing
        } elseif (($frame[1] -eq '/')) {
            $sum = 10
            if($null -eq $nextFrame) {
                #no bonus
            } else {
                $sum += [int][string]$nextFrame[0]
            }
        }
        else {
            $sum += [int][string]$frame[1]
        }
        return $sum
    }

    for ($i = 0; $i -lt $frames2.Count; $i++) {
        if($i -lt $frames2.Count - 1) {
            $score += scoreForFrame $frames2[$i] $frames2[$i + 1]
        } else {
            $score += scoreForFrame $frames2[$i] $null
        }
    }

    return $score
}
