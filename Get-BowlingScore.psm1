function Get-BowlingScore {
    param([string]$frames)
    [int]$score = 0
    for ($i = 0; $i -lt $frames.Length; $i+=2) {
        #write-host $frames[$i] " " $score
        $score += [int][string]$frames[$i]
    }
    return $score
}