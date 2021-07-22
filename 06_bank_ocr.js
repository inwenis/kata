// https://codingdojo.org/kata/BankOCR/

const input =
`
 _     _  _     _  _  _  _  _ 
| |  | _| _||_||_ |_   ||_||_|
|_|  ||_  _|  | _||_|  ||_| _|
`

let l0, l1, l2, l3
[l0, l1, l2, l3] = input.split('\n')

const dict = {}
for (let i = 0; i < 10; i++) {
    const d =
        l1.substring(i*3, (i+1)*3) + '\n' +
        l2.substring(i*3, (i+1)*3) + '\n' +
        l3.substring(i*3, (i+1)*3)
    dict[d] = i;
};

function decode(test1) {
    let t0, t1, t2, t3
    [t0, t1, t2, t3] = test1.split('\n')

    let result = '';
    for (let i = 0; i < 9; i++) {
        const d =
            t1.substring(i*3, (i+1)*3) + '\n' +
            t2.substring(i*3, (i+1)*3) + '\n' +
            t3.substring(i*3, (i+1)*3)
        result += dict[d];
    }

    return result;
}

let test1 =
`
                           
  |  |  |  |  |  |  |  |  |
  |  |  |  |  |  |  |  |  |
`

let test2 =
`
    _  _     _  _  _  _  _ 
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _|
`

let test3 =
`
 _  _  _     _  _  _  _  _ 
| | _| _||_||_ |_   ||_||_|
|_||_  _|  | _||_|  ||_| _|
`

console.log(decode(test1))
console.log(decode(test2))
console.log(decode(test3))
