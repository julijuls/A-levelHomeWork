//2.Задача. Создайте переменную str и присвойте ей значение 'abcde'. 
//Обращаясь к отдельным символам этой строки выведите на экран символ 'a', символ 'b', символ 'e'. 
//Перебираем через цикл строку и при переборе строки если текушее значение 
//в цикле будет равно 'a', 'b', 'e' - вывести через console 'Я знаю эту букву'
let str='abcde';
var arr=str.split('');
var a="a";
var b="b";
var e="e";
res = arr.forEach(function(element, index, array) {
    console.log('element:', element);
    if (element == a||element == b||element == e) {
     console.log("я знаю эту букву");
    }
});
