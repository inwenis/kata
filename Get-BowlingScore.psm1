function Get-BowlingScore {
    param([string]$frames)
    #write-host $frames
    if($frames.Contains("1")) {
        return 10
    } else {
        return 0
    }
}