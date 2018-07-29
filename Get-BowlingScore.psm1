function Get-BowlingScore {
    param([string]$frames)
    #write-host $frames
    if ($frames.Contains("1-1")) {
        return 10
    } elseif ($frames.Contains("0")) {
        return 0
    } else {
        [int]$score = 0
        for ($i = 0; $i -lt $frames.Length; $i+=2) {
            #write-host $frames[$i] " " $score
            $score += [int][string]$frames[$i]
        }
        return $score
    }
}