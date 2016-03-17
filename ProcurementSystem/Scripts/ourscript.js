$(document).ready(function(){
            $('#sel').on('change', function() {
              if ( this.value == '1')
              {
                   $("#sel2").hide();
                $("#sel1").show();
              }
              else  if ( this.value == '2')
              {
                  $("#sel1").hide();
                $("#sel2").show();
              }
               else
              {
                $("#sel1").hide();
              }
            });
        });
		
		
   $(document).ready(function(){
            $('#dev').on('change', function() {
              if ( this.value == '0')
              {
                $("#other").show();
              }
          
               else
              {
                $("#other").hide();
              }
            });
        });
       