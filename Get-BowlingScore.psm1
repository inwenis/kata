function Get-BowlingScore {
    param([string]$frames)

    [int]$score = 0

    for ($i = 0; $i -lt $frames.Length; $i+=1) {
        if($frames[$i] -eq '-') {
            #do nothing
        } elseif ($frames[$i] -eq '/') {
            if($frames[$i-1] -eq '-') {
                $score += 10
            } else {
                $score += 10 - [int][string]$frames[$i-1]
            }

            if($frames[$i+1] -eq '-') {
                #no bonus
            } else {
                $score += [int][string]$frames[$i + 1]
            }

        } else {
            $score += [int][string]$frames[$i]
        }
    }

    return $score
}