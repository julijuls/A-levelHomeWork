//1. Напишите код вычисления суммы всех нечетных чисел от 0 до заданного
//числа N
//- Спрашиваем у пользователя через prompt
//- Переводим в number(потому что из prompt мы получаем строку)
//- Дальше думаем сами
//В конце просто я должен увидеть сумму от 0 до N числа, который я ввёл
var N=parseInt(prompt("Enter number"));
var SumNumbers=0;
for(var i=1; i<=N;i++){
    if (i%2==1){
        SumNumbers+=i;
    }
}
console.log('SumNumbers='+SumNumbers);