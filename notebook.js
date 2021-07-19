console.log(typeof 42)
console.log(typeof 42.1)
console.log(typeof "42.1")
console.log(typeof '42.1')
console.log(typeof `42.1`)
console.log(2.988e10)
console.log(29.88e10)
console.log(1/0)
console.log(0/1)
console.log(0/0)
console.log(NaN === 0/0) // returns false
console.log(NaN)
let a = NaN
let b = NaN
console.log(a === b) // that's false
let str1 = "aaa"
let str2 = `this is a 

new lines in a string


test`
console.log(str2)
let x =

"aaa"
console.log(x)
console.log(`this is a string template literal ${100/3}`)

// Boolean
console.log(true)
console.log(typeof true)
console.log(typeof (3 > 2))
console.log(3 > 2)

console.log("a" > "b")
console.log("x" > "b")
console.log("X" > "x")

console.log("Itchy" != "Scratchy") // → true
console.log("Apple" == "Orange") // → false

// logical
// && || !
console.log(true || true && false) // true
console.log(true ? 1 : 2)
let n = "apple"
let y =
  n == "apple"  ? 1 :
  n == "banana" ? 2 :
  n == "lemon"  ? 3 :
                  0
console.log(y)

// null undefined
console.log(null)
console.log(undefined)

console.log(typeof null) // object
console.log(typeof undefined) // undefined

// type conversion
console.log(null == undefined) // true
console.log(0 == null)
console.log(0 == undefined)
console.log(0 != null)
console.log(0 != undefined)

console.log("" == 0) // true, automatis type conversion
console.log("" === 0) // no type conversion

// short circuiting of logical operators
console.log(null || "user")
console.log(undefined || "user")
let k = null || "default"

console.group({data: [1,2,3,4,5]})

console.log("bye");

if (1==1) {
    console.log("here")
} else {
  console.log("there")
}

let x2 = 30;
console.log("the value of x is", x2, true, null, undefined);

let theNumber = "ads";
if (!Number.isNaN(Number(theNumber))) {
  console.log("Your number is the square root of " + theNumber * theNumber);
}

if (1 + 1 == 2) console.log("It's true");

let number = 0;
while (number <= 12) {
  console.log(number);
  number = number + 2;
}

let x3 = 10;
do {
  console.log(x3)
  x3 = x3 - 1;
} while (x3 > 2);

for (let number = 0; number <= 12; number = number + 2) {
  console.log(number);
}
Array.from({length:5}, (x,i) => [i, i+1])