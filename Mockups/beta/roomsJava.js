 function onBtnClick () {
     document.getElementById("thisWeek").style.color="#0000ff";
    
}
 function test(id) {
     document.getElementById(id).style.backgroundColor = "#3475CD";
 }
 function setDate() {
     var d = new Date();
     if (d.getDay() == 1){
         d = "Monday";
     }
    else if (d.getDay() == 2) {
         d= "Tuesday";
     }
    else if (d.getDay() == 3) {
         d = "Wednesday";
     }
    else if (d.getDay() == 4) {
         d = "Thursday";
     }
     else {
         d = "Friday";
     }
     document.getElementById("date").innerHTML = d;
 }