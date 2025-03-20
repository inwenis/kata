// @ts-check

// https://codingdojo.org/kata/DictionaryReplacer/

function replace(input, dict) {
    for (const key in dict) {
        input = input.replace(new RegExp(`\\$${key}\\$`, 'g'), dict[key])
    }
    return input
}

console.log(replace('', {}) + ' (actual)\n (expected)')
console.log(replace('$temp$', {temp: 'temporary'}) + ' (actual)\ntemporary (expected)')
console.log(replace('$t$$t$', {t: 'tmp'}) + ' (actual)\ntmptmp (expected)')
console.log(replace('$t$$t$$x$', {t: 'tmp'}) + ' (actual)\ntmptmp$x$ (expected)')
console.log(replace('$t$$t$$x$', {t: 'tmp', x: 'yes'}) + ' (actual)\ntmptmpyes (expected)')