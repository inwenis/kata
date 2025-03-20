// https://codingdojo.org/kata/Diamond/

function copy(arr) {
    return [].concat(arr)
}

function create_top(letter) {
    const top = []
    const a = "A".charCodeAt(0)
    const max = letter.charCodeAt(0) - a + 1
    top.push("_".repeat(max-1) + "A")
    for (let i = 1; i < max; i++) {
        const x = String.fromCharCode(a + i);
        const l = "_".repeat(max-(i+1)) + x + "_".repeat(i*2-1) + x
        top.push(l)
    }
    return top
}

function diamond(letter) {
    const top = create_top(letter)
    const bot = copy(top).reverse().slice(1)
    const diamond = top.concat(bot)
    return diamond
}

for (let line of diamond("J")) console.log(line)
for (let line of diamond("C")) console.log(line)
for (let line of diamond("B")) console.log(line)
for (let line of diamond("A")) console.log(line)