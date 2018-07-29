function Get-BowlingScore {
    param([string]$frames)
    [int]$score = 0
    for ($i = 0; $i -lt $frames.Length; $i+=1) {
        #write-host $frames[$i] " " $score
        if(-not($frames[$i] -eq '-')) {
            $score += [int][string]$frames[$i]
        }
    }
    return $score
}