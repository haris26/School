$(document).ready(function(){
    $(".nav-tabs a").click(function(){
        $(this).tab('show');
    });
});


$(document).ready( function() {
    $("#load").on("click", function() {
        $( "#mainContent" ).load( "form1.html");
        $( "#form1" ).addClass('active');
    });
});

$(document).ready( function() {
    $("#load1").on("click", function() {
        $( "#mainContent" ).load( "form2.html");
        $( "#form2" ).addClass('active');
    });
});


$(window).scroll(function() {
  if ($(document).scrollTop() > 50) {
    $('nav').addClass('shrink');
  } else {
    $('nav').removeClass('shrink');
  }
});