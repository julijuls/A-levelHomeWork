//11 Дошли? Прекрасно.
//Напишите скрипт, который считает количество секунд в часе, в сутках, в месяце.
//Спрашиваем у пользователя через prompt число.
//Если пользователь ввёл 10h, то мы выводим ему количество секунд за 10 часов.
//Если пользователь ввёл 10d, то мы выводим ему количество секунд за 10 дней.
//Если пользователь ввёл 10w, то мы выводим ему количество секунд за 10 недел.
//сли пользователь ввёл 10m, то мы выводим ему количество секунд за 10 месяц.
//Проверяем то, что в конце)
var houruser=prompt("Enter number /d/h/w/m");
var last = houruser.slice(-1);
var hour=houruser.split(last);
console.log(hour[0]);
hours_to_number=parseInt(hour[0]);
var result;
if (last=="h"){
    result=hour[0]*60;
}else if(last="d"){
    result=hour[0]*60*24;

}else if(last="w"){
    result=hour[0]*60*24*7;

}else if(last="m"){
    result=hour[0]*60*24*31;

}
console.log(result+"sec");
