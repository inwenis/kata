function Get-BowlingScore {
    param([string]$framesAsText)

    function symbolToPinsDown { # aka. how many pins down
        param([string]$framesAsText, [int]$index)
        $symbol = $framesAsText[$index]
        if ($symbol -eq '-') {
            return 0
        } elseif ($symbol -eq 'X') {
            return 10
        } elseif ($symbol -eq '/') {
            return 10 - (symbolToPinsDown $framesAsText ($index - 1))
        }
        else {
            return [int][string]$symbol
        }
    }

    [int] $sum = 0
    [int] $index = 0
    foreach ($frame in @(1..10)) {
        if ($framesAsText.Substring($index, 2) -match "[0-9-]{2}") {
            $sum += symbolToPinsDown $framesAsText ($index + 0) # pins down
            $sum += symbolToPinsDown $framesAsText ($index + 1) # pins down
            $index += 2
        } elseif ($framesAsText.Substring($index, 2) -match "[0-9-]/") {
            $sum += symbolToPinsDown $framesAsText ($index + 0) # pins down
            $sum += symbolToPinsDown $framesAsText ($index + 1) # pins down
            $sum += symbolToPinsDown $framesAsText ($index + 2) # bonus
            $index += 2
        } elseif ($framesAsText[$index] -eq 'X') {
            $sum += symbolToPinsDown $framesAsText ($index + 0) # pins down
            $sum += symbolToPinsDown $framesAsText ($index + 1) # bonus
            $sum += symbolToPinsDown $framesAsText ($index + 2) # bonus
            $index += 1
        } else {
            throw "this should not happen"
        }
    }

    return $sum
}
