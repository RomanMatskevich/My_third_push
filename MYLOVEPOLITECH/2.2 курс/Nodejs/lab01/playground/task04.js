const lodash = require("lodash");
//1, Видалення элементів з масиву
console.log("\n1. Видалення елементів з массиву")
let arr = [1, 2, 3, 3, 4, 5];
console.log(`Arr - ${arr}`);
lodash.pull(arr, 3)
console.log(`Arr - ${arr}`);

//2, Генерування випадкового числа в певному діапазоні
console.log(`\n2. Генерація випадкового числа від 0 до 10`)
console.log(`Random - ${lodash.random(0,10)}`)

//3,
console.log(`\n3. Drop`)
let arr2 = [1, 2, 3, 3, 4, 5];
console.log(`Arr - ${arr2}`);
console.log(`Arr - ${lodash.drop(arr2, 3)}`);

//4, Розмір масиву
console.log(`\n4. Визначення розміру масиву`)
let arr3 = [1, 2, 3, 3, 4, 5];
console.log(`Arr size - ${lodash.size(arr3)}`);

//5, проходження мо кожному елементу масива і збільшення його на 1.
console.log(`\n5. Проходження мо кожному елементу масива і збільшення його на 1`)

let arr4 = [1, 2, 3, 3, 4, 5];
console.log(`Arr - ${arr4}`);
console.log(`Arr - ${lodash.map(arr4 , item =>{return item+1})}`);