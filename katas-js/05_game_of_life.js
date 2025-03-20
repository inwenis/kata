// @ts-check

function toCell(x) {
    const f =
        x === '.' ? false :
        x === '*' ? true :
                    undefined
    return f
}

function toSymbol(x) {
    const f =
        x === false ? ' ' :
        x === true  ? '⬛' :
                    undefined
    return f
}

function sprint(arr) {
    return arr.map(x => x.map(y => toSymbol(y)).join('')).join('\n')
}

function computeNextGen(a) {
    const h = a.length
    const w = a[0].length
    const nextGen = Array.from(Array(h), () => Array(w))
    for (let i = 0; i < h; i++) {
        for (let j = 0; j < w; j++) {
            const isAlive = a[i][j];
            let n = null
            if (i > 0 && i < h-1 && j > 0 && j < w-1) {
                n = [ a[i-1][j-1], a[i-1][j], a[i-1][j+1],
                      a[i][j-1],                a[i][j+1],
                      a[i+1][j-1], a[i+1][j], a[i+1][j+1] ]
            }
            else if (i === 0 && j > 0 && j < w-1) {
                n = [ a[i][j-1],                a[i][j+1],
                      a[i+1][j-1], a[i+1][j], a[i+1][j+1] ]
            }
            else if (i === h-1 && j > 0 && j < w-1) {
                n = [ a[i-1][j-1], a[i-1][j], a[i-1][j+1],
                      a[i][j-1],                a[i][j+1] ]
            }
            else if (j === 0 && i > 0 && i < h-1) {
                n = [                a[i-1][j], a[i-1][j+1],
                                                  a[i][j+1],
                                     a[i+1][j], a[i+1][j+1] ]
            }
            else if (j === w-1 && i > 0 && i < h-1) {
                n = [ a[i-1][j-1], a[i-1][j],
                      a[i][j-1],
                      a[i+1][j-1], a[i+1][j], ]
            }
            else if (i === 0 && j === 0) {
                n = [
                                                a[i][j+1],
                                    a[i+1][j], a[i+1][j+1] ]
            }
            else if (i === 0 && j === w-1) {
                n = [ a[i][j-1],
                      a[i+1][j-1], a[i+1][j],]
            }
            else if (i === h-1 && j === 0) {
                n = [                a[i-1][j], a[i-1][j+1],
                                                  a[i][j+1] ]
            }
            else if (i === h-1 && j === w-1) {
                n = [ a[i-1][j-1], a[i-1][j],
                      a[i][j-1],             ]
            }
            const live = n.filter(x => x === true).length
            const newState =
                isAlive && live < 2                   ? false : // death by underpopulation
                isAlive && live > 3                   ? false : // death by overpopulation
                isAlive && (live === 2 || live === 3) ? true :  // stay alive
                !isAlive && live === 3                ? true :  // become alive
                                                        false
            nextGen[i][j] = newState
        }
    }
    return nextGen
}

function sleep(ms) {
    let x = 0
    for (let i = 0; i < ms; i++) {
        x = x + i
    }
}

const input =
`........
....*...
...**...
........`

const input2 =
`....................................
....*...............................
...**...............................
..............***.........***.......
......***.....................**....
....................................
..........**.......*....***.........
....................................
....................................
...............*....................
........***...................**....
...........***......................
....................****............`

const input3 =
`....................................
....*...............................
.....*..............................
...***..............................
....................................
....................................
....................................
....................................
....................................
....................................
.........**...................**....
...........***......................
....................****............`

const rows = input3.split('\n')
let arrx = rows.map(x => x.split('').map(x => toCell(x)))

for (let i = 0; i < 1000; i++) {
    arrx = computeNextGen(arrx)
    console.clear()
    console.log(sprint(arrx))
    sleep(200000000)
}
