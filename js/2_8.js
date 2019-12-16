//8. Создайте переменную str и присвойте ей значение 'Привет, Мир!'.
// Выведите сумму всех charCode этой переменной
var str='Привет, Мир!';
var sum;
for(var i=0;i<str.length;i++)
{
    sum+=parseInt(str.charCodeAt(i));
   
}

console.log(sum);