//02. Создайте три переменные с любыми числовыми значениями. Используя условный оператор  
//и не используя логические, найдите минимальное число и отобразите на экране имя переменной и ее значение.
var minNum;
var minName;
let a=20;
let b=30;
let c=40;
  if(a < b) {
    minNum = a;
    minName="a";
  } else {
    minNum = b;
    minName="b";
  }
  if(c < minNum) {
    minNum = c;
    minName="c";
  }
  console.log('min value: '+minName+'='+minNum);