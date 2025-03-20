// https://codingdojo.org/kata/FizzBuzz/

for (let i = 1; i <= 50; i++) {
    let m = ""
    if (i % 3 === 0) { m += "Fizz" }
    if (i % 5 === 0) { m += "Buzz" }
    if (m === "") { m = i}
    console.log(m)
}

function fizzbuzz(x) {
    let m = ""
    if (x % 3 === 0) { m += "Fizz" }
    if (x % 5 === 0) { m += "Buzz" }
    if (m === "")    { m = x.toString() }
    return m
}

let arr = Array.from({length: 50}, (_, i) => i +1).map(x => fizzbuzz(x) )
console.log(arr)