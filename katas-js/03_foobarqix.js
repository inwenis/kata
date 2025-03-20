function isMultiplicaitonOf(x, arr) {
    return arr.some(i => x % i === 0)
}

function includes(x, arr) {
    const s = x.toString()
    return arr.some(i => s.includes(i.toString()))
}

function foobarqix(x) {
    const map = [
        {n: 3, t: "Foo"},
        {n: 5, t: "Bar"},
        {n: 7, t: "Qix"},
        {n: 9, t: "Xix"},
    ]
    const keys = map.map(x => x.n)
    let m = ""
    if (isMultiplicaitonOf(x, keys) || includes(x, keys)) {
        let s = x.toString()
        for (pair of map) {
            if (x % pair.n === 0) { m += pair.t }
        }
        for (pair of map) {
            s = s.replace(new RegExp(pair.n, 'g'), pair.t)
        }
        s =
          s
          .replace(/0/g, "*")
          .replace(/\d/g, "")
        m = `${m}${s}`
    } else {
        m = x.toString().replace(/0/g, "*")
    }

    return `${x} => ${m}`
}

let x = Array.from({length: 100}, (_, i) => i + 1).map(x => foobarqix(x))
for (i of x) {
    console.log(i)
}
console.log(foobarqix(101))
console.log(foobarqix(303))
console.log(foobarqix(105))
console.log(foobarqix(10101))